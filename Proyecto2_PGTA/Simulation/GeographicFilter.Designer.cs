namespace Simulation
{
    partial class GeographicFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeographicFilter));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            applyBtn = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            autofillBtn = new Button();
            label4 = new Label();
            pictureBox7 = new PictureBox();
            cancelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(57, 34);
            label1.Name = "label1";
            label1.Size = new Size(606, 28);
            label1.TabIndex = 0;
            label1.Text = "Insert minimum and maximum values for latitude and longitude ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(349, 172);
            label2.Name = "label2";
            label2.Size = new Size(145, 28);
            label2.TabIndex = 1;
            label2.Text = "< Longitude <";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(349, 135);
            label3.Name = "label3";
            label3.Size = new Size(144, 28);
            label3.TabIndex = 2;
            label3.Text = "<  Latitude   <";
            // 
            // applyBtn
            // 
            applyBtn.FlatAppearance.BorderColor = Color.DarkGray;
            applyBtn.FlatAppearance.BorderSize = 3;
            applyBtn.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            applyBtn.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            applyBtn.FlatStyle = FlatStyle.Flat;
            applyBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            applyBtn.Location = new Point(281, 315);
            applyBtn.Name = "applyBtn";
            applyBtn.Size = new Size(280, 50);
            applyBtn.TabIndex = 3;
            applyBtn.Text = "Apply";
            applyBtn.UseVisualStyleBackColor = true;
            applyBtn.Click += applyBtn_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(218, 132);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(497, 135);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(218, 169);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(497, 172);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 7;
            // 
            // autofillBtn
            // 
            autofillBtn.FlatAppearance.BorderColor = Color.DarkGray;
            autofillBtn.FlatAppearance.BorderSize = 3;
            autofillBtn.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            autofillBtn.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            autofillBtn.FlatStyle = FlatStyle.Flat;
            autofillBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            autofillBtn.Location = new Point(350, 236);
            autofillBtn.Name = "autofillBtn";
            autofillBtn.Size = new Size(140, 40);
            autofillBtn.TabIndex = 8;
            autofillBtn.Text = "Autofill";
            autofillBtn.UseVisualStyleBackColor = true;
            autofillBtn.Click += autofillBtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(57, 85);
            label4.Name = "label4";
            label4.Size = new Size(418, 28);
            label4.TabIndex = 9;
            label4.Text = "IMPORTANT: The separator must be a coma!";
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.Location = new Point(802, 445);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(50, 50);
            pictureBox7.TabIndex = 12;
            pictureBox7.TabStop = false;
            // 
            // cancelBtn
            // 
            cancelBtn.FlatAppearance.BorderColor = Color.DarkGray;
            cancelBtn.FlatAppearance.BorderSize = 3;
            cancelBtn.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            cancelBtn.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cancelBtn.Location = new Point(681, 391);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(115, 40);
            cancelBtn.TabIndex = 13;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // GeographicFilter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 496);
            Controls.Add(cancelBtn);
            Controls.Add(pictureBox7);
            Controls.Add(label4);
            Controls.Add(autofillBtn);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(applyBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GeographicFilter";
            Text = "GeographicFilter";
            Load += GeographicFilter_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button applyBtn;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button autofillBtn;
        private Label label4;
        private PictureBox pictureBox7;
        private Button cancelBtn;
    }
}