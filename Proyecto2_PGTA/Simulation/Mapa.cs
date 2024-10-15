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
        public Mapa()
        {
            InitializeComponent();
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

        }

        //static List<List<object[]>> currentPos(List<List<object>> cat048)
        //{

            // Crear la lista que almacenará las listas internas de string[]
            //List<List<object[]>> list = new List<List<object[]>>();

            // Recorrer cada lista de CAT048 en la lista principal
            //foreach (List<object> aircraftList in cat048)
            //{
                // Crear una lista de string[] para cada lista de CAT048
                //List<object[]> currentAircraftList = new List<object[]>();

                // Añadir la lista de string[] a la lista principal
                //list.Add(currentAircraftList);

                // Recorrer cada objeto CAT048 en la lista actual
                //foreach (CAT048 aircraft in aircraftList)
                //{
                    // Añadir un array de strings con las propiedades LAT, LON y TN de cada aircraft
                    //currentAircraftList.Add(new string[]
                    //{
                //aircraft.LAT,
                //aircraft.LON,
                //aircraft.TN
                   // });
                //}
           // }
            //return list;
        //}
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
