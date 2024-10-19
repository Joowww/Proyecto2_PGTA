namespace Simulation
{
    partial class Welcome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            button1 = new Button();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox7 = new PictureBox();
            sidebar = new FlowLayoutPanel();
            panel1 = new Panel();
            label1 = new Label();
            menuButton = new PictureBox();
            panel2 = new Panel();
            button2 = new Button();
            AboutUsContainer = new Panel();
            panel8 = new Panel();
            buttonContactUs = new Button();
            panel7 = new Panel();
            buttonGroup = new Button();
            panel3 = new Panel();
            buttonAboutUs = new Button();
            SettingsContainer = new Panel();
            panel11 = new Panel();
            button9 = new Button();
            panel10 = new Panel();
            button3 = new Button();
            panel4 = new Panel();
            buttonSettings = new Button();
            HelpContainer = new Panel();
            panel13 = new Panel();
            buttonQRVideoT = new Button();
            panel12 = new Panel();
            buttonTutorial = new Button();
            panel5 = new Panel();
            buttonHelp = new Button();
            panel6 = new Panel();
            buttonPPolicy = new Button();
            SidebarTimer = new System.Windows.Forms.Timer(components);
            AboutUsTimer = new System.Windows.Forms.Timer(components);
            SettingsTimer = new System.Windows.Forms.Timer(components);
            HelpTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            sidebar.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)menuButton).BeginInit();
            panel2.SuspendLayout();
            AboutUsContainer.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            SettingsContainer.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            panel4.SuspendLayout();
            HelpContainer.SuspendLayout();
            panel13.SuspendLayout();
            panel12.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(465, 359);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(281, 46);
            button1.TabIndex = 1;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += StartBtn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Center;
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(465, 161);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(188, 51);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(465, 218);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(281, 51);
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(465, 275);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(281, 45);
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImage = (Image)resources.GetObject("pictureBox5.BackgroundImage");
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Location = new Point(665, 300);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(50, 19);
            pictureBox5.TabIndex = 7;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackgroundImage = (Image)resources.GetObject("pictureBox6.BackgroundImage");
            pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Location = new Point(653, 276);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(81, 21);
            pictureBox6.TabIndex = 8;
            pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Center;
            pictureBox7.Location = new Point(853, 606);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(216, 44);
            pictureBox7.TabIndex = 9;
            pictureBox7.TabStop = false;
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(35, 40, 45);
            sidebar.Controls.Add(panel1);
            sidebar.Controls.Add(panel2);
            sidebar.Controls.Add(AboutUsContainer);
            sidebar.Controls.Add(SettingsContainer);
            sidebar.Controls.Add(HelpContainer);
            sidebar.Controls.Add(panel6);
            sidebar.Dock = DockStyle.Left;
            sidebar.Location = new Point(0, 0);
            sidebar.MaximumSize = new Size(250, 650);
            sidebar.MinimumSize = new Size(103, 650);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(103, 650);
            sidebar.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(menuButton);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 141);
            panel1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(115, 60);
            label1.Name = "label1";
            label1.Size = new Size(65, 28);
            label1.TabIndex = 11;
            label1.Text = "Menu";
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
            panel2.Controls.Add(button2);
            panel2.Location = new Point(3, 150);
            panel2.Name = "panel2";
            panel2.Size = new Size(272, 60);
            panel2.TabIndex = 12;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.Dock = DockStyle.Left;
            button2.FlatAppearance.BorderColor = Color.FromArgb(35, 40, 45);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Padding = new Padding(5, 0, 0, 0);
            button2.Size = new Size(247, 60);
            button2.TabIndex = 11;
            button2.Text = "                Home";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            // 
            // AboutUsContainer
            // 
            AboutUsContainer.BackColor = Color.FromArgb(50, 55, 60);
            AboutUsContainer.Controls.Add(panel8);
            AboutUsContainer.Controls.Add(panel7);
            AboutUsContainer.Controls.Add(panel3);
            AboutUsContainer.Location = new Point(3, 216);
            AboutUsContainer.MaximumSize = new Size(296, 156);
            AboutUsContainer.MinimumSize = new Size(272, 60);
            AboutUsContainer.Name = "AboutUsContainer";
            AboutUsContainer.Size = new Size(296, 60);
            AboutUsContainer.TabIndex = 11;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(50, 55, 60);
            panel8.Controls.Add(buttonContactUs);
            panel8.Location = new Point(0, 108);
            panel8.Name = "panel8";
            panel8.Size = new Size(272, 48);
            panel8.TabIndex = 15;
            // 
            // buttonContactUs
            // 
            buttonContactUs.BackColor = Color.Transparent;
            buttonContactUs.Dock = DockStyle.Left;
            buttonContactUs.FlatAppearance.BorderColor = Color.FromArgb(35, 40, 45);
            buttonContactUs.FlatStyle = FlatStyle.Flat;
            buttonContactUs.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonContactUs.ForeColor = Color.White;
            buttonContactUs.Image = (Image)resources.GetObject("buttonContactUs.Image");
            buttonContactUs.ImageAlign = ContentAlignment.MiddleLeft;
            buttonContactUs.Location = new Point(0, 0);
            buttonContactUs.Name = "buttonContactUs";
            buttonContactUs.Padding = new Padding(5, 0, 0, 0);
            buttonContactUs.Size = new Size(272, 48);
            buttonContactUs.TabIndex = 11;
            buttonContactUs.Text = "                Contact us";
            buttonContactUs.TextAlign = ContentAlignment.MiddleLeft;
            buttonContactUs.UseVisualStyleBackColor = false;
            buttonContactUs.Click += buttonContactUs_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(50, 55, 60);
            panel7.Controls.Add(buttonGroup);
            panel7.Location = new Point(0, 60);
            panel7.Name = "panel7";
            panel7.Size = new Size(272, 48);
            panel7.TabIndex = 14;
            // 
            // buttonGroup
            // 
            buttonGroup.BackColor = Color.Transparent;
            buttonGroup.Dock = DockStyle.Left;
            buttonGroup.FlatAppearance.BorderColor = Color.FromArgb(35, 40, 45);
            buttonGroup.FlatStyle = FlatStyle.Flat;
            buttonGroup.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonGroup.ForeColor = Color.White;
            buttonGroup.Image = (Image)resources.GetObject("buttonGroup.Image");
            buttonGroup.ImageAlign = ContentAlignment.MiddleLeft;
            buttonGroup.Location = new Point(0, 0);
            buttonGroup.Name = "buttonGroup";
            buttonGroup.Padding = new Padding(5, 0, 0, 0);
            buttonGroup.Size = new Size(272, 48);
            buttonGroup.TabIndex = 11;
            buttonGroup.Text = "                Group 9";
            buttonGroup.TextAlign = ContentAlignment.MiddleLeft;
            buttonGroup.UseVisualStyleBackColor = false;
            buttonGroup.Click += buttonGroup_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(35, 40, 45);
            panel3.Controls.Add(buttonAboutUs);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(272, 60);
            panel3.TabIndex = 13;
            // 
            // buttonAboutUs
            // 
            buttonAboutUs.BackColor = Color.Transparent;
            buttonAboutUs.Dock = DockStyle.Left;
            buttonAboutUs.FlatAppearance.BorderColor = Color.FromArgb(35, 40, 45);
            buttonAboutUs.FlatStyle = FlatStyle.Flat;
            buttonAboutUs.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAboutUs.ForeColor = Color.Transparent;
            buttonAboutUs.Image = (Image)resources.GetObject("buttonAboutUs.Image");
            buttonAboutUs.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAboutUs.Location = new Point(0, 0);
            buttonAboutUs.Name = "buttonAboutUs";
            buttonAboutUs.Padding = new Padding(5, 0, 0, 0);
            buttonAboutUs.Size = new Size(247, 60);
            buttonAboutUs.TabIndex = 11;
            buttonAboutUs.Text = "                About us";
            buttonAboutUs.TextAlign = ContentAlignment.MiddleLeft;
            buttonAboutUs.UseVisualStyleBackColor = false;
            buttonAboutUs.Click += buttonAboutUs_Click;
            // 
            // SettingsContainer
            // 
            SettingsContainer.BackColor = Color.FromArgb(35, 40, 45);
            SettingsContainer.Controls.Add(panel11);
            SettingsContainer.Controls.Add(panel10);
            SettingsContainer.Controls.Add(panel4);
            SettingsContainer.Location = new Point(3, 282);
            SettingsContainer.MaximumSize = new Size(272, 156);
            SettingsContainer.MinimumSize = new Size(272, 60);
            SettingsContainer.Name = "SettingsContainer";
            SettingsContainer.Size = new Size(272, 60);
            SettingsContainer.TabIndex = 17;
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(50, 55, 60);
            panel11.Controls.Add(button9);
            panel11.Location = new Point(0, 105);
            panel11.Name = "panel11";
            panel11.Size = new Size(272, 48);
            panel11.TabIndex = 16;
            // 
            // button9
            // 
            button9.BackColor = Color.Transparent;
            button9.Dock = DockStyle.Left;
            button9.FlatAppearance.BorderColor = Color.FromArgb(35, 40, 45);
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button9.ForeColor = Color.White;
            button9.Image = (Image)resources.GetObject("button9.Image");
            button9.ImageAlign = ContentAlignment.MiddleLeft;
            button9.Location = new Point(0, 0);
            button9.Name = "button9";
            button9.Padding = new Padding(5, 0, 0, 0);
            button9.Size = new Size(270, 48);
            button9.TabIndex = 11;
            button9.Text = "                Language";
            button9.TextAlign = ContentAlignment.MiddleLeft;
            button9.UseVisualStyleBackColor = false;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(50, 55, 60);
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
            button3.FlatAppearance.BorderColor = Color.FromArgb(35, 40, 45);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(0, 0);
            button3.Name = "button3";
            button3.Padding = new Padding(5, 0, 0, 0);
            button3.Size = new Size(271, 48);
            button3.TabIndex = 11;
            button3.Text = "                Forms colour";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(buttonSettings);
            panel4.Location = new Point(1, 1);
            panel4.Name = "panel4";
            panel4.Size = new Size(272, 60);
            panel4.TabIndex = 14;
            // 
            // buttonSettings
            // 
            buttonSettings.BackColor = Color.Transparent;
            buttonSettings.Dock = DockStyle.Left;
            buttonSettings.FlatAppearance.BorderColor = Color.FromArgb(35, 40, 45);
            buttonSettings.FlatStyle = FlatStyle.Flat;
            buttonSettings.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSettings.ForeColor = Color.White;
            buttonSettings.Image = (Image)resources.GetObject("buttonSettings.Image");
            buttonSettings.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSettings.Location = new Point(0, 0);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Padding = new Padding(5, 0, 0, 0);
            buttonSettings.Size = new Size(243, 60);
            buttonSettings.TabIndex = 11;
            buttonSettings.Text = "                Settings";
            buttonSettings.TextAlign = ContentAlignment.MiddleLeft;
            buttonSettings.UseVisualStyleBackColor = false;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // HelpContainer
            // 
            HelpContainer.BackColor = Color.FromArgb(35, 40, 45);
            HelpContainer.Controls.Add(panel13);
            HelpContainer.Controls.Add(panel12);
            HelpContainer.Controls.Add(panel5);
            HelpContainer.Location = new Point(3, 348);
            HelpContainer.MaximumSize = new Size(272, 157);
            HelpContainer.MinimumSize = new Size(272, 60);
            HelpContainer.Name = "HelpContainer";
            HelpContainer.Size = new Size(272, 60);
            HelpContainer.TabIndex = 17;
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(50, 55, 60);
            panel13.Controls.Add(buttonQRVideoT);
            panel13.Location = new Point(0, 108);
            panel13.Name = "panel13";
            panel13.Size = new Size(272, 48);
            panel13.TabIndex = 17;
            // 
            // buttonQRVideoT
            // 
            buttonQRVideoT.BackColor = Color.Transparent;
            buttonQRVideoT.Dock = DockStyle.Left;
            buttonQRVideoT.FlatAppearance.BorderColor = Color.FromArgb(35, 40, 45);
            buttonQRVideoT.FlatStyle = FlatStyle.Flat;
            buttonQRVideoT.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonQRVideoT.ForeColor = Color.White;
            buttonQRVideoT.Image = (Image)resources.GetObject("buttonQRVideoT.Image");
            buttonQRVideoT.ImageAlign = ContentAlignment.MiddleLeft;
            buttonQRVideoT.Location = new Point(0, 0);
            buttonQRVideoT.Name = "buttonQRVideoT";
            buttonQRVideoT.Padding = new Padding(5, 0, 0, 0);
            buttonQRVideoT.Size = new Size(247, 48);
            buttonQRVideoT.TabIndex = 11;
            buttonQRVideoT.Text = "                Videotutorial";
            buttonQRVideoT.TextAlign = ContentAlignment.MiddleLeft;
            buttonQRVideoT.UseVisualStyleBackColor = false;
            buttonQRVideoT.Click += buttonQRVideoT_Click;
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
            panel5.Controls.Add(buttonHelp);
            panel5.Location = new Point(2, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(272, 60);
            panel5.TabIndex = 15;
            // 
            // buttonHelp
            // 
            buttonHelp.BackColor = Color.Transparent;
            buttonHelp.Dock = DockStyle.Left;
            buttonHelp.FlatAppearance.BorderColor = Color.FromArgb(35, 40, 45);
            buttonHelp.FlatStyle = FlatStyle.Flat;
            buttonHelp.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonHelp.ForeColor = Color.White;
            buttonHelp.Image = (Image)resources.GetObject("buttonHelp.Image");
            buttonHelp.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHelp.Location = new Point(0, 0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new Padding(5, 0, 0, 0);
            buttonHelp.Size = new Size(247, 60);
            buttonHelp.TabIndex = 11;
            buttonHelp.Text = "                Help";
            buttonHelp.TextAlign = ContentAlignment.MiddleLeft;
            buttonHelp.UseVisualStyleBackColor = false;
            buttonHelp.Click += buttonHelp_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(buttonPPolicy);
            panel6.Location = new Point(3, 414);
            panel6.Name = "panel6";
            panel6.Size = new Size(272, 60);
            panel6.TabIndex = 16;
            // 
            // buttonPPolicy
            // 
            buttonPPolicy.BackColor = Color.Transparent;
            buttonPPolicy.Dock = DockStyle.Left;
            buttonPPolicy.FlatAppearance.BorderColor = Color.FromArgb(35, 40, 45);
            buttonPPolicy.FlatStyle = FlatStyle.Flat;
            buttonPPolicy.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPPolicy.ForeColor = Color.White;
            buttonPPolicy.Image = (Image)resources.GetObject("buttonPPolicy.Image");
            buttonPPolicy.ImageAlign = ContentAlignment.MiddleLeft;
            buttonPPolicy.Location = new Point(0, 0);
            buttonPPolicy.Name = "buttonPPolicy";
            buttonPPolicy.Padding = new Padding(5, 0, 0, 0);
            buttonPPolicy.Size = new Size(247, 60);
            buttonPPolicy.TabIndex = 11;
            buttonPPolicy.Text = "                Privacy Policy";
            buttonPPolicy.TextAlign = ContentAlignment.MiddleLeft;
            buttonPPolicy.UseVisualStyleBackColor = false;
            buttonPPolicy.Click += buttonPPolicy_Click;
            // 
            // SidebarTimer
            // 
            SidebarTimer.Interval = 10;
            SidebarTimer.Tick += SidebarTimer_Tick;
            // 
            // AboutUsTimer
            // 
            AboutUsTimer.Interval = 10;
            AboutUsTimer.Tick += AboutUsTimer_Tick;
            // 
            // SettingsTimer
            // 
            SettingsTimer.Interval = 10;
            SettingsTimer.Tick += SettingsTimer_Tick;
            // 
            // HelpTimer
            // 
            HelpTimer.Interval = 10;
            HelpTimer.Tick += HelpTimer_Tick;
            // 
            // Welcome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1068, 650);
            Controls.Add(sidebar);
            Controls.Add(pictureBox7);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Welcome";
            Text = "Welcome";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            sidebar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)menuButton).EndInit();
            panel2.ResumeLayout(false);
            AboutUsContainer.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel3.ResumeLayout(false);
            SettingsContainer.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel4.ResumeLayout(false);
            HelpContainer.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private FlowLayoutPanel sidebar;
        private Panel panel1;
        private Panel panel2;
        private Button button2;
        private Label label1;
        private PictureBox menuButton;
        private Panel panel3;
        private Button buttonAboutUs;
        private Panel panel4;
        private Button buttonSettings;
        private Panel panel5;
        private Button buttonHelp;
        private Panel panel6;
        private Button buttonPPolicy;
        private System.Windows.Forms.Timer SidebarTimer;
        private Panel AboutUsContainer;
        private Panel panel8;
        private Button buttonContactUs;
        private Panel panel7;
        private Button buttonGroup;
        private System.Windows.Forms.Timer AboutUsTimer;
        private Panel SettingsContainer;
        private Panel panel11;
        private Button button9;
        private Panel panel10;
        private Button button3;
        private System.Windows.Forms.Timer SettingsTimer;
        private Panel HelpContainer;
        private Panel panel13;
        private Button buttonQRVideoT;
        private Panel panel12;
        private Button buttonTutorial;
        private System.Windows.Forms.Timer HelpTimer;
    }
}