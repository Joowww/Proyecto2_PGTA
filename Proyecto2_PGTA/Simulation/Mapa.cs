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
        private List<List<object>> FiltredMessages;

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
            mapControl.Zoom = 12;

            mapControl.Update();

        }

        private void RunBtn_Click(object sender, EventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
