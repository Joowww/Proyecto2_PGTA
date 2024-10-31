﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using System.Drawing; // Para el tipo Color
using AstDecoder;
using Accord.Statistics;
using GMap.NET.MapProviders;
using System.Windows.Forms;

namespace Simulation
{
    public partial class Mapa : Form
    {
        private Principal principal;
        GMapControl mapControl;
        List<List<object>> FiltredMessages { get; set; }
        List<List<object>> AllMessages { get; set; }
        private bool isDarkMode;

        private int currentSecond;
        private int maxSecond; // Variable para almacenar el máximo segundo disponible
        private GMapOverlay markersOverlay; // Capa de marcadores
        private GMapOverlay routeOverlay;
        private Dictionary<string, GMarkerGoogle> aircraftMarkers; // Guarda los target address de los aviones pintados
        private Dictionary<string, PointLatLng> previousPositions; // Almacena las posiciones anteriores de los aviones

        private System.Windows.Forms.Timer simulationTimer;

        public Mapa(List<List<object>> filtredMessages, List<List<object>> allMessages, Principal _principal)
        {
            InitializeComponent();
            FiltredMessages = filtredMessages;
            AllMessages = allMessages;
            principal = _principal;

            mapControl = new GMapControl();
            mapControl.MapProvider = GMapProviders.GoogleMap;
            mapControl.Dock = DockStyle.Fill;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            mapControl.ShowCenter = false;
            panel1.Controls.Add(mapControl);

            // Agregar elementos al ComboBox
            comboBox1.Items.Add("Google Maps");
            comboBox1.Items.Add("Bing Maps");
            comboBox1.Items.Add("OpenStreetMap");
            comboBox1.Items.Add("Google Hybrid");
            comboBox1.Items.Add("Google Satellite");
            comboBox1.SelectedIndex = 0; // Seleccionar la primera opción por defecto

            comboBox2.Items.Add("All data");
            comboBox2.Items.Add("Removing pure blanks");
            comboBox2.Items.Add("Removing fixed transponders");
            comboBox2.Items.Add("Combination of these");
            comboBox2.SelectedIndex = 0; // Seleccionar la primera opción por defecto

            // Establecer el primer segundo como el primero en la lista de aviones
            if (FiltredMessages.Count > 0)
            {
                currentSecond = Convert.ToInt32(FiltredMessages[0][0]);
                maxSecond = FiltredMessages.Max(aircraft => Convert.ToInt32(aircraft[0])); // Obtener el segundo máximo
            }

            // Inicializar la capa de marcadores
            markersOverlay = new GMapOverlay("markers");
            mapControl.Overlays.Add(markersOverlay);
            aircraftMarkers = new Dictionary<string, GMarkerGoogle>();
            previousPositions = new Dictionary<string, PointLatLng>();
            routeOverlay = new GMapOverlay("routes");
            mapControl.Overlays.Add(routeOverlay);

            // Inicialización del Timer
            simulationTimer = new System.Windows.Forms.Timer();
            simulationTimer.Interval = 1000; // Ejecuta cada segundo
            simulationTimer.Tick += SimulationTimer_Tick;

            // Configuración del TrackBar para la velocidad
            trackBar1.Minimum = 1; // Más lento
            trackBar1.Maximum = 10; // Más rápido
            trackBar1.Value = 1; // Valor inicial en el medio
            trackBar1.Scroll += trackBar1_Scroll;
        }

        private void Mapa_Load(object sender, EventArgs e)
        {
            // Cargar el estado del tema guardado
            isDarkMode = Properties.Settings1.Default.IsDarkMode;

            // Aplicar el tema según el estado guardado
            ApplyTheme();

            // Si el modo oscuro está activo, aplicarlo
            if (isDarkMode)
            {
                Theme.SetDarkMode(this);
            }
            else
            {
                Theme.SetLightMode(this);
            }


            mapControl.Position = new PointLatLng(41.298, 2.080);

            mapControl.MinZoom = 1;
            mapControl.MaxZoom = 30;
            mapControl.Zoom = 8;

            mapControl.Update();

            // Pintar los primeros 4 segundos desde el tiempo inicial (currentSecond) al cargar el formulario
            for (int i = 0; i < 4; i++)
            {
                List<List<object>> result = AircraftsPerSecond(FiltredMessages, currentSecond + i);
                PaintAircrafts(result);
            }

            // Refrescar el mapa
            mapControl.Refresh();

            // Configurar el segundo de inicio para la simulación
            currentSecond += 4; // El siguiente segundo será el 5º relativo al primer valor de tiempo

        }

        private void MoveBtn_Click(object sender, EventArgs e)
        {
            if (currentSecond <= maxSecond)
            {

                // Obtener los aviones del segundo actual
                List<List<object>> result = AircraftsPerSecond(FiltredMessages, currentSecond);

                // Pintar los aviones del segundo actual
                PaintAircrafts(result);

                // Forzar la actualización del mapa
                mapControl.Refresh();

                // Incrementar el segundo para la próxima vez que se presione el botón
                currentSecond++;
            }
            else
            {
                simulationTimer.Stop(); // Detener el timer si la simulación ha terminado
                AutomaticBtn.Text = "Automatic";
                MessageBox.Show("The simulation has finished");
            }
        }

        static List<List<object>> AircraftsPerSecond(List<List<object>> FiltredMessages, int second)
        {
            List<List<object>> aircraftsSecond = new List<List<object>>();
            // Recorrer todas las listas de FiltredMessages
            foreach (List<object> aircraft in FiltredMessages)
            {
                int timeAircraft = Convert.ToInt32(aircraft[0]);

                // Si el tiempo coincide, agregar la lista de ese avión a la lista de salida
                if (timeAircraft == second)
                {
                    aircraftsSecond.Add(aircraft);  // Agregar la lista del avión
                }
            }
            return aircraftsSecond;
        }

        // Método para pintar los aviones en el mapa
        private void PaintAircrafts(List<List<object>> aircrafts)
        {
            foreach (List<object> aircraft in aircrafts)
            {
                // Obtener los datos del avión
                double latitude = Convert.ToDouble(aircraft[1]);
                double longitude = Convert.ToDouble(aircraft[2]);
                double H = Convert.ToDouble(aircraft[3]);
                string TA = Convert.ToString(aircraft[6]);

                PointLatLng Position = new PointLatLng(latitude, longitude);

                // Verificar si el TA ya está en el diccionario
                if (!string.IsNullOrEmpty(TA))
                {
                    if (aircraftMarkers.ContainsKey(TA))
                    {
                        // Eliminar el marcador anterior
                        markersOverlay.Markers.Remove(aircraftMarkers[TA]);
                    }

                    // Comprobar si hay una posición anterior
                    if (previousPositions.ContainsKey(TA))
                    {
                        // Obtener la posición anterior
                        PointLatLng previousPosition = previousPositions[TA];

                        // Dibujar la línea entre la posición anterior y la actual
                        DrawLine(previousPosition, Position);
                    }

                    // Crear un nuevo marcador
                    string point = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Smiley.png");
                    Bitmap bitmap = (Bitmap)Image.FromFile(point);

                    // Especificar el nuevo tamaño
                    int newWidth = bitmap.Width / 15; // Cambia el tamaño a la mitad
                    int newHeight = bitmap.Height / 15;

                    // Crear un nuevo bitmap más pequeño
                    Bitmap resizedBitmap = new Bitmap(newWidth, newHeight);

                    // Dibujar la imagen original en el nuevo bitmap
                    using (Graphics g = Graphics.FromImage(resizedBitmap))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(bitmap, 0, 0, newWidth, newHeight);
                    }


                    GMarkerGoogle marker = new GMarkerGoogle(Position, resizedBitmap);

                    // Agregar un tooltip al marcador
                    marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
                    marker.ToolTipText = $"{TA}\nLatitude: {latitude}\nLongitude: {longitude}\nHeight: {H}";

                    // Agregar el nuevo marcador a la capa de marcadores
                    markersOverlay.Markers.Add(marker);

                    // Actualizar el diccionario con el nuevo marcador
                    aircraftMarkers[TA] = marker;

                    // Actualizar la posición anterior
                    previousPositions[TA] = Position;

                }
            }
            mapControl.Invalidate();
        }

        private void DrawLine(PointLatLng start, PointLatLng end)
        {
            var route = new GMapRoute(new List<PointLatLng> { start, end }, "MyRoute");
            route.Stroke = new Pen(Color.Red, 2); // Color y grosor de la línea

            routeOverlay.Routes.Add(route);

            // Refrescar el mapa para mostrar la nueva línea
            mapControl.Refresh();
        }

        private void ChangeMapBtn_Click(object sender, EventArgs e)
        {
            string selectedMapType = comboBox1.SelectedItem.ToString();
            // Cambiar el proveedor de mapas según la opción seleccionada con if-else
            if (selectedMapType == "Google Maps")
            {
                mapControl.MapProvider = GMapProviders.GoogleMap;
            }
            else if (selectedMapType == "Bing Maps")
            {
                mapControl.MapProvider = GMapProviders.BingMap;
            }
            else if (selectedMapType == "OpenStreetMap")
            {
                mapControl.MapProvider = GMapProviders.OpenStreetMap;
            }
            else if (selectedMapType == "Google Hybrid")
            {
                mapControl.MapProvider = GMapProviders.GoogleHybridMap;
            }
            else if (selectedMapType == "Google Satellite")
            {
                mapControl.MapProvider = GMapProviders.GoogleSatelliteMap;
            }
            else
            {
                MessageBox.Show("Please select a valid map provider");
            }

            // Actualizar el mapa con el nuevo proveedor
            mapControl.Refresh();
        }

        private void ApplyTheme()
        {
            // Aplica el tema al formulario actual
            if (isDarkMode)
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
            }
            else
            {
                this.BackColor = Color.White;
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            CloseApp CloseAPP = new CloseApp(this);
            this.Enabled = false;
            CloseAPP.Show();
        }

        private void RestartSimulation()
        {
            // Restablecer el segundo actual a 0 o al primer segundo de la lista
            currentSecond = Convert.ToInt32(FiltredMessages[0][0]);

            // Limpiar los marcadores y rutas existentes
            markersOverlay.Markers.Clear();
            routeOverlay.Routes.Clear();

            // Limpiar los diccionarios
            aircraftMarkers.Clear();
            previousPositions.Clear();

            // Pintar los primeros 4 segundos desde el tiempo inicial
            for (int i = 0; i < 4; i++)
            {
                List<List<object>> result = AircraftsPerSecond(FiltredMessages, currentSecond + i);
                PaintAircrafts(result);
            }

            // Refrescar el mapa
            mapControl.Refresh();

            // Restablecer el TrackBar a su valor mínimo (1)
            trackBar1.Value = 1; // Vuelve a la izquierda (velocidad normal)

            // Actualizar el intervalo del Timer a la velocidad normal
            simulationTimer.Interval = 1000; // Asegúrate de que el Timer tenga el intervalo normal

            if (AutomaticBtn.Text == "Pause")
            {
                // Pausar el modo automático
                simulationTimer.Stop();
                AutomaticBtn.Text = "Automatic";
            }
        }

        private void RestartBtn_Click(object sender, EventArgs e)
        {
            RestartSimulation();
        }

        private void AutomaticBtn_Click(object sender, EventArgs e)
        {
            if (AutomaticBtn.Text == "Automatic")
            {
                // Iniciar el modo automático
                simulationTimer.Start();
                AutomaticBtn.Text = "Pause";
            }
            else if (AutomaticBtn.Text == "Pause")
            {
                // Pausar el modo automático
                simulationTimer.Stop();
                AutomaticBtn.Text = "Automatic";
            }

        }

        private void SimulationTimer_Tick(object sender, EventArgs e)
        {
            // Llama al método para avanzar la simulación
            MoveBtn_Click(null, null);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int trackBarValue = trackBar1.Value;

            // Intervalo que definimos como velocidad normal
            int minInterval = 1000; // Intervalo mínimo para la velocidad normal
            int maxInterval = 100; // Intervalo máximo para la velocidad más rápida

            // Mapeamos el valor del TrackBar a un intervalo, donde el valor mínimo del TrackBar
            // representa la velocidad normal (1000 ms).
            simulationTimer.Interval = minInterval - (trackBarValue - 1) * (minInterval - maxInterval) / (trackBar1.Maximum - 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string selection = comboBox2.SelectedItem.ToString();
            List<List<object>> updatedFilteredMessages = new List<List<object>>();

            // Ejecutar la función según la opción seleccionada
            if (selection == "All data")
            {
                updatedFilteredMessages = principal.Option1(AllMessages);
            }
            else if (selection == "Removing pure blanks")
            {
                updatedFilteredMessages = principal.Option2(AllMessages);
            }
            else if (selection == "Removing fixed transponders")
            {
                updatedFilteredMessages = principal.Option3(AllMessages);
            }
            else if (selection == "Combination of these")
            {
                updatedFilteredMessages = principal.Option4(AllMessages);
            }

            // Asignar los datos filtrados a FiltredMessages
            FiltredMessages = updatedFilteredMessages;

            // Reiniciar la simulación con los datos actualizados
            RestartSimulation();

        }

        private void exportCsvBtn_Click(object sender, EventArgs e)
        {
            string rutaCSV = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ASTERIX.csv");

            // Verifica si el archivo original existe
            if (!File.Exists(rutaCSV))
            {
                MessageBox.Show("The CSV file was not found.");
                return;
            }

            // Crear un SaveFileDialog para que el usuario elija el nombre y ubicación del nuevo archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Save Filtered CSV File",
                FileName = "FilteredASTERIX.csv" // Nombre por defecto
            };

            // Mostrar el diálogo y comprobar si el usuario selecciona un nombre de archivo
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return; // Si el usuario cancela, no se hace nada
            }

            string newCsvPath = saveFileDialog.FileName;

            // Crear un HashSet con las claves de mensajes filtrados para búsqueda rápida
            HashSet<string> filteredKeys = new HashSet<string>(
                FiltredMessages.Select(msg => $"{msg[0]}|{msg[1]}|{msg[2]}|{msg[3]}|{msg[4]}|{msg[5]}|{msg[6]}"));

            // Leer y filtrar el archivo original
            var filteredLines = new List<string>();
            using (StreamReader reader = new StreamReader(rutaCSV))
            {
                string header = reader.ReadLine();
                filteredLines.Add(header); // Añadir encabezado

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Separar la línea en columnas
                    string[] row = line.Split('\t').Select(e => e.Trim('\"')).ToArray();
                    string key = $"{row[4]}|{row[5]}|{row[6]}|{row[7]}|{row[8]}|{row[23]}|{row[35]}";

                    // Si el mensaje está en el filtro, agregarlo a la lista
                    if (filteredKeys.Contains(key))
                    {
                        filteredLines.Add(line);
                    }
                }
            }

            // Guardar el nuevo CSV
            File.WriteAllLines(newCsvPath, filteredLines, Encoding.UTF8);
            MessageBox.Show("Filtered CSV exported successfully.");

        }
    }
}
