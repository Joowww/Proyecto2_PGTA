namespace Simulation
{
    partial class Tutorial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tutorial));
            label1 = new Label();
            pictureBox7 = new PictureBox();
            buttonClose = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(30, 27);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(612, 28);
            label1.TabIndex = 0;
            label1.Text = "This application allows you to decode and simulate an Asterix file.";
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.Location = new Point(1308, 833);
            pictureBox7.Margin = new Padding(4);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(50, 50);
            pictureBox7.TabIndex = 10;
            pictureBox7.TabStop = false;
            // 
            // buttonClose
            // 
            buttonClose.FlatAppearance.BorderColor = Color.DarkGray;
            buttonClose.FlatAppearance.BorderSize = 3;
            buttonClose.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            buttonClose.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClose.Location = new Point(469, 797);
            buttonClose.Margin = new Padding(4);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(385, 70);
            buttonClose.TabIndex = 13;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(170, 177);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(234, 28);
            label2.TabIndex = 19;
            label2.Text = "file from your computer.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(170, 244);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(832, 28);
            label3.TabIndex = 20;
            label3.Text = "Next, you will be asked how you would like to import the data. You have several options: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(170, 96);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(958, 28);
            label4.TabIndex = 21;
            label4.Text = "Once you click the \"Start\" button, you will be prompted to upload an .ast file. You can choose between ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(170, 137);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(924, 28);
            label5.TabIndex = 22;
            label5.Text = "two available files (one with 1-hour data and another with 4-hour data), or you can upload a custom";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(170, 286);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(964, 28);
            label6.TabIndex = 23;
            label6.Text = "you can import all the data, select one of the pre-defined filter types, or choose a combination of filters.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(170, 328);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(957, 28);
            label7.TabIndex = 24;
            label7.Text = "If you need further assistance, you can always check the \"Help\" tab. If you selected the wrong file, tab. ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(170, 370);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(707, 28);
            label8.TabIndex = 25;
            label8.Text = "If you selected the wrong file, you can easily go back using the \"Home\" tab.";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(170, 443);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(944, 28);
            label9.TabIndex = 26;
            label9.Text = "After selecting your preferred options, click the \"Simulate\" button, configure the filters (if applicable), ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(170, 485);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(972, 28);
            label10.TabIndex = 27;
            label10.Text = "and within 4 seconds, a map with simulated aircraft will appear. You can choose to simulate step-by-step ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(170, 527);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(992, 28);
            label11.TabIndex = 28;
            label11.Text = "using the \"Move\" button, or run the simulation automatically. Additionally, you can increase the simulation ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(170, 569);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(995, 28);
            label12.TabIndex = 29;
            label12.Text = "speed using the scroll wheel or restart the simulation. You also have the option to switch the map provider ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(170, 611);
            label13.Name = "label13";
            label13.Size = new Size(810, 28);
            label13.TabIndex = 30;
            label13.Text = "and reapply filters as needed. Finally, you can export the simulation data in CSV format.";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(170, 685);
            label14.Name = "label14";
            label14.Size = new Size(980, 28);
            label14.TabIndex = 31;
            label14.Text = "Also, don't forget to explore the \"Extra Simulation\" button—a special feature of our project that promises ";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(170, 727);
            label15.Name = "label15";
            label15.Size = new Size(683, 28);
            label15.TabIndex = 32;
            label15.Text = "to enhance your experience. Give it a try, and you won’t be disappointed!";
            // 
            // Tutorial
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 896);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(buttonClose);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox7);
            Controls.Add(label1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Tutorial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tutorial";
            FormClosing += Tutorial_FormClosing;
            Load += Tutorial_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox7;
        private Button buttonClose;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
    }
}