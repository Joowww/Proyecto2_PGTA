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
            pictureBox8 = new PictureBox();
            button2 = new Button();
            SettingsContainer = new Panel();
            panel11 = new Panel();
            button9 = new Button();
            panel10 = new Panel();
            button3 = new Button();
            panel4 = new Panel();
            pictureBox10 = new PictureBox();
            buttonSettings = new Button();
            HelpContainer = new Panel();
            panel12 = new Panel();
            buttonTutorial = new Button();
            panel5 = new Panel();
            pictureBox11 = new PictureBox();
            buttonHelp = new Button();
            HelpTimer = new System.Windows.Forms.Timer(components);
            SettingsTimer = new System.Windows.Forms.Timer(components);
            SidebarTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            sidebar.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)menuButton).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            SettingsContainer.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            HelpContainer.SuspendLayout();
            panel12.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(439, 221);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(222, 28);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(405, 150);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(288, 20);
            label1.TabIndex = 2;
            label1.Text = "How would you like to import the csv file?";
            // 
            // SimulateBtn
            // 
            SimulateBtn.Location = new Point(509, 281);
            SimulateBtn.Margin = new Padding(2);
            SimulateBtn.Name = "SimulateBtn";
            SimulateBtn.Size = new Size(90, 27);
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
            pictureBox7.Location = new Point(711, 425);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(216, 44);
            pictureBox7.TabIndex = 10;
            pictureBox7.TabStop = false;
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.DarkGray;
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
            menuButton.Cursor = Cursors.Hand;
            menuButton.InitialImage = (Image)resources.GetObject("menuButton.InitialImage");
            menuButton.Location = new Point(9, 40);
            menuButton.Name = "menuButton";
            menuButton.Size = new Size(75, 61);
            menuButton.TabIndex = 11;
            menuButton.TabStop = false;
            menuButton.Click += menuButton_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(pictureBox8);
            panel2.Controls.Add(button2);
            panel2.Location = new Point(6, 151);
            panel2.Margin = new Padding(6, 1, 6, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(237, 60);
            panel2.TabIndex = 12;
            // 
            // pictureBox8
            // 
            pictureBox8.BackgroundImage = (Image)resources.GetObject("pictureBox8.BackgroundImage");
            pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox8.Location = new Point(12, 0);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(80, 60);
            pictureBox8.TabIndex = 14;
            pictureBox8.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.Dock = DockStyle.Left;
            button2.FlatAppearance.BorderColor = Color.DarkGray;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Padding = new Padding(5, 0, 0, 0);
            button2.Size = new Size(237, 60);
            button2.TabIndex = 11;
            button2.Text = "                Home";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // SettingsContainer
            // 
            SettingsContainer.BackColor = Color.DarkGray;
            SettingsContainer.Controls.Add(panel11);
            SettingsContainer.Controls.Add(panel10);
            SettingsContainer.Controls.Add(panel4);
            SettingsContainer.Location = new Point(6, 215);
            SettingsContainer.Margin = new Padding(6, 2, 6, 2);
            SettingsContainer.MaximumSize = new Size(237, 156);
            SettingsContainer.MinimumSize = new Size(237, 59);
            SettingsContainer.Name = "SettingsContainer";
            SettingsContainer.Size = new Size(237, 59);
            SettingsContainer.TabIndex = 17;
            // 
            // panel11
            // 
            panel11.BackColor = Color.Gray;
            panel11.Controls.Add(button9);
            panel11.Location = new Point(0, 105);
            panel11.Name = "panel11";
            panel11.Size = new Size(272, 51);
            panel11.TabIndex = 16;
            // 
            // button9
            // 
            button9.BackColor = Color.Transparent;
            button9.Dock = DockStyle.Left;
            button9.FlatAppearance.BorderColor = Color.Gray;
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button9.ForeColor = Color.White;
            button9.Image = (Image)resources.GetObject("button9.Image");
            button9.ImageAlign = ContentAlignment.MiddleLeft;
            button9.Location = new Point(0, 0);
            button9.Name = "button9";
            button9.Padding = new Padding(5, 0, 0, 0);
            button9.Size = new Size(273, 51);
            button9.TabIndex = 11;
            button9.Text = "                Language";
            button9.TextAlign = ContentAlignment.MiddleLeft;
            button9.UseVisualStyleBackColor = false;
            // 
            // panel10
            // 
            panel10.BackColor = Color.Gray;
            panel10.Controls.Add(button3);
            panel10.Location = new Point(1, 59);
            panel10.Name = "panel10";
            panel10.Size = new Size(272, 48);
            panel10.TabIndex = 15;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.Dock = DockStyle.Left;
            button3.FlatAppearance.BorderColor = Color.Gray;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(0, 0);
            button3.Name = "button3";
            button3.Padding = new Padding(5, 0, 0, 0);
            button3.Size = new Size(269, 48);
            button3.TabIndex = 11;
            button3.Text = "                Forms colour";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.Controls.Add(pictureBox10);
            panel4.Controls.Add(buttonSettings);
            panel4.Location = new Point(1, 1);
            panel4.Margin = new Padding(6, 2, 6, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(236, 58);
            panel4.TabIndex = 14;
            // 
            // pictureBox10
            // 
            pictureBox10.BackgroundImage = (Image)resources.GetObject("pictureBox10.BackgroundImage");
            pictureBox10.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox10.Location = new Point(12, 0);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(80, 60);
            pictureBox10.TabIndex = 14;
            pictureBox10.TabStop = false;
            // 
            // buttonSettings
            // 
            buttonSettings.BackColor = Color.Transparent;
            buttonSettings.Dock = DockStyle.Left;
            buttonSettings.FlatAppearance.BorderColor = Color.DarkGray;
            buttonSettings.FlatAppearance.BorderSize = 0;
            buttonSettings.FlatStyle = FlatStyle.Flat;
            buttonSettings.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSettings.ForeColor = Color.White;
            buttonSettings.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSettings.Location = new Point(0, 0);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Padding = new Padding(5, 0, 0, 0);
            buttonSettings.Size = new Size(236, 58);
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
            HelpContainer.MaximumSize = new Size(237, 110);
            HelpContainer.MinimumSize = new Size(237, 60);
            HelpContainer.Name = "HelpContainer";
            HelpContainer.Size = new Size(237, 61);
            HelpContainer.TabIndex = 17;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(50, 55, 60);
            panel12.Controls.Add(buttonTutorial);
            panel12.Location = new Point(0, 62);
            panel12.Name = "panel12";
            panel12.Size = new Size(272, 48);
            panel12.TabIndex = 16;
            // 
            // buttonTutorial
            // 
            buttonTutorial.BackColor = Color.Transparent;
            buttonTutorial.Dock = DockStyle.Left;
            buttonTutorial.FlatAppearance.BorderColor = Color.FromArgb(35, 40, 45);
            buttonTutorial.FlatStyle = FlatStyle.Flat;
            buttonTutorial.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonTutorial.ForeColor = Color.White;
            buttonTutorial.Image = (Image)resources.GetObject("buttonTutorial.Image");
            buttonTutorial.ImageAlign = ContentAlignment.MiddleLeft;
            buttonTutorial.Location = new Point(0, 0);
            buttonTutorial.Name = "buttonTutorial";
            buttonTutorial.Padding = new Padding(5, 0, 0, 0);
            buttonTutorial.Size = new Size(247, 48);
            buttonTutorial.TabIndex = 11;
            buttonTutorial.Text = "                Tutorial";
            buttonTutorial.TextAlign = ContentAlignment.MiddleLeft;
            buttonTutorial.UseVisualStyleBackColor = false;
            buttonTutorial.Click += buttonTutorial_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.DarkGray;
            panel5.Controls.Add(pictureBox11);
            panel5.Controls.Add(buttonHelp);
            panel5.Location = new Point(2, 2);
            panel5.Margin = new Padding(6, 2, 6, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(235, 59);
            panel5.TabIndex = 15;
            // 
            // pictureBox11
            // 
            pictureBox11.BackgroundImage = (Image)resources.GetObject("pictureBox11.BackgroundImage");
            pictureBox11.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox11.Location = new Point(12, 0);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(80, 60);
            pictureBox11.TabIndex = 14;
            pictureBox11.TabStop = false;
            // 
            // buttonHelp
            // 
            buttonHelp.BackColor = Color.Transparent;
            buttonHelp.Dock = DockStyle.Left;
            buttonHelp.FlatAppearance.BorderColor = Color.DarkGray;
            buttonHelp.FlatAppearance.BorderSize = 0;
            buttonHelp.FlatStyle = FlatStyle.Flat;
            buttonHelp.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonHelp.ForeColor = Color.White;
            buttonHelp.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHelp.Location = new Point(0, 0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new Padding(5, 0, 0, 0);
            buttonHelp.Size = new Size(235, 59);
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
            Load += Form_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            sidebar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)menuButton).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            SettingsContainer.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            HelpContainer.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox comboBox1;
        private Label label1;
        private Button SimulateBtn;
        private PictureBox pictureBox7;
        private FlowLayoutPanel sidebar;
        private Panel panel1;
        private Label label2;
        private PictureBox menuButton;
        private Panel panel2;
        private Button button2;
        private Panel AboutUsContainer;
        private Panel panel8;
        private Button buttonContactUs;
        private Panel panel7;
        private Button buttonGroup;
        private Panel panel3;
        private Button buttonAboutUs;
        private Panel SettingsContainer;
        private Panel panel11;
        private Button button9;
        private Panel panel10;
        private Button button3;
        private Panel panel4;
        private Button buttonSettings;
        private Panel HelpContainer;
        private Panel panel13;
        private Button buttonQRVideoT;
        private Panel panel12;
        private Button buttonTutorial;
        private Panel panel5;
        private Button buttonHelp;
        private Panel panel6;
        private Button buttonPPolicy;
        private System.Windows.Forms.Timer HelpTimer;
        private System.Windows.Forms.Timer SettingsTimer;
        private System.Windows.Forms.Timer SidebarTimer;
        private PictureBox pictureBox8;
        private PictureBox pictureBox10;
        private PictureBox pictureBox11;
    }
}