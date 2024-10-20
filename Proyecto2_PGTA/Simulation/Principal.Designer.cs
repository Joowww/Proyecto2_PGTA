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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            pictureBox1 = new PictureBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            SimulateBtn = new Button();
            pictureBox7 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(-3, -2);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1066, 406);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(362, 298);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(222, 28);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(334, 275);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(288, 20);
            label1.TabIndex = 2;
            label1.Text = "How would you like to import the csv file?";
            // 
            // SimulateBtn
            // 
            SimulateBtn.Location = new Point(625, 296);
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
            pictureBox7.Location = new Point(846, 361);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(216, 44);
            pictureBox7.TabIndex = 10;
            pictureBox7.TabStop = false;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 402);
            Controls.Add(pictureBox7);
            Controls.Add(SimulateBtn);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "Principal";
            Text = "Principal";
            Load += Form_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox comboBox1;
        private Label label1;
        private Button SimulateBtn;
        private PictureBox pictureBox7;
    }
}