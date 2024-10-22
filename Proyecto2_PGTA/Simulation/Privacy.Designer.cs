namespace Simulation
{
    partial class Privacy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Privacy));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            pictureBox7 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(41, 56);
            label1.Name = "label1";
            label1.Size = new Size(698, 28);
            label1.TabIndex = 0;
            label1.Text = "The application collects minimal data necessary for its functionality, such as";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(41, 114);
            label2.Name = "label2";
            label2.Size = new Size(742, 28);
            label2.TabIndex = 1;
            label2.Text = "contact and usage information. We do not share data with third parties without ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(41, 171);
            label3.Name = "label3";
            label3.Size = new Size(723, 28);
            label3.TabIndex = 2;
            label3.Text = "prior consent, except when required by law. All information is securely stored ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(41, 229);
            label4.Name = "label4";
            label4.Size = new Size(406, 28);
            label4.TabIndex = 3;
            label4.Text = "and protected against unauthorized access.";
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.DarkGray;
            button1.FlatAppearance.BorderSize = 3;
            button1.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            button1.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(282, 354);
            button1.Name = "button1";
            button1.Size = new Size(280, 50);
            button1.TabIndex = 4;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(251, 300);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(16, 14);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(41, 300);
            label5.Name = "label5";
            label5.Size = new Size(204, 28);
            label5.TabIndex = 6;
            label5.Text = "2024-AstDecoder.org";
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Center;
            pictureBox7.Location = new Point(585, 412);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(216, 44);
            pictureBox7.TabIndex = 11;
            pictureBox7.TabStop = false;
            // 
            // Privacy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox7);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Privacy";
            Text = "Privacy";
            Load += Privacy_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private PictureBox pictureBox1;
        private Label label5;
        private PictureBox pictureBox7;
    }
}