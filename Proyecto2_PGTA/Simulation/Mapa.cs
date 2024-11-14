using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MultiCAT6.Utils;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Simulation
{
    public partial class Mapa : Form
    {
        //Loading2 loading;
        private Principal principal;
        public GMapControl mapControl;
        List<List<object>> FiltredMessages { get; set; }
        public List<List<object>> AllMessages { get; set; }

        public bool extra = false;
        public Dictionary<int, double> DistancesBySecond { get; private set; } = new Dictionary<int, double>();

        public string TA1 { get; set; }
        public string TA2 { get; set; }
        private bool isDarkMode;


        private int currentSecond;
        private int maxSecond; // Variable para almacenar el máximo segundo disponible
        public GMapOverlay markersOverlay; // Capa de marcadores
        public GMapOverlay routeOverlay;
        private Dictionary<string, GMarkerGoogle> aircraftMarkers; // Guarda los target address de los aviones pintados
        private Dictionary<string, PointLatLng> previousPositions; // Almacena las posiciones anteriores de los aviones

        private System.Windows.Forms.Timer simulationTimer;

        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recBut3;
        private Rectangle recBut4;
        private Rectangle recBut5;
        private Rectangle recBut6;
        private Rectangle recBut7;
        private Rectangle recBut8;
        private Rectangle recCb1;
        private Rectangle recCb2;
        private Rectangle recLbl1;
        private Rectangle recLbl2;
        private Rectangle recLbl3;
        private Rectangle recLbl4;
        private Rectangle recTb1;
        private Rectangle recPtb1;
        private Rectangle recPanel1;
        private Rectangle recPanel2;

        public Mapa(List<List<object>> filtredMessages, List<List<object>> allMessages, int selectedIndexOption, Principal _principal)
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
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add("All data");
            comboBox2.Items.Add("Removing pure blanks");
            comboBox2.Items.Add("Removing fixed transponders");
            comboBox2.Items.Add("Geographic filter");
            comboBox2.Items.Add("Removing flights above 6000 ft");
            comboBox2.Items.Add("Removing on ground flights");
            comboBox2.Items.Add("Combination of these");
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedIndex = selectedIndexOption;


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
            trackBar1.Maximum = 15; // Más rápido
            trackBar1.Value = 1;
            trackBar1.Scroll += trackBar1_Scroll;

            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Time (s)";
            dataGridView1.Columns[1].Name = "Latitude (°)";
            dataGridView1.Columns[2].Name = "Longitude (°)";
            dataGridView1.Columns[3].Name = "Corrected Altitude (m)";
            dataGridView1.Columns[4].Name = "Type";
            dataGridView1.Columns[5].Name = "Target address";
            dataGridView1.Visible = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            panel2.Controls.Add(dataGridView1);
            dataGridView1.ClearSelection();

            this.Resize += Mapa_Resiz;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(MoveBtn.Location, MoveBtn.Size);
            recBut2 = new Rectangle(AutomaticBtn.Location, AutomaticBtn.Size);
            recBut3 = new Rectangle(RestartBtn.Location, RestartBtn.Size);
            recBut4 = new Rectangle(ChangeMapBtn.Location, ChangeMapBtn.Size);
            recBut5 = new Rectangle(button5.Location, button5.Size);
            recBut6 = new Rectangle(extraFunctionalityBtn.Location, extraFunctionalityBtn.Size);
            recBut7 = new Rectangle(CloseBtn.Location, CloseBtn.Size);
            recBut8 = new Rectangle(exportCsvBtn.Location, exportCsvBtn.Size);
            recCb1 = new Rectangle(comboBox1.Location, comboBox1.Size);
            recCb2 = new Rectangle(comboBox2.Location, comboBox2.Size);
            recLbl1 = new Rectangle(label1.Location, label1.Size);
            recLbl2 = new Rectangle(label2.Location, label2.Size);
            recLbl3 = new Rectangle(label3.Location, label3.Size);
            recLbl4 = new Rectangle(label4.Location, label4.Size);
            recTb1 = new Rectangle(trackBar1.Location, trackBar1.Size);
            recPtb1 = new Rectangle(pictureBox7.Location, pictureBox7.Size);
            recPanel1 = new Rectangle(panel1.Location, panel1.Size);
            recPanel2 = new Rectangle(panel2.Location, panel2.Size);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }

        private void Mapa_Resiz(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                resize_Control(MoveBtn, recBut1);
                resize_Control(AutomaticBtn, recBut2);
                resize_Control(RestartBtn, recBut3);
                resize_Control(ChangeMapBtn, recBut4);
                resize_Control(button5, recBut5);
                resize_Control(extraFunctionalityBtn, recBut6);
                resize_Control(CloseBtn, recBut7);
                resize_Control(exportCsvBtn, recBut8);
                resize_Control(comboBox1, recCb1);
                resize_Control(comboBox2, recCb2);
                resize_Control(label1, recLbl1);
                resize_Control(label2, recLbl2);
                resize_Control(label3, recLbl3);
                resize_Control(label4, recLbl4);
                resize_Control(trackBar1, recTb1);
                resize_Control(pictureBox7, recPtb1);
                resize_Control(panel1, recPanel1);
                resize_Control(panel2, recPanel2);

            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                restore_ControlSize(MoveBtn, recBut1);
                restore_ControlSize(AutomaticBtn, recBut2);
                restore_ControlSize(RestartBtn, recBut3);
                restore_ControlSize(ChangeMapBtn, recBut4);
                restore_ControlSize(button5, recBut5);
                restore_ControlSize(extraFunctionalityBtn, recBut6);
                restore_ControlSize(CloseBtn, recBut7);
                restore_ControlSize(exportCsvBtn, recBut8);
                restore_ControlSize(comboBox1, recCb1);
                restore_ControlSize(comboBox2, recCb2);
                restore_ControlSize(label1, recLbl1);
                restore_ControlSize(label2, recLbl2);
                restore_ControlSize(label3, recLbl3);
                restore_ControlSize(label4, recLbl4);
                restore_ControlSize(trackBar1, recTb1);
                restore_ControlSize(pictureBox7, recPtb1);
                restore_ControlSize(panel1, recPanel1);
                restore_ControlSize(panel2, recPanel2);
            }
        }

        private void restore_ControlSize(Control control, Rectangle originalRect)
        {
            control.Location = originalRect.Location;
            control.Size = originalRect.Size;

            // Restauramos el tamaño de la fuente original
            control.Font = new Font(control.Font.FontFamily, 10, control.Font.Style);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }
        private void resize_Control(Control control, Rectangle rect)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);

            int newX = (int)(rect.X * xRatio);
            int newY = (int)(rect.Y * yRatio);

            int newWidth = (int)(rect.Width * xRatio);
            int newHeight = (int)(rect.Height * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);

            // Ajustar tamaño de la fuente
            float fontSizeRatio = Math.Min(xRatio, yRatio); // Escala basada en la menor proporción
            control.Font = new Font(control.Font.FontFamily, control.Font.Size * fontSizeRatio, control.Font.Style);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
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

            List<List<object>> initialAircrafts = new List<List<object>>();

            // Pintar los primeros 4 segundos desde el tiempo inicial (currentSecond) al cargar el formulario
            for (int i = 0; i < 4; i++)
            {
                List<List<object>> result = AircraftsPerSecond(FiltredMessages, currentSecond + i);
                PaintAircrafts(result);
                initialAircrafts.AddRange(result);
            }

            UpdateDataGridView(initialAircrafts);
            // Refrescar el mapa
            mapControl.Refresh();

            // Configurar el segundo de inicio para la simulación
            currentSecond += 4; // El siguiente segundo será el 5º relativo al primer valor de tiempo

        }

        private void UpdateDataGridView(List<List<object>> aircrafts)
        {
            dataGridView1.Rows.Clear();
            foreach (List<object> aircraft in aircrafts)
            {
                int time = Convert.ToInt32(aircraft[0]);
                double latitude = Convert.ToDouble(aircraft[1]);
                double longitude = Convert.ToDouble(aircraft[2]);
                string height = Convert.ToString(aircraft[3]);
                string type = Convert.ToString(aircraft[4]);
                string ta = Convert.ToString(aircraft[6]);

                dataGridView1.Rows.Add(time, latitude, longitude, height, type, ta);
            }
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void MoveBtn_Click(object sender, EventArgs e)
        {
            if (currentSecond <= maxSecond)
            {

                // Obtener los aviones del segundo actual
                List<List<object>> result = AircraftsPerSecond(FiltredMessages, currentSecond);

                // Pintar los aviones del segundo actual
                PaintAircrafts(result);

                UpdateDataGridView(result);

                if (extra == true)
                {
                    double distancia = DistancesBySecond[currentSecond];
                    label4.Text = $"Distance = {distancia:F2} NM"; // Limita a 2 decimales
                }

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
                string Altitude_corrected = Convert.ToString(aircraft[3]);
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

                    double angleGRAD = 0;

                    // Comprobar si hay una posición anterior
                    if (previousPositions.ContainsKey(TA))
                    {
                        // Obtener la posición anterior
                        PointLatLng previousPosition = previousPositions[TA];

                        // Dibujar la línea entre la posición anterior y la actual
                        DrawLine(previousPosition, Position);

                        // Cálculo del ángulo de rotación 
                        double AY = Position.Lat - previousPosition.Lat;
                        double AX = Position.Lng - previousPosition.Lng;
                        double angleRAD = Math.Atan(AY / AX);
                        angleGRAD = angleRAD * 180 / Math.PI;

                        // Ajustar el ángulo si AX es negativo
                        if (AX < 0)
                        {
                            angleGRAD += 180;
                        }
                        if (AX == 0)
                        {
                            angleGRAD = 0;
                        }
                    }

                    Bitmap bitmap = null;

                    if (angleGRAD != 0 && angleGRAD != 90 && angleGRAD != 180 && angleGRAD != -90)
                    {
                        if ((angleGRAD > 0 && angleGRAD < 45) || (angleGRAD > 90 && angleGRAD < 135) || (angleGRAD > -90 && angleGRAD < -45) || (angleGRAD > 180 && angleGRAD < 225))
                        {
                            bitmap = new Bitmap("plane60.png");   //30 degrees

                            if (angleGRAD > 0 && angleGRAD <= 45)
                            {
                                //north-east 
                            }
                            else if (angleGRAD > 90 && angleGRAD <= 135)
                            {
                                bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone); //north-west (rotation clockwise)
                            }
                            else if (angleGRAD <= -45 && angleGRAD > -90)
                            {
                                bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone); //south-east
                            }
                            else if (angleGRAD <= 225 && angleGRAD > 180)
                            {
                                bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone); //south-west
                            }
                        }

                        else if ((angleGRAD > 45 && angleGRAD < 90) || (angleGRAD > 135 && angleGRAD < 180) || (angleGRAD > -45 && angleGRAD < 0) || (angleGRAD > 225 && angleGRAD < 270))
                        {
                            bitmap = new Bitmap("plane30.png");   //30 degrees

                            if (angleGRAD > 45 && angleGRAD < 90)
                            {
                                //north-east 
                            }
                            else if (angleGRAD > 135 && angleGRAD < 180)
                            {
                                bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone); //north-west (rotation clockwise)
                            }
                            else if (angleGRAD < 0 && angleGRAD > -45)
                            {
                                bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone); //south-east
                            }
                            else if (angleGRAD < 270 && angleGRAD > 225)
                            {
                                bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone); //south-west
                            }
                        }
                    }

                    else
                    {
                        bitmap = new Bitmap("plane0.png");

                        if (angleGRAD == 0)
                        {
                            // No se aplica rotación adicional
                        }
                        else if (angleGRAD == 90)
                        {
                            bitmap.RotateFlip(RotateFlipType.Rotate270FlipXY);
                        }
                        else if (angleGRAD == 180)
                        {
                            bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                        }
                        else if (angleGRAD == -90)
                        {
                            bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                    }


                    // Especificar el tamaño del marcador
                    int newWidth = bitmap.Width / 30;
                    int newHeight = bitmap.Height / 30;
                    Bitmap resizedBitmap = new Bitmap(bitmap, new Size(newWidth, newHeight));

                    // Calcular el offset para centrar el bitmap
                    int offsetX = resizedBitmap.Width / 2;
                    int offsetY = resizedBitmap.Height / 2;

                    // Crear el marcador
                    GMarkerGoogle marker = new GMarkerGoogle(Position, resizedBitmap);

                    // Ajustar la posición del marcador para centrar el bitmap
                    marker.Offset = new Point(-offsetX, -offsetY);

                    // Agregar un tooltip al marcador
                    marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
                    marker.ToolTipText = $"Target address: {TA}\nLatitude (°): {latitude}\nLongitude (°): {longitude}\nCorrected Altitude (m): {Altitude_corrected}";

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
            // Limpiar los marcadores y rutas existentes
            markersOverlay.Markers.Clear();
            routeOverlay.Routes.Clear();

            // Limpiar los diccionarios
            aircraftMarkers.Clear();
            previousPositions.Clear();
            dataGridView1.Rows.Clear();

            try
            {
                currentSecond = Convert.ToInt32(FiltredMessages[0][0]);

                List<List<object>> initialAircrafts = new List<List<object>>();

                // Pintar los primeros 4 segundos desde el tiempo inicial
                for (int i = 0; i < 4; i++)
                {
                    // Check if AircraftsPerSecond method returns valid data
                    List<List<object>> result = AircraftsPerSecond(FiltredMessages, currentSecond + i);

                    PaintAircrafts(result);
                    initialAircrafts.AddRange(result);
                }

                UpdateDataGridView(initialAircrafts);

                // Refrescar el mapa
                mapControl.Refresh();

                // Restablecer el TrackBar a su valor mínimo (1)
                trackBar1.Value = 1; // Vuelve a la izquierda (velocidad normal)

                // Actualizar el intervalo del Timer a la velocidad normal
                simulationTimer.Interval = 1000;

                if (AutomaticBtn.Text == "Pause")
                {
                    // Pausar el modo automático
                    simulationTimer.Stop();
                    AutomaticBtn.Text = "Automatic";
                }

                currentSecond += 4;

                if (extra == true)
                {
                    double distancia = DistancesBySecond[currentSecond - 1];
                    label4.Text = $"Distance = {distancia:F2} NM"; // Limita a 2 decimales
                }
            }

            catch
            {
                MessageBox.Show("No messages matched the specified geographic filter. Please adjust the latitude and longitude values.",
                                "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //DeshabilitarControles(button5, comboBox2, CloseBtn);
            }
        }

        //private void DeshabilitarControles(Control filter, Control comboBox, Control close)
        //{
        //    foreach (Control control in this.Controls)
        //    {
        //        if (control != filter && control != comboBox && control !=close)
        //        {
        //            control.Enabled = false;
        //        }
        //    }
        //}

        //private void HabilitarControles(Control filter, Control comboBox, Control close)
        //{
        //    foreach (Control control in this.Controls)
        //    {
        //        control.Enabled = true;
        //    }
        //}

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
            int maxInterval = 1; // Intervalo máximo para la velocidad más rápida

            // Mapeamos el valor del TrackBar a un intervalo, donde el valor mínimo del TrackBar
            // representa la velocidad normal (1000 ms).
            simulationTimer.Interval = minInterval - (trackBarValue - 1) * (minInterval - maxInterval) / (trackBar1.Maximum - 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //HabilitarControles(button5, comboBox2, CloseBtn);
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
            else if (selection == "Geographic filter")
            {
                updatedFilteredMessages = principal.Option4(AllMessages);
            }
            else if (selection == "Removing flights above 6000 ft")
            {
                updatedFilteredMessages = principal.Option5(AllMessages);
            }
            else if (selection == "Removing on ground flights")
            {
                updatedFilteredMessages = principal.Option6(AllMessages);
            }
            else if (selection == "Combination of these")
            {
                updatedFilteredMessages = principal.Option7(AllMessages);
            }

            // Asignar los datos filtrados a FiltredMessages
            FiltredMessages = updatedFilteredMessages;

            extra = false;
            label4.Text = "";

            if (FiltredMessages != null)
            {
                // Reiniciar la simulación con los datos actualizados
                RestartSimulation();
            }

        }

        private async void exportCsvBtn_Click(object sender, EventArgs e)
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

            //Show();
            //Task oTask = new Task(SL);
            //oTask.Start();
            //await oTask;

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
            //Hide();
            MessageBox.Show("Filtered CSV exported successfully.");

        }

        private void extraFunctionalityBtn_Click(object sender, EventArgs e)
        {

            ExtraFunctionality extraFunctionality = new ExtraFunctionality(this);
            this.Enabled = false;
            extraFunctionality.Show();

        }

        public (List<List<object>> filtredMessages, List<string> missingTargets) Option8(List<List<object>> allMessages, string TA1, string TA2)
        {
            List<List<object>> filtredMessages = new List<List<object>>();
            List<string> missingTargets = new List<string>();

            bool ta1Found = false;
            bool ta2Found = false;

            // Recorremos todos los mensajes
            foreach (var message in allMessages)
            {

                string TA = Convert.ToString(message[6]);

                if (TA == TA1)
                {
                    ta1Found = true;
                    filtredMessages.Add(message);
                }
                if (TA == TA2)
                {
                    ta2Found = true;
                    filtredMessages.Add(message);
                }

            }

            // Comprobamos si TA1 y TA2 están presentes
            if (!ta1Found)
                missingTargets.Add(TA1);
            if (!ta2Found)
                missingTargets.Add(TA2);

            return (filtredMessages, missingTargets);

        }

        // CALCULA LA DISTANCIA ENTRE AVIONES CADA SEGUNDO (DESDE EL PRIMER SEGUNDO DE FILTRED MESSAGES HASTA EL ÚLTIMO)
        public Dictionary<int, double> CalculateDistanceForAircrafts(List<List<object>> FiltredMessages, string TA1, string TA2)
        {
            Dictionary<string, PointLatLng> previousPositions = new Dictionary<string, PointLatLng>(); // Almacena las últimas posiciones conocidas
            Dictionary<int, double> distancesBySecond = new Dictionary<int, double>(); // Diccionario para almacenar las distancias por segundo


            // Determinar el primer y último segundo basado en FiltredMessages
            int sec = Convert.ToInt32(FiltredMessages.First()[0]);
            int maxsec = Convert.ToInt32(FiltredMessages.Last()[0]);

            for (int i = sec; i <= maxsec; i++)
            {
                // Obtener aviones para el segundo actual
                List<List<object>> aircraftsInCurrentSecond = AircraftsPerSecond(FiltredMessages, i);

                // Recorremos todos los mensajes
                foreach (var message in aircraftsInCurrentSecond)
                {
                    string TA = Convert.ToString(message[6]);
                    double latitude = Convert.ToDouble(message[1]);
                    double longitude = Convert.ToDouble(message[2]);

                    // Filtramos los mensajes de los aviones TA1 y TA2
                    if (TA == TA1 || TA == TA2)
                    {

                        // Variables para almacenar las posiciones de TA1 y TA2
                        PointLatLng positionTA1 = default;
                        PointLatLng positionTA2 = default;
                        PointLatLng stereographicPositionTA1;
                        PointLatLng stereographicPositionTA2;

                        // Asignar posiciones basadas en el mensaje actual
                        if (TA == TA1)
                        {
                            positionTA1 = new PointLatLng(latitude, longitude);
                        }
                        else if (TA == TA2)
                        {
                            positionTA2 = new PointLatLng(latitude, longitude);

                        }

                        // Utilizar la última posición conocida si uno de los aviones no tiene datos nuevos
                        if (positionTA1.Lat == 0 && previousPositions.ContainsKey(TA1))
                            positionTA1 = previousPositions[TA1];
                        if (positionTA2.Lat == 0 && previousPositions.ContainsKey(TA2))
                            positionTA2 = previousPositions[TA2];

                        // Calcular la distancia si ambas posiciones están disponibles
                        if (positionTA1.Lat != 0 && positionTA2.Lat != 0)
                        {
                            stereographicPositionTA1 = GetStereographic(positionTA1);
                            stereographicPositionTA2 = GetStereographic(positionTA2);
                            double distance = CalculateDistance(stereographicPositionTA1, stereographicPositionTA2);
                            distancesBySecond[i] = distance; // Almacena la distancia para el segundo actual

                        }
                        else
                        {
                            distancesBySecond[i] = 0;

                        }

                        // Guardar las posiciones actuales como últimas conocidas
                        if (positionTA1.Lat != 0)
                            previousPositions[TA1] = positionTA1;
                        if (positionTA2.Lat != 0)
                            previousPositions[TA2] = positionTA2;
                    }

                }
                if (aircraftsInCurrentSecond.Count == 0)
                {
                    distancesBySecond[i] = distancesBySecond.Last().Value;
                }

            }

            DistancesBySecond = distancesBySecond;
            return distancesBySecond;

        }

        public void SetTargetAddresses(List<List<object>> filtredMessages)
        {

            FiltredMessages = filtredMessages;
            RestartSimulation();

        }

        public PointLatLng GetStereographic(PointLatLng position)
        {
            CoordinatesWGS84 coordinatesWGS84 = new CoordinatesWGS84();
            coordinatesWGS84.Lat = position.Lat;
            coordinatesWGS84.Lon = position.Lng;

            coordinatesWGS84.Lat = coordinatesWGS84.Lat * Math.PI / 180;
            coordinatesWGS84.Lon = coordinatesWGS84.Lon * Math.PI / 180;

            GeoUtils geoUtils = new GeoUtils();
            CoordinatesWGS84 myCenterProjection = new CoordinatesWGS84();

            myCenterProjection.Lat = 41 + (6.0 / 60.0) + (56.560 / 3600.0);
            myCenterProjection.Lon = 001 + (41.0 / 60.0) + (33.01 / 3600.0);
            myCenterProjection.Lat = myCenterProjection.Lat * Math.PI / 180.0;
            myCenterProjection.Lon = myCenterProjection.Lon * Math.PI / 180.0;

            CoordinatesWGS84 myCenter = new CoordinatesWGS84();
            myCenter = geoUtils.setCenterProjection(myCenterProjection);

            CoordinatesXYZ Coordinates_geocentric = new CoordinatesXYZ();
            CoordinatesXYZ Coordinates_cart = new CoordinatesXYZ();
            CoordinatesUVH Coordinates_ster = new CoordinatesUVH();

            Coordinates_geocentric = geoUtils.change_geodesic2geocentric(coordinatesWGS84);
            Coordinates_cart = geoUtils.change_geocentric2system_cartesian(Coordinates_geocentric);
            Coordinates_ster = geoUtils.change_system_cartesian2stereographic(Coordinates_cart);

            // Devolver una nueva posición con las coordenadas estereográficas
            return new PointLatLng(Coordinates_ster.U, Coordinates_ster.V);
        }

        public double CalculateDistance(PointLatLng stereographicPositionTA1, PointLatLng stereographicPositionTA2)
        {
            double distance;
            double dU = stereographicPositionTA1.Lat - stereographicPositionTA2.Lat;
            double dV = stereographicPositionTA1.Lng - stereographicPositionTA2.Lng;
            distance = Math.Sqrt(dV * dV + dU * dU);
            distance = (distance / 1852.0);
            return distance;
        }
        //public void SL()
        //{
        //Thread.Sleep(3000);
        //}
        //public void Show()
        //{
        //loading = new Loading2();
        //loading.Show();
        //}
        //public void Hide()
        //{
        //if (loading != null)
        //{
        //loading.Close();
        //}
        //}
    }
}
