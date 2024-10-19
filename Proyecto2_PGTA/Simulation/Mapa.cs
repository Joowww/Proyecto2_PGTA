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
using AstDecoder;
using Accord.Statistics;
using GMap.NET.MapProviders;

namespace Simulation
{
    public partial class Mapa : Form
    {
        GMapControl mapControl;
        List<List<object>> FiltredMessages { get; set; }

        private int currentSecond;
        private int maxSecond; // Variable para almacenar el máximo segundo disponible
        private GMapOverlay markersOverlay; // Capa de marcadores

        public Mapa(List<List<object>> filtredMessages)
        {
            InitializeComponent();
            FiltredMessages = filtredMessages;

            mapControl = new GMapControl();
            mapControl.MapProvider = GMapProviders.GoogleMap;
            mapControl.Dock = DockStyle.Fill;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            mapControl.ShowCenter = false;
            panel1.Controls.Add(mapControl);

            comboBox1.Items.Add("Option 1");
            comboBox1.Items.Add("Option 2");
            comboBox1.Items.Add("Option 3");

            comboBox2.Items.Add("Option 1");
            comboBox2.Items.Add("Option 2");
            comboBox2.Items.Add("Option 3");

            // Establecer el primer segundo como el primero en la lista de aviones
            if (FiltredMessages.Count > 0)
            {
                currentSecond = Convert.ToInt32(FiltredMessages[0][0]);
                maxSecond = FiltredMessages.Max(aircraft => Convert.ToInt32(aircraft[0])); // Obtener el segundo máximo
            }

            // Inicializar la capa de marcadores
            markersOverlay = new GMapOverlay("markers");
            mapControl.Overlays.Add(markersOverlay);
        }

        private void Mapa_Load(object sender, EventArgs e)
        {
            mapControl.Position = new PointLatLng(41.298, 2.080);

            mapControl.MinZoom = 1;
            mapControl.MaxZoom = 30;
            mapControl.Zoom = 8;

            mapControl.Update();

        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            if (currentSecond <= maxSecond)
            {
                // Limpiar los marcadores del segundo anterior
                ClearMarkers();

                List<List<object>> result = AircraftsPerSecond(FiltredMessages, currentSecond);

                // Recorrer la lista de aviones encontrados y agregar un marcador para cada uno
                foreach (List<object> aircraft in result)
                {
                    // Obtener latitud y longitud del avión
                    double latitude = Convert.ToDouble(aircraft[1]);
                    double longitude = Convert.ToDouble(aircraft[2]);
                    double H = Convert.ToDouble(aircraft[3]);
                    string TA = Convert.ToString(aircraft[5]);

                    PointLatLng Position = new PointLatLng(latitude, longitude);

                    GMarkerGoogle marker = new GMarkerGoogle(Position, GMarkerGoogleType.green);

                    // Agregar un tooltip al marcador
                    marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
                    marker.ToolTipText = $"{TA}\nLatitude: {latitude}\nLongitude: {longitude}\nHeight: {H}";

                    markersOverlay.Markers.Add(marker);

                }

                // Forzar la actualización del mapa
                mapControl.Refresh();

                // Incrementar el segundo para la próxima vez que se presione el botón
                currentSecond++;
            }
            else
            {
                MessageBox.Show("The simulation has finished");
            }
        }

        static List<List<object>> AircraftsPerSecond (List<List<object>> FiltredMessages, int second)
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

        private void ClearMarkers()
        {
            // Limpiar los marcadores del mapa
            markersOverlay.Markers.Clear();

            // Forzar la actualización del mapa
            mapControl.Refresh();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
