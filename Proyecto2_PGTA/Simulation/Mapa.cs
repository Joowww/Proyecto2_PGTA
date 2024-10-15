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

namespace Simulation
{
    public partial class Mapa : Form
    {
        GMapControl mapControl;
        public List<CAT048> cat048 { get; set; }
        public Mapa(List<CAT048> cat048)
        {
            InitializeComponent();
            this.cat048 = cat048;

        }

            private void Mapa_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Option 1");
            comboBox1.Items.Add("Option 2");
            comboBox1.Items.Add("Option 3");

            comboBox2.Items.Add("Option 1");
            comboBox2.Items.Add("Option 2");
            comboBox2.Items.Add("Option 3");

            mapControl = new GMapControl();
            mapControl.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            mapControl.Dock = DockStyle.Fill;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            mapControl.ShowCenter = false;
            panel1.Controls.Add(mapControl);

            // Crear un marcador en la posición inicial
            PointLatLng InitialPos = new PointLatLng(41.298, 2.080);
            GMapMarker marker = new GMarkerGoogle(InitialPos, GMarkerGoogleType.red_dot);
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            markersOverlay.Markers.Add(marker);

            // Añadir el overlay de marcadores al control del mapa
            mapControl.Overlays.Add(markersOverlay);
            mapControl.Zoom = 1000;  // Establecer el zoom al nivel deseado

            mapControl.Update();

            currentPos(cat048);

        }

        static List<List<string[]>> currentPos (List<CAT048> cat048)
        {

            List<List<string[]>> list = new List<List<string[]>> ();
            foreach (CAT048 aircraft in cat048)
            {
                List<string[]> currentAircraft = new List<string[]>();
                list.Add(currentAircraft);
                currentAircraft.Add(new string[]
                {
                    aircraft.LAT,
                    aircraft.LON,
                    aircraft.TN
                });
            }
            return list;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
