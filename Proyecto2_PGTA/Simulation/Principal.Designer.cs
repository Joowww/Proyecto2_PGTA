namespace Simulation
{
    partial class Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            comboBox1 = new ComboBox();
            label1 = new Label();
            SimulateBtn = new Button();
            pictureBox7 = new PictureBox();
            sidebar = new FlowLayoutPanel();
            panel1 = new Panel();
            label2 = new Label();
            menuButton = new PictureBox();
            panel2 = new Panel();
            panel9 = new Panel();
            pictureBox5 = new PictureBox();
            HomeBtn = new Button();
            SettingsContainer = new Panel();
            panel11 = new Panel();
            panel15 = new Panel();
            pictureBox3 = new PictureBox();
            button9 = new Button();
            panel10 = new Panel();
            panel14 = new Panel();
            pictureBox8 = new PictureBox();
            button3 = new Button();
            panel4 = new Panel();
            panel13 = new Panel();
            pictureBox6 = new PictureBox();
            buttonSettings = new Button();
            HelpContainer = new Panel();
            panel12 = new Panel();
            panel18 = new Panel();
            pictureBox9 = new PictureBox();
            buttonTutorial = new Button();
            pictureBox17 = new PictureBox();
            panel5 = new Panel();
            panel17 = new Panel();
            pictureBox4 = new PictureBox();
            buttonHelp = new Button();
            HelpTimer = new System.Windows.Forms.Timer(components);
            SettingsTimer = new System.Windows.Forms.Timer(components);
            SidebarTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            sidebar.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)menuButton).BeginInit();
            panel2.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SettingsContainer.SuspendLayout();
            panel11.SuspendLayout();
            panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel10.SuspendLayout();
            panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            panel4.SuspendLayout();
            panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            HelpContainer.SuspendLayout();
            panel12.SuspendLayout();
            panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox17).BeginInit();
            panel5.SuspendLayout();
            panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(444, 194);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(222, 28);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(353, 127);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(400, 28);
            label1.TabIndex = 2;
            label1.Text = "How would you like to import the csv file?";
            // 
            // SimulateBtn
            // 
            SimulateBtn.FlatAppearance.BorderColor = Color.DarkGray;
            SimulateBtn.FlatAppearance.BorderSize = 3;
            SimulateBtn.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            SimulateBtn.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            SimulateBtn.FlatStyle = FlatStyle.Flat;
            SimulateBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SimulateBtn.Location = new Point(409, 274);
            SimulateBtn.Margin = new Padding(2);
            SimulateBtn.Name = "SimulateBtn";
            SimulateBtn.Size = new Size(280, 50);
            SimulateBtn.TabIndex = 4;
            SimulateBtn.Text = "Simulate";
            SimulateBtn.UseVisualStyleBackColor = true;
            SimulateBtn.Click += SimulateBtn_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Center;
            pictureBox7.Location = new Point(713, 428);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(216, 44);
            pictureBox7.TabIndex = 10;
            pictureBox7.TabStop = false;
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.Silver;
            sidebar.BorderStyle = BorderStyle.FixedSingle;
            sidebar.Controls.Add(panel1);
            sidebar.Controls.Add(panel2);
            sidebar.Controls.Add(SettingsContainer);
            sidebar.Controls.Add(HelpContainer);
            sidebar.Location = new Point(-1, -1);
            sidebar.MaximumSize = new Size(249, 650);
            sidebar.MinimumSize = new Size(108, 650);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(108, 650);
            sidebar.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(menuButton);
            panel1.Location = new Point(6, 6);
            panel1.Margin = new Padding(6, 6, 6, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(237, 141);
            panel1.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(115, 60);
            label2.Name = "label2";
            label2.Size = new Size(65, 28);
            label2.TabIndex = 11;
            label2.Text = "Menu";
            // 
            // menuButton
            // 
            menuButton.BackgroundImage = (Image)resources.GetObject("menuButton.BackgroundImage");
            menuButton.BackgroundImageLayout = ImageLayout.Stretch;
            menuButton.Cursor = Cursors.Hand;
            menuButton.InitialImage = (Image)resources.GetObject("menuButton.InitialImage");
            menuButton.Location = new Point(12, 40);
            menuButton.Name = "menuButton";
            menuButton.Size = new Size(75, 61);
            menuButton.TabIndex = 11;
            menuButton.TabStop = false;
            menuButton.Click += menuButton_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(panel9);
            panel2.Controls.Add(HomeBtn);
            panel2.Location = new Point(6, 151);
            panel2.Margin = new Padding(6, 1, 6, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(237, 60);
            panel2.TabIndex = 12;
            // 
            // panel9
            // 
            panel9.BackColor = Color.Transparent;
            panel9.Controls.Add(pictureBox5);
            panel9.Location = new Point(0, 0);
            panel9.Margin = new Padding(6, 1, 6, 2);
            panel9.Name = "panel9";
            panel9.Size = new Size(107, 60);
            panel9.TabIndex = 22;
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImage = (Image)resources.GetObject("pictureBox5.BackgroundImage");
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Location = new Point(15, 5);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(70, 50);
            pictureBox5.TabIndex = 13;
            pictureBox5.TabStop = false;
            // 
            // HomeBtn
            // 
            HomeBtn.BackColor = Color.Transparent;
            HomeBtn.Dock = DockStyle.Left;
            HomeBtn.FlatAppearance.BorderColor = Color.DarkGray;
            HomeBtn.FlatAppearance.BorderSize = 0;
            HomeBtn.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            HomeBtn.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            HomeBtn.FlatStyle = FlatStyle.Flat;
            HomeBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            HomeBtn.ForeColor = Color.White;
            HomeBtn.ImageAlign = ContentAlignment.MiddleLeft;
            HomeBtn.Location = new Point(0, 0);
            HomeBtn.Name = "HomeBtn";
            HomeBtn.Padding = new Padding(5, 0, 0, 0);
            HomeBtn.Size = new Size(237, 60);
            HomeBtn.TabIndex = 11;
            HomeBtn.Text = "                Home";
            HomeBtn.TextAlign = ContentAlignment.MiddleLeft;
            HomeBtn.UseVisualStyleBackColor = false;
            HomeBtn.Click += HomeBtn_Click;
            // 
            // SettingsContainer
            // 
            SettingsContainer.BackColor = Color.Silver;
            SettingsContainer.Controls.Add(panel11);
            SettingsContainer.Controls.Add(panel10);
            SettingsContainer.Controls.Add(panel4);
            SettingsContainer.Location = new Point(6, 215);
            SettingsContainer.Margin = new Padding(6, 2, 6, 2);
            SettingsContainer.MaximumSize = new Size(237, 152);
            SettingsContainer.MinimumSize = new Size(237, 59);
            SettingsContainer.Name = "SettingsContainer";
            SettingsContainer.Size = new Size(237, 59);
            SettingsContainer.TabIndex = 17;
            // 
            // panel11
            // 
            panel11.BackColor = Color.Gray;
            panel11.Controls.Add(panel15);
            panel11.Controls.Add(button9);
            panel11.Location = new Point(2, 106);
            panel11.Margin = new Padding(6, 0, 6, 0);
            panel11.MaximumSize = new Size(270, 45);
            panel11.Name = "panel11";
            panel11.Size = new Size(270, 45);
            panel11.TabIndex = 16;
            // 
            // panel15
            // 
            panel15.BackColor = Color.Transparent;
            panel15.Controls.Add(pictureBox3);
            panel15.Location = new Point(0, 2);
            panel15.Margin = new Padding(6, 1, 6, 2);
            panel15.Name = "panel15";
            panel15.Size = new Size(107, 40);
            panel15.TabIndex = 28;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(19, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(55, 35);
            pictureBox3.TabIndex = 13;
            pictureBox3.TabStop = false;
            // 
            // button9
            // 
            button9.BackColor = Color.Transparent;
            button9.Dock = DockStyle.Left;
            button9.FlatAppearance.BorderColor = Color.DarkGray;
            button9.FlatAppearance.BorderSize = 2;
            button9.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            button9.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button9.ForeColor = Color.White;
            button9.ImageAlign = ContentAlignment.MiddleLeft;
            button9.Location = new Point(0, 0);
            button9.Name = "button9";
            button9.Padding = new Padding(5, 0, 0, 0);
            button9.Size = new Size(235, 45);
            button9.TabIndex = 11;
            button9.Text = "                Language";
            button9.TextAlign = ContentAlignment.MiddleLeft;
            button9.UseVisualStyleBackColor = false;
            // 
            // panel10
            // 
            panel10.BackColor = Color.Gray;
            panel10.Controls.Add(panel14);
            panel10.Controls.Add(button3);
            panel10.Location = new Point(1, 59);
            panel10.Margin = new Padding(6, 0, 6, 2);
            panel10.MaximumSize = new Size(270, 45);
            panel10.Name = "panel10";
            panel10.Size = new Size(270, 45);
            panel10.TabIndex = 15;
            // 
            // panel14
            // 
            panel14.BackColor = Color.Transparent;
            panel14.Controls.Add(pictureBox8);
            panel14.Location = new Point(0, 2);
            panel14.Margin = new Padding(6, 1, 6, 2);
            panel14.Name = "panel14";
            panel14.Size = new Size(107, 40);
            panel14.TabIndex = 28;
            // 
            // pictureBox8
            // 
            pictureBox8.BackgroundImage = (Image)resources.GetObject("pictureBox8.BackgroundImage");
            pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox8.Location = new Point(19, 2);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(55, 35);
            pictureBox8.TabIndex = 13;
            pictureBox8.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.Dock = DockStyle.Left;
            button3.FlatAppearance.BorderColor = Color.DarkGray;
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            button3.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(0, 0);
            button3.Name = "button3";
            button3.Padding = new Padding(5, 0, 0, 0);
            button3.Size = new Size(241, 45);
            button3.TabIndex = 11;
            button3.Text = "                Forms colour";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.Controls.Add(panel13);
            panel4.Controls.Add(buttonSettings);
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(6, 2, 6, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(237, 59);
            panel4.TabIndex = 14;
            // 
            // panel13
            // 
            panel13.BackColor = Color.Transparent;
            panel13.Controls.Add(pictureBox6);
            panel13.Location = new Point(0, 0);
            panel13.Margin = new Padding(6, 1, 6, 2);
            panel13.Name = "panel13";
            panel13.Size = new Size(107, 60);
            panel13.TabIndex = 22;
            // 
            // pictureBox6
            // 
            pictureBox6.BackgroundImage = (Image)resources.GetObject("pictureBox6.BackgroundImage");
            pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Location = new Point(15, 5);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(70, 50);
            pictureBox6.TabIndex = 13;
            pictureBox6.TabStop = false;
            // 
            // buttonSettings
            // 
            buttonSettings.BackColor = Color.Transparent;
            buttonSettings.Dock = DockStyle.Left;
            buttonSettings.FlatAppearance.BorderColor = Color.DarkGray;
            buttonSettings.FlatAppearance.BorderSize = 0;
            buttonSettings.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            buttonSettings.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            buttonSettings.FlatStyle = FlatStyle.Flat;
            buttonSettings.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSettings.ForeColor = Color.White;
            buttonSettings.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSettings.Location = new Point(0, 0);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Padding = new Padding(5, 0, 0, 0);
            buttonSettings.Size = new Size(242, 59);
            buttonSettings.TabIndex = 11;
            buttonSettings.Text = "                Settings";
            buttonSettings.TextAlign = ContentAlignment.MiddleLeft;
            buttonSettings.UseVisualStyleBackColor = false;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // HelpContainer
            // 
            HelpContainer.BackColor = Color.Transparent;
            HelpContainer.Controls.Add(panel12);
            HelpContainer.Controls.Add(panel5);
            HelpContainer.Location = new Point(6, 278);
            HelpContainer.Margin = new Padding(6, 2, 6, 2);
            HelpContainer.MaximumSize = new Size(237, 107);
            HelpContainer.MinimumSize = new Size(237, 60);
            HelpContainer.Name = "HelpContainer";
            HelpContainer.Size = new Size(237, 60);
            HelpContainer.TabIndex = 17;
            // 
            // panel12
            // 
            panel12.BackColor = Color.Gray;
            panel12.Controls.Add(panel18);
            panel12.Controls.Add(buttonTutorial);
            panel12.Controls.Add(pictureBox17);
            panel12.Location = new Point(2, 60);
            panel12.Margin = new Padding(6, 0, 6, 0);
            panel12.MaximumSize = new Size(270, 45);
            panel12.Name = "panel12";
            panel12.Size = new Size(270, 45);
            panel12.TabIndex = 16;
            // 
            // panel18
            // 
            panel18.BackColor = Color.Transparent;
            panel18.Controls.Add(pictureBox9);
            panel18.Location = new Point(0, 2);
            panel18.Margin = new Padding(6, 1, 6, 2);
            panel18.Name = "panel18";
            panel18.Size = new Size(107, 40);
            panel18.TabIndex = 28;
            // 
            // pictureBox9
            // 
            pictureBox9.BackgroundImage = (Image)resources.GetObject("pictureBox9.BackgroundImage");
            pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox9.Location = new Point(19, 2);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(55, 35);
            pictureBox9.TabIndex = 13;
            pictureBox9.TabStop = false;
            // 
            // buttonTutorial
            // 
            buttonTutorial.BackColor = Color.Transparent;
            buttonTutorial.Dock = DockStyle.Left;
            buttonTutorial.FlatAppearance.BorderColor = Color.DarkGray;
            buttonTutorial.FlatAppearance.BorderSize = 2;
            buttonTutorial.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            buttonTutorial.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            buttonTutorial.FlatStyle = FlatStyle.Flat;
            buttonTutorial.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonTutorial.ForeColor = Color.White;
            buttonTutorial.ImageAlign = ContentAlignment.MiddleLeft;
            buttonTutorial.Location = new Point(0, 0);
            buttonTutorial.Name = "buttonTutorial";
            buttonTutorial.Padding = new Padding(5, 0, 0, 0);
            buttonTutorial.Size = new Size(235, 45);
            buttonTutorial.TabIndex = 11;
            buttonTutorial.Text = "                Tutorial";
            buttonTutorial.TextAlign = ContentAlignment.MiddleLeft;
            buttonTutorial.UseVisualStyleBackColor = false;
            buttonTutorial.Click += buttonTutorial_Click;
            // 
            // pictureBox17
            // 
            pictureBox17.BackgroundImage = (Image)resources.GetObject("pictureBox17.BackgroundImage");
            pictureBox17.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox17.Location = new Point(12, 3);
            pictureBox17.Name = "pictureBox17";
            pictureBox17.Size = new Size(45, 36);
            pictureBox17.TabIndex = 26;
            pictureBox17.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Transparent;
            panel5.Controls.Add(panel17);
            panel5.Controls.Add(buttonHelp);
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(6, 2, 6, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(237, 59);
            panel5.TabIndex = 15;
            // 
            // panel17
            // 
            panel17.BackColor = Color.Transparent;
            panel17.Controls.Add(pictureBox4);
            panel17.Location = new Point(0, 0);
            panel17.Margin = new Padding(6, 1, 6, 2);
            panel17.Name = "panel17";
            panel17.Size = new Size(107, 60);
            panel17.TabIndex = 22;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(15, 5);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(70, 50);
            pictureBox4.TabIndex = 13;
            pictureBox4.TabStop = false;
            // 
            // buttonHelp
            // 
            buttonHelp.BackColor = Color.Transparent;
            buttonHelp.Dock = DockStyle.Left;
            buttonHelp.FlatAppearance.BorderColor = Color.DarkGray;
            buttonHelp.FlatAppearance.BorderSize = 0;
            buttonHelp.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            buttonHelp.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            buttonHelp.FlatStyle = FlatStyle.Flat;
            buttonHelp.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonHelp.ForeColor = Color.White;
            buttonHelp.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHelp.Location = new Point(0, 0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new Padding(5, 0, 0, 0);
            buttonHelp.Size = new Size(237, 59);
            buttonHelp.TabIndex = 11;
            buttonHelp.Text = "                Help";
            buttonHelp.TextAlign = ContentAlignment.MiddleLeft;
            buttonHelp.UseVisualStyleBackColor = false;
            buttonHelp.Click += buttonHelp_Click;
            // 
            // HelpTimer
            // 
            HelpTimer.Interval = 10;
            HelpTimer.Tick += HelpTimer_Tick;
            // 
            // SettingsTimer
            // 
            SettingsTimer.Interval = 10;
            SettingsTimer.Tick += SettingsTimer_Tick;
            // 
            // SidebarTimer
            // 
            SidebarTimer.Interval = 10;
            SidebarTimer.Tick += SidebarTimer_Tick;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 469);
            Controls.Add(sidebar);
            Controls.Add(pictureBox7);
            Controls.Add(SimulateBtn);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "Principal";
            Text = "Principal";
            WindowState = FormWindowState.Maximized;
            Load += Form_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            sidebar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)menuButton).EndInit();
            panel2.ResumeLayout(false);
            panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            SettingsContainer.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel10.ResumeLayout(false);
            panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            panel4.ResumeLayout(false);
            panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            HelpContainer.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox17).EndInit();
            panel5.ResumeLayout(false);
            panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox1;
        private Label label1;
        private Button SimulateBtn;
        private PictureBox pictureBox7;
        private FlowLayoutPanel sidebar;
        private Panel panel1;
        private Label label2;
        private PictureBox menuButton;
        private Panel panel2;
        private Button HomeBtn;
        private Panel AboutUsContainer;
        private Button buttonContactUs;
        private Button buttonGroup;
        private Button buttonAboutUs;
        private Panel SettingsContainer;
        private Panel panel11;
        private Button button9;
        private Panel panel10;
        private Button button3;
        private Panel panel4;
        private Button buttonSettings;
        private Panel HelpContainer;
        private Panel panel12;
        private Button buttonTutorial;
        private Panel panel5;
        private Button buttonHelp;
        private Button buttonPPolicy;
        private System.Windows.Forms.Timer HelpTimer;
        private System.Windows.Forms.Timer SettingsTimer;
        private System.Windows.Forms.Timer SidebarTimer;
        private PictureBox pictureBox17;
        private Panel panel9;
        private PictureBox pictureBox5;
        private Panel panel15;
        private PictureBox pictureBox3;
        private Panel panel14;
        private PictureBox pictureBox8;
        private Panel panel13;
        private PictureBox pictureBox6;
        private Panel panel18;
        private PictureBox pictureBox9;
        private Panel panel17;
        private PictureBox pictureBox4;
    }
}