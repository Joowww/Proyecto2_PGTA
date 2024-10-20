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
            this.MoveBtn = new System.Windows.Forms.Button();
            this.AutomaticBtn = new System.Windows.Forms.Button();
            this.RestartBtn = new System.Windows.Forms.Button();
            this.ChangeMapBtn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // MoveBtn
            // 
            this.MoveBtn.Location = new System.Drawing.Point(52, 85);
            this.MoveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.MoveBtn.Name = "MoveBtn";
            this.MoveBtn.Size = new System.Drawing.Size(112, 34);
            this.MoveBtn.TabIndex = 0;
            this.MoveBtn.Text = "Move";
            this.MoveBtn.UseVisualStyleBackColor = true;
            this.MoveBtn.Click += new System.EventHandler(this.MoveBtn_Click);
            // 
            // AutomaticBtn
            // 
            this.AutomaticBtn.Location = new System.Drawing.Point(52, 128);
            this.AutomaticBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AutomaticBtn.Name = "AutomaticBtn";
            this.AutomaticBtn.Size = new System.Drawing.Size(112, 34);
            this.AutomaticBtn.TabIndex = 1;
            this.AutomaticBtn.Text = "Automatic";
            this.AutomaticBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AutomaticBtn.UseVisualStyleBackColor = true;
            // 
            // RestartBtn
            // 
            this.RestartBtn.Location = new System.Drawing.Point(52, 168);
            this.RestartBtn.Margin = new System.Windows.Forms.Padding(2);
            this.RestartBtn.Name = "RestartBtn";
            this.RestartBtn.Size = new System.Drawing.Size(112, 34);
            this.RestartBtn.TabIndex = 2;
            this.RestartBtn.Text = "Restart";
            this.RestartBtn.UseVisualStyleBackColor = true;
            this.RestartBtn.Click += new System.EventHandler(this.RestartBtn_Click);
            // 
            // ChangeMapBtn
            // 
            this.ChangeMapBtn.Location = new System.Drawing.Point(272, 352);
            this.ChangeMapBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ChangeMapBtn.Name = "ChangeMapBtn";
            this.ChangeMapBtn.Size = new System.Drawing.Size(112, 34);
            this.ChangeMapBtn.TabIndex = 3;
            this.ChangeMapBtn.Text = "Accept";
            this.ChangeMapBtn.UseVisualStyleBackColor = true;
            this.ChangeMapBtn.Click += new System.EventHandler(this.ChangeMapBtn_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(272, 434);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 34);
            this.button5.TabIndex = 4;
            this.button5.Text = "Accept";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(52, 352);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(215, 33);
            this.comboBox1.TabIndex = 5;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(52, 436);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(215, 33);
            this.comboBox2.TabIndex = 6;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(1245, 594);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(112, 34);
            this.CloseBtn.TabIndex = 7;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(600, 549);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(536, 69);
            this.trackBar1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(734, 502);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Scroll to change simulation\'s velocity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 324);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Change map provider:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 408);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Change the filter:";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(405, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 431);
            this.panel1.TabIndex = 12;
            // 
            // Mapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 658);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.ChangeMapBtn);
            this.Controls.Add(this.RestartBtn);
            this.Controls.Add(this.AutomaticBtn);
            this.Controls.Add(this.MoveBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Mapa";
            this.Text = "Mapa";
            this.Load += new System.EventHandler(this.Mapa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button MoveBtn;
        private Button AutomaticBtn;
        private Button RestartBtn;
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