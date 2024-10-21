namespace Simulation
{
    partial class VideoTutorial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoTutorial));
            pictureBox2 = new PictureBox();
            label1 = new Label();
            pictureBox7 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            buttonClose = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Location = new Point(315, 199);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(233, 195);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(132, 132);
            label1.Name = "label1";
            label1.Size = new Size(591, 28);
            label1.TabIndex = 5;
            label1.Text = "También hay la posibilidad de entrar al videotutorial con un QR:";
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Center;
            pictureBox7.Location = new Point(628, 461);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(216, 44);
            pictureBox7.TabIndex = 10;
            pictureBox7.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(132, 34);
            label2.Name = "label2";
            label2.Size = new Size(440, 28);
            label2.TabIndex = 11;
            label2.Text = "Aquí hay el link para poder ver el videotutorial:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(396, 86);
            label3.Name = "label3";
            label3.Size = new Size(65, 28);
            label3.TabIndex = 12;
            label3.Text = "label3";
            label3.Click += label3_Click;
            // 
            // buttonClose
            // 
            buttonClose.FlatAppearance.BorderColor = Color.DarkGray;
            buttonClose.FlatAppearance.BorderSize = 3;
            buttonClose.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            buttonClose.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClose.Location = new Point(268, 424);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(280, 50);
            buttonClose.TabIndex = 13;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // VideoTutorial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(844, 505);
            Controls.Add(buttonClose);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox7);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VideoTutorial";
            Text = "VideoTutorial";
            Load += VideoTutorial_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private Label label1;
        private PictureBox pictureBox7;
        private Label label2;
        private Label label3;
        private Button buttonClose;
    }
}