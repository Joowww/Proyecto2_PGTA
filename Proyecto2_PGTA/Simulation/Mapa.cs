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
        private Principal principal;
        public GMapControl mapControl;
        List<List<object>> FiltredMessages { get; set; }
        public List<List<object>> AllMessages { get; set; }

        public bool extra = false;
        public Dictionary<int, double> DistancesBySecond { get; private set; } = new Dictionary<int, double>();

        public string TI1 { get; set; }
        public string TI2 { get; set; }
        private bool isDarkMode;


        private int currentSecond;
        private int maxSecond; 
        public GMapOverlay markersOverlay; 
        public GMapOverlay routeOverlay;
        private Dictionary<string, GMarkerGoogle> aircraftMarkers; 
        private Dictionary<string, PointLatLng> previousPositions; 

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
        private Rectangle recLbl5;
        private Rectangle recTb1;
        private Rectangle recPtb1;
        private Rectangle recPanel1;
        private Rectangle recPanel2;
        private Rectangle recDgv1;

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


            if (FiltredMessages.Count > 0)
            {
                currentSecond = Convert.ToInt32(FiltredMessages[0][0]);
                maxSecond = FiltredMessages.Max(aircraft => Convert.ToInt32(aircraft[0])); 
            }

            markersOverlay = new GMapOverlay("markers");
            mapControl.Overlays.Add(markersOverlay);
            aircraftMarkers = new Dictionary<string, GMarkerGoogle>();
            previousPositions = new Dictionary<string, PointLatLng>();
            routeOverlay = new GMapOverlay("routes");
            mapControl.Overlays.Add(routeOverlay);

            simulationTimer = new System.Windows.Forms.Timer();
            simulationTimer.Interval = 1000; 
            simulationTimer.Tick += SimulationTimer_Tick;

            trackBar1.Minimum = 1; 
            trackBar1.Maximum = 15; 
            trackBar1.Value = 1;
            trackBar1.Scroll += trackBar1_Scroll;

            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "Time (s)";
            dataGridView1.Columns[1].Name = "Latitude (°)";
            dataGridView1.Columns[2].Name = "Longitude (°)";
            dataGridView1.Columns[3].Name = "Corrected Altitude (m)";
            dataGridView1.Columns[4].Name = "Type";
            dataGridView1.Columns[5].Name = "Target address";
            dataGridView1.Columns[6].Name = "Target identification";
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
            recLbl5 = new Rectangle(label5.Location, label5.Size);
            recTb1 = new Rectangle(trackBar1.Location, trackBar1.Size);
            recPtb1 = new Rectangle(pictureBox7.Location, pictureBox7.Size);
            recPanel1 = new Rectangle(panel1.Location, panel1.Size);
            recPanel2 = new Rectangle(panel2.Location, panel2.Size);
            recDgv1 = new Rectangle(dataGridView1.Location, dataGridView1.Size);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }

        /// <summary>
        /// Adjusts dynamically the size and position of the form's controls based on whether it is maximized or in its normal size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                resize_Control(label5, recLbl5);
                resize_Control(trackBar1, recTb1);
                resize_Control(pictureBox7, recPtb1);
                resize_Control(panel1, recPanel1);
                resize_Control(panel2, recPanel2);
                resize_Control(dataGridView1, recDgv1);

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
                restore_ControlSize(label5, recLbl5);
                restore_ControlSize(trackBar1, recTb1);
                restore_ControlSize(pictureBox7, recPtb1);
                restore_ControlSize(panel1, recPanel1);
                restore_ControlSize(panel2, recPanel2);
                restore_ControlSize(dataGridView1, recDgv1);
            }
        }

        /// <summary>
        /// Restores the original position, size, and font of a control.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="originalRect"></param>
        private void restore_ControlSize(Control control, Rectangle originalRect)
        {
            control.Location = originalRect.Location;
            control.Size = originalRect.Size;

            control.Font = new Font(control.Font.FontFamily, 10, control.Font.Style);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }
        /// <summary>
        /// Dynamically resizes and repositions a control based on the current size of the form relative to its original size.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="rect"></param>
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

            float fontSizeRatio = Math.Min(xRatio, yRatio); 
            control.Font = new Font(control.Font.FontFamily, control.Font.Size * fontSizeRatio, control.Font.Style);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }

        /// <summary>
        /// Initializes map settings, applies dark/light theme, and displays aircraft data for the first 4 seconds. Updates the map and data grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mapa_Load(object sender, EventArgs e)
        {
            isDarkMode = Properties.Settings1.Default.IsDarkMode;

            ApplyTheme();

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

            for (int i = 0; i < 4; i++)
            {
                List<List<object>> result = AircraftsPerSecond(FiltredMessages, currentSecond + i);
                PaintAircrafts(result);
                initialAircrafts.AddRange(result);
            }

            UpdateDataGridView(initialAircrafts);

            UpdateTime(initialAircrafts);
            mapControl.Refresh();

            currentSecond += 4;

        }

        /// <summary>
        /// Populates the data grid with aircraft info (time, position, height, type).
        /// </summary>
        /// <param name="aircrafts"></param>
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
                string ti = Convert.ToString(aircraft[8]);

                dataGridView1.Rows.Add(time, latitude, longitude, height, type, ta, ti);
            }
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        /// <summary>
        /// Displays the time of the last aircraft in the list.
        /// </summary>
        /// <param name="aircrafts"></param>
        private void UpdateTime(List<List<object>> aircrafts)
        {
            var lastAircraft = aircrafts[aircrafts.Count - 1];
            string time = Convert.ToString(lastAircraft[9]);
            label5.Text = time;
        }

        /// <summary>
        /// Advances the simulation by one second, updates the map and grid, and shows distance if enabled. Stops when the simulation ends.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveBtn_Click(object sender, EventArgs e)
        {
            if (currentSecond <= maxSecond)
            {
                List<List<object>> result = AircraftsPerSecond(FiltredMessages, currentSecond);

                PaintAircrafts(result);

                UpdateDataGridView(result);
                UpdateTime(result);

                if (extra == true)
                {
                    double distancia = DistancesBySecond[currentSecond];
                    label4.Text = $"Distance = {distancia:F2} NM"; 
                }

                mapControl.Refresh();

                currentSecond++;
            }
            else
            {
                simulationTimer.Stop(); 
                AutomaticBtn.Text = "Automatic";
                MessageBox.Show("The simulation has finished");
            }
        }


        /// <summary>
        /// Filters aircraft data based on the specified second.
        /// </summary>
        /// <param name="FiltredMessages"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        static List<List<object>> AircraftsPerSecond(List<List<object>> FiltredMessages, int second)
        {
            List<List<object>> aircraftsSecond = new List<List<object>>();
            foreach (List<object> aircraft in FiltredMessages)
            {
                int timeAircraft = Convert.ToInt32(aircraft[0]);

                if (timeAircraft == second)
                {
                    aircraftsSecond.Add(aircraft);  
                }
            }
            return aircraftsSecond;
        }

        /// <summary>
        /// Method to draw airplanes on the map.
        /// </summary>
        /// <param name="aircrafts"></param>
        private void PaintAircrafts(List<List<object>> aircrafts)
        {
            foreach (List<object> aircraft in aircrafts)
            {
                double latitude = Convert.ToDouble(aircraft[1]);
                double longitude = Convert.ToDouble(aircraft[2]);
                string Altitude_corrected = Convert.ToString(aircraft[3]);
                string TA = Convert.ToString(aircraft[6]);
                string TI = Convert.ToString(aircraft[8]);

                PointLatLng Position = new PointLatLng(latitude, longitude);

                if (!string.IsNullOrEmpty(TA))
                {
                    if (aircraftMarkers.ContainsKey(TA))
                    {
                        markersOverlay.Markers.Remove(aircraftMarkers[TA]);
                    }

                    double angleGRAD = 0;

                    if (previousPositions.ContainsKey(TA))
                    {
                        PointLatLng previousPosition = previousPositions[TA];

                        DrawLine(previousPosition, Position);

                        double AY = Position.Lat - previousPosition.Lat;
                        double AX = Position.Lng - previousPosition.Lng;
                        double angleRAD = Math.Atan(AY / AX);
                        angleGRAD = angleRAD * 180 / Math.PI;

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
                            bitmap = new Bitmap("plane60.png");   

                            if (angleGRAD > 0 && angleGRAD <= 45)
                            {
                                //north-east 
                            }
                            else if (angleGRAD > 90 && angleGRAD <= 135)
                            {
                                bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone); 
                            }
                            else if (angleGRAD <= -45 && angleGRAD > -90)
                            {
                                bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            }
                            else if (angleGRAD <= 225 && angleGRAD > 180)
                            {
                                bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone); 
                            }
                        }

                        else if ((angleGRAD > 45 && angleGRAD < 90) || (angleGRAD > 135 && angleGRAD < 180) || (angleGRAD > -45 && angleGRAD < 0) || (angleGRAD > 225 && angleGRAD < 270))
                        {
                            bitmap = new Bitmap("plane30.png");  

                            if (angleGRAD > 45 && angleGRAD < 90)
                            {
                                //north-east 
                            }
                            else if (angleGRAD > 135 && angleGRAD < 180)
                            {
                                bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone); 
                            }
                            else if (angleGRAD < 0 && angleGRAD > -45)
                            {
                                bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            }
                            else if (angleGRAD < 270 && angleGRAD > 225)
                            {
                                bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone); 
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

                    int newWidth = bitmap.Width / 30;
                    int newHeight = bitmap.Height / 30;
                    Bitmap resizedBitmap = new Bitmap(bitmap, new Size(newWidth, newHeight));

                    int offsetX = resizedBitmap.Width / 2;
                    int offsetY = resizedBitmap.Height / 2;

                    GMarkerGoogle marker = new GMarkerGoogle(Position, resizedBitmap);

                    marker.Offset = new Point(-offsetX, -offsetY);

                    marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
                    marker.ToolTipText = $"Target identification: {TI}\nTarget address: {TA}\nLatitude (°): {latitude}\nLongitude (°): {longitude}\nCorrected Altitude (m): {Altitude_corrected}";

                    markersOverlay.Markers.Add(marker);

                    aircraftMarkers[TA] = marker;

                    previousPositions[TA] = Position;

                }
            }
            mapControl.Invalidate();
        }

        /// <summary>
        /// Draws a red line between two points (start and end) on the map and refreshes the map control to display the route.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void DrawLine(PointLatLng start, PointLatLng end)
        {
            var route = new GMapRoute(new List<PointLatLng> { start, end }, "MyRoute");
            route.Stroke = new Pen(Color.Red, 2);

            routeOverlay.Routes.Add(route);

            mapControl.Refresh();
        }


        /// <summary>
        /// Changes the map provider based on the selected option from a combo box (Google Maps, Bing Maps, OpenStreetMap, etc.) and refreshes the map control to reflect the new map provider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeMapBtn_Click(object sender, EventArgs e)
        {
            string selectedMapType = comboBox1.SelectedItem.ToString();

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
            mapControl.Refresh();
        }

        /// <summary>
        /// Changes the form’s background based on the selected theme.
        /// </summary>
        private void ApplyTheme()
        {
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

        /// <summary>
        /// Clears markers, routes, and data, then re-initializes the simulation with filtered messages. It calculates the distance if extra is true and updates the UI accordingly.
        /// </summary>
        private void RestartSimulation()
        {
            markersOverlay.Markers.Clear();
            routeOverlay.Routes.Clear();

            aircraftMarkers.Clear();
            previousPositions.Clear();
            dataGridView1.Rows.Clear();

            try
            {
                currentSecond = Convert.ToInt32(FiltredMessages[0][0]);

                List<List<object>> initialAircrafts = new List<List<object>>();

                for (int i = 0; i < 4; i++)
                {
                    List<List<object>> result = AircraftsPerSecond(FiltredMessages, currentSecond + i);

                    PaintAircrafts(result);
                    initialAircrafts.AddRange(result);
                }
                UpdateDataGridView(initialAircrafts);
                UpdateTime(initialAircrafts);

                mapControl.Refresh();

                trackBar1.Value = 1; 

                simulationTimer.Interval = 1000;

                if (AutomaticBtn.Text == "Pause")
                {
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
            }
        }

        /// <summary>
        /// Triggers the RestartSimulation method when the restart button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartBtn_Click(object sender, EventArgs e)
        {
            RestartSimulation();
        }

        /// <summary>
        /// Toggles between "Automatic" and "Pause" states, starting or stopping the simulation timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutomaticBtn_Click(object sender, EventArgs e)
        {
            if (AutomaticBtn.Text == "Automatic")
            {
                simulationTimer.Start();
                AutomaticBtn.Text = "Pause";
            }
            else if (AutomaticBtn.Text == "Pause")
            {
                simulationTimer.Stop();
                AutomaticBtn.Text = "Automatic";
            }

        }

        /// <summary>
        /// Executes the MoveBtn_Click method each time the simulation timer ticks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimulationTimer_Tick(object sender, EventArgs e)
        {
            MoveBtn_Click(null, null);
        }

        /// <summary>
        /// Adjusts the simulation timer interval based on the trackbar value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int trackBarValue = trackBar1.Value;

            int minInterval = 1000; 
            int maxInterval = 1; 

            simulationTimer.Interval = minInterval - (trackBarValue - 1) * (minInterval - maxInterval) / (trackBar1.Maximum - 1);
        }

        /// <summary>
        /// Applies a filter to AllMessages based on the selected option from comboBox2, updates the FiltredMessages, and restarts the simulation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            string selection = comboBox2.SelectedItem.ToString();
            List<List<object>> updatedFilteredMessages = new List<List<object>>();

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

            FiltredMessages = updatedFilteredMessages;

            extra = false;
            label4.Text = "";

            if (FiltredMessages != null)
            {
                RestartSimulation();
            }

        }

        /// <summary>
        /// Exports filtered data to a CSV file, checking for the presence of specific filtered messages.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void exportCsvBtn_Click(object sender, EventArgs e)
        {
            string rutaCSV = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ASTERIX.csv");

            if (!File.Exists(rutaCSV))
            {
                MessageBox.Show("The CSV file was not found.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Save Filtered CSV File",
                FileName = "FilteredASTERIX.csv" 
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return; 
            }

            string newCsvPath = saveFileDialog.FileName;

            HashSet<string> filteredKeys = new HashSet<string>(
                FiltredMessages.Select(msg => $"{msg[0]}|{msg[1]}|{msg[2]}|{msg[3]}|{msg[4]}|{msg[5]}|{msg[6]}"));

            var filteredLines = new List<string>();
            using (StreamReader reader = new StreamReader(rutaCSV))
            {
                string header = reader.ReadLine();
                filteredLines.Add(header); 

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] row = line.Split('\t').Select(e => e.Trim('\"')).ToArray();
                    string key = $"{row[4]}|{row[5]}|{row[6]}|{row[77]}|{row[8]}|{row[23]}|{row[35]}";

                    if (filteredKeys.Contains(key))
                    {
                        filteredLines.Add(line);
                    }
                }
            }
            File.WriteAllLines(newCsvPath, filteredLines, Encoding.UTF8);
            MessageBox.Show("Filtered CSV exported successfully.");

        }

        private void extraFunctionalityBtn_Click(object sender, EventArgs e)
        {

            ExtraFunctionality extraFunctionality = new ExtraFunctionality(this);
            this.Enabled = false;
            extraFunctionality.Show();

        }

        /// <summary>
        /// Filters messages based on two target identifiers (TI1 and TI2) and returns the filtered messages and any missing targets.
        /// </summary>
        /// <param name="allMessages"></param>
        /// <param name="TI1"></param>
        /// <param name="TI2"></param>
        /// <returns></returns>
        public (List<List<object>> filtredMessages, List<string> missingTargets) Option8(List<List<object>> allMessages, string TI1, string TI2)
        {
            List<List<object>> filtredMessages = new List<List<object>>();
            List<string> missingTargets = new List<string>();

            bool ti1Found = false;
            bool ti2Found = false;

            foreach (var message in allMessages)
            {

                string TI = Convert.ToString(message[8]);

                if (TI == TI1)
                {
                    ti1Found = true;
                    filtredMessages.Add(message);
                }
                if (TI == TI2)
                {
                    ti2Found = true;
                    filtredMessages.Add(message);
                }

            }

            if (!ti1Found)
                missingTargets.Add(TI1);
            if (!ti2Found)
                missingTargets.Add(TI2);

            return (filtredMessages, missingTargets);

        }

        /// <summary>
        /// Calculates the distance between airplanes every second (from the first second of filtered messages to the last).
        /// </summary>
        /// <param name="FiltredMessages"></param>
        /// <param name="TI1"></param>
        /// <param name="TI2"></param>
        /// <returns></returns>
        public Dictionary<int, double> CalculateDistanceForAircrafts(List<List<object>> FiltredMessages, string TI1, string TI2)
        {
            Dictionary<string, PointLatLng> previousPositions = new Dictionary<string, PointLatLng>(); 
            Dictionary<int, double> distancesBySecond = new Dictionary<int, double>(); 


            int sec = Convert.ToInt32(FiltredMessages.First()[0]);
            int maxsec = Convert.ToInt32(FiltredMessages.Last()[0]);

            for (int i = sec; i <= maxsec; i++)
            {
                List<List<object>> aircraftsInCurrentSecond = AircraftsPerSecond(FiltredMessages, i);

                foreach (var message in aircraftsInCurrentSecond)
                {
                    string TI = Convert.ToString(message[8]);
                    double latitude = Convert.ToDouble(message[1]);
                    double longitude = Convert.ToDouble(message[2]);

                    if (TI == TI1 || TI == TI2)
                    {
                        PointLatLng positionTI1 = default;
                        PointLatLng positionTI2 = default;
                        PointLatLng stereographicPositionTI1;
                        PointLatLng stereographicPositionTI2;

                        if (TI == TI1)
                        {
                            positionTI1 = new PointLatLng(latitude, longitude);
                        }
                        else if (TI == TI2)
                        {
                            positionTI2 = new PointLatLng(latitude, longitude);

                        }

                        if (positionTI1.Lat == 0 && previousPositions.ContainsKey(TI1))
                            positionTI1 = previousPositions[TI1];
                        if (positionTI2.Lat == 0 && previousPositions.ContainsKey(TI2))
                            positionTI2 = previousPositions[TI2];

                        if (positionTI1.Lat != 0 && positionTI2.Lat != 0)
                        {
                            stereographicPositionTI1 = GetStereographic(positionTI1);
                            stereographicPositionTI2 = GetStereographic(positionTI2);
                            double distance = CalculateDistance(stereographicPositionTI1, stereographicPositionTI2);
                            distancesBySecond[i] = distance; 

                        }
                        else
                        {
                            distancesBySecond[i] = 0;

                        }

                        if (positionTI1.Lat != 0)
                            previousPositions[TI1] = positionTI1;
                        if (positionTI2.Lat != 0)
                            previousPositions[TI2] = positionTI2;
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

        /// <summary>
        /// Updates the FiltredMessages and restarts the simulation.
        /// </summary>
        /// <param name="filtredMessages"></param>
        public void SetTargetAddresses(List<List<object>> filtredMessages)
        {

            FiltredMessages = filtredMessages;
            RestartSimulation();

        }

        /// <summary>
        /// Converts a geographical position (latitude, longitude) into stereographic coordinates using a specific projection center.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
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

            return new PointLatLng(Coordinates_ster.U, Coordinates_ster.V);
        }

        /// <summary>
        /// Calculates the distance (in nautical miles) between two stereographic positions.
        /// </summary>
        /// <param name="stereographicPositionTI1"></param>
        /// <param name="stereographicPositionTI2"></param>
        /// <returns></returns>
        public double CalculateDistance(PointLatLng stereographicPositionTI1, PointLatLng stereographicPositionTI2)
        {
            double distance;
            double dU = stereographicPositionTI1.Lat - stereographicPositionTI2.Lat;
            double dV = stereographicPositionTI1.Lng - stereographicPositionTI2.Lng;
            distance = Math.Sqrt(dV * dV + dU * dU);
            distance = (distance / 1852.0);
            return distance;
        }

    }
}
