namespace Simulation
{
    partial class ImportAst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportAst));
            groupBox1 = new GroupBox();
            label1 = new Label();
            browseBtn = new Button();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            button1 = new Button();
            pictureBox7 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(browseBtn);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(255, 86);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(394, 196);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Import ASTERIX file";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 159);
            label1.Name = "label1";
            label1.Size = new Size(0, 28);
            label1.TabIndex = 6;
            // 
            // browseBtn
            // 
            browseBtn.FlatAppearance.BorderColor = Color.DarkGray;
            browseBtn.FlatAppearance.BorderSize = 3;
            browseBtn.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            browseBtn.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            browseBtn.FlatStyle = FlatStyle.Flat;
            browseBtn.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            browseBtn.Location = new Point(245, 121);
            browseBtn.Name = "browseBtn";
            browseBtn.Size = new Size(100, 30);
            browseBtn.TabIndex = 5;
            browseBtn.Text = "Browse...";
            browseBtn.UseVisualStyleBackColor = true;
            browseBtn.Click += browseBtn_Click;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            radioButton3.Location = new Point(19, 121);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(222, 27);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "Import from your browse";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            radioButton2.Location = new Point(19, 75);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(118, 27);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "ASTERIX 4h";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            radioButton1.Location = new Point(19, 26);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(118, 27);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "ASTERIX 1h";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.DarkGray;
            button1.FlatAppearance.BorderSize = 3;
            button1.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            button1.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(308, 314);
            button1.Name = "button1";
            button1.Size = new Size(280, 50);
            button1.TabIndex = 4;
            button1.Text = "Accept";
            button1.UseVisualStyleBackColor = true;
            button1.Click += acceptBtn_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.Location = new Point(831, 431);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(50, 50);
            pictureBox7.TabIndex = 12;
            pictureBox7.TabStop = false;
            // 
            // ImportAst
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 493);
            Controls.Add(pictureBox7);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ImportAst";
            Text = "ImportAst";
            Load += ImportAst_Load_1;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button browseBtn;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button1;
        private Label label1;
        private PictureBox pictureBox7;
    }
}