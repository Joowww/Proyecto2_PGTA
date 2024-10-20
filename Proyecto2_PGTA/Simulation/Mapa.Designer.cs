namespace Simulation
{
    partial class Mapa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mapa));
            MoveBtn = new Button();
            AutomaticBtn = new Button();
            ReestartBtn = new Button();
            ChangeMapBtn = new Button();
            button5 = new Button();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            CloseBtn = new Button();
            trackBar1 = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // MoveBtn
            // 
            MoveBtn.Location = new Point(42, 68);
            MoveBtn.Margin = new Padding(2);
            MoveBtn.Name = "MoveBtn";
            MoveBtn.Size = new Size(90, 27);
            MoveBtn.TabIndex = 0;
            MoveBtn.Text = "Move";
            MoveBtn.UseVisualStyleBackColor = true;
            MoveBtn.Click += MoveBtn_Click;
            // 
            // AutomaticBtn
            // 
            AutomaticBtn.Location = new Point(42, 102);
            AutomaticBtn.Margin = new Padding(2);
            AutomaticBtn.Name = "AutomaticBtn";
            AutomaticBtn.Size = new Size(90, 27);
            AutomaticBtn.TabIndex = 1;
            AutomaticBtn.Text = "Automatic";
            AutomaticBtn.TextAlign = ContentAlignment.TopCenter;
            AutomaticBtn.UseVisualStyleBackColor = true;
            // 
            // ReestartBtn
            // 
            ReestartBtn.Location = new Point(42, 134);
            ReestartBtn.Margin = new Padding(2);
            ReestartBtn.Name = "ReestartBtn";
            ReestartBtn.Size = new Size(90, 27);
            ReestartBtn.TabIndex = 2;
            ReestartBtn.Text = "Reestart";
            ReestartBtn.UseVisualStyleBackColor = true;
            // 
            // ChangeMapBtn
            // 
            ChangeMapBtn.Location = new Point(218, 282);
            ChangeMapBtn.Margin = new Padding(2);
            ChangeMapBtn.Name = "ChangeMapBtn";
            ChangeMapBtn.Size = new Size(90, 27);
            ChangeMapBtn.TabIndex = 3;
            ChangeMapBtn.Text = "Accept";
            ChangeMapBtn.UseVisualStyleBackColor = true;
            ChangeMapBtn.Click += ChangeMapBtn_Click;
            // 
            // button5
            // 
            button5.Location = new Point(218, 347);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(90, 27);
            button5.TabIndex = 4;
            button5.Text = "Accept";
            button5.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(42, 282);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(173, 28);
            comboBox1.TabIndex = 5;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(42, 349);
            comboBox2.Margin = new Padding(2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(173, 28);
            comboBox2.TabIndex = 6;
            // 
            // CloseBtn
            // 
            CloseBtn.Location = new Point(996, 475);
            CloseBtn.Margin = new Padding(2);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new Size(90, 27);
            CloseBtn.TabIndex = 7;
            CloseBtn.Text = "Close";
            CloseBtn.UseVisualStyleBackColor = true;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(480, 439);
            trackBar1.Margin = new Padding(2);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(429, 56);
            trackBar1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(587, 402);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(253, 20);
            label1.TabIndex = 9;
            label1.Text = "Scroll to change simulation's velocity";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 259);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 10;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 326);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 11;
            label3.Text = "label3";
            // 
            // panel1
            // 
            panel1.Location = new Point(324, 30);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(762, 345);
            panel1.TabIndex = 12;
            // 
            // Mapa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1106, 526);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(trackBar1);
            Controls.Add(CloseBtn);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(button5);
            Controls.Add(ChangeMapBtn);
            Controls.Add(ReestartBtn);
            Controls.Add(AutomaticBtn);
            Controls.Add(MoveBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "Mapa";
            Text = "Mapa";
            Load += Mapa_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button MoveBtn;
        private Button AutomaticBtn;
        private Button ReestartBtn;
        private Button ChangeMapBtn;
        private Button button5;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button CloseBtn;
        private TrackBar trackBar1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel1;
    }
}