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
        }

        private void Mapa_Load(object sender, EventArgs e)
        {
            mapControl.Position = new PointLatLng(41.298, 2.080);

            mapControl.MinZoom = 1;
            mapControl.MaxZoom = 30;
            mapControl.Zoom = 10;

            mapControl.Update();

        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            List<List<object>> result = AircraftsPerSecond(FiltredMessages, 28801);

            // Crear un objeto de superposición para los marcadores
            GMapOverlay markers = new GMapOverlay("markers");

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

                markers.Markers.Add(marker);
            }
            // Agregar el overlay de marcadores al mapa
            mapControl.Overlays.Add(markers);

            // Ajustar el zoom y la posición después de agregar los marcadores
            if (result.Count > 0)
            {
                double lat = Convert.ToDouble(result[0][1]);
                double lon = Convert.ToDouble(result[0][2]);

                // Centrar el mapa en la primera posición de los aviones
                mapControl.SetPositionByKeywords($"{lat}, {lon}");
                mapControl.Zoom = 11;  // Establecer un zoom adecuado para la vista

                // Forzar la actualización del mapa
                mapControl.Refresh();
            }

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
