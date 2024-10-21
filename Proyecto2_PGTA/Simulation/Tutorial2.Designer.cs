namespace Simulation
{
    partial class Tutorial2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tutorial2));
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            buttonClose = new Button();
            pictureBox7 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(138, 128);
            label4.Name = "label4";
            label4.Size = new Size(90, 28);
            label4.TabIndex = 27;
            label4.Text = "Firstly, ...";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(138, 280);
            label3.Name = "label3";
            label3.Size = new Size(94, 28);
            label3.TabIndex = 26;
            label3.Text = "Finally, ...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(138, 205);
            label2.Name = "label2";
            label2.Size = new Size(105, 28);
            label2.TabIndex = 25;
            label2.Text = "Second, ...";
            // 
            // buttonClose
            // 
            buttonClose.FlatAppearance.BorderColor = Color.DarkGray;
            buttonClose.FlatAppearance.BorderSize = 3;
            buttonClose.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            buttonClose.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClose.Location = new Point(280, 380);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(280, 50);
            buttonClose.TabIndex = 13;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Center;
            pictureBox7.Location = new Point(678, 428);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(216, 44);
            pictureBox7.TabIndex = 23;
            pictureBox7.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(39, 42);
            label1.Name = "label1";
            label1.Size = new Size(682, 28);
            label1.TabIndex = 22;
            label1.Text = " Brief explanation of the steps to follow for proper use of the application:";
            // 
            // Tutorial2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 471);
            Controls.Add(buttonClose);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox7);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Tutorial2";
            Text = "Tutorial2";
            Load += Tutorial2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label3;
        private Label label2;
        private Button buttonClose;
        private PictureBox pictureBox7;
        private Label label1;
    }
}