namespace Simulation
{
    partial class Bienvenida
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
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            aboutUsToolStripMenuItem = new ToolStripMenuItem();
            asterixDecoderToolStripMenuItem = new ToolStripMenuItem();
            usToolStripMenuItem = new ToolStripMenuItem();
            contactToolStripMenuItem = new ToolStripMenuItem();
            privacyPolicyToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            videoToolStripMenuItem = new ToolStripMenuItem();
            languageToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(359, 311);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(90, 27);
            button1.TabIndex = 1;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { aboutUsToolStripMenuItem, helpToolStripMenuItem, languageToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "About us";
            // 
            // aboutUsToolStripMenuItem
            // 
            aboutUsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { asterixDecoderToolStripMenuItem, usToolStripMenuItem, contactToolStripMenuItem, privacyPolicyToolStripMenuItem });
            aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            aboutUsToolStripMenuItem.Size = new Size(73, 24);
            aboutUsToolStripMenuItem.Text = "About...";
            // 
            // asterixDecoderToolStripMenuItem
            // 
            asterixDecoderToolStripMenuItem.Name = "asterixDecoderToolStripMenuItem";
            asterixDecoderToolStripMenuItem.Size = new Size(224, 26);
            asterixDecoderToolStripMenuItem.Text = "Asterix Decoder";
            // 
            // usToolStripMenuItem
            // 
            usToolStripMenuItem.Name = "usToolStripMenuItem";
            usToolStripMenuItem.Size = new Size(224, 26);
            usToolStripMenuItem.Text = "Creators";
            // 
            // contactToolStripMenuItem
            // 
            contactToolStripMenuItem.Name = "contactToolStripMenuItem";
            contactToolStripMenuItem.Size = new Size(224, 26);
            contactToolStripMenuItem.Text = "@ Contact";
            // 
            // privacyPolicyToolStripMenuItem
            // 
            privacyPolicyToolStripMenuItem.Name = "privacyPolicyToolStripMenuItem";
            privacyPolicyToolStripMenuItem.Size = new Size(224, 26);
            privacyPolicyToolStripMenuItem.Text = "Privacy policy";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { videoToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            // 
            // videoToolStripMenuItem
            // 
            videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            videoToolStripMenuItem.Size = new Size(224, 26);
            videoToolStripMenuItem.Text = "QR video";
            // 
            // languageToolStripMenuItem
            // 
            languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            languageToolStripMenuItem.Size = new Size(88, 24);
            languageToolStripMenuItem.Text = "Language";
            // 
            // Bienvenida
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Bienvenida";
            Text = "Bienvenida";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aboutUsToolStripMenuItem;
        private ToolStripMenuItem asterixDecoderToolStripMenuItem;
        private ToolStripMenuItem usToolStripMenuItem;
        private ToolStripMenuItem contactToolStripMenuItem;
        private ToolStripMenuItem privacyPolicyToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem videoToolStripMenuItem;
        private ToolStripMenuItem languageToolStripMenuItem;
    }
}