namespace Simulation
{
    partial class ExtraFunctionality
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtraFunctionality));
            label1 = new Label();
            targetBtn = new Button();
            label2 = new Label();
            label3 = new Label();
            pictureBox7 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(254, 83);
            label1.Name = "label1";
            label1.Size = new Size(250, 28);
            label1.TabIndex = 0;
            label1.Text = "Explicar extra functionality";
            // 
            // targetBtn
            // 
            targetBtn.FlatAppearance.BorderColor = Color.DarkGray;
            targetBtn.FlatAppearance.BorderSize = 3;
            targetBtn.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            targetBtn.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            targetBtn.FlatStyle = FlatStyle.Flat;
            targetBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            targetBtn.Location = new Point(254, 299);
            targetBtn.Name = "targetBtn";
            targetBtn.Size = new Size(280, 50);
            targetBtn.TabIndex = 1;
            targetBtn.Text = "Enter 2 target addresses";
            targetBtn.UseVisualStyleBackColor = true;
            targetBtn.Click += targetBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(254, 138);
            label2.Name = "label2";
            label2.Size = new Size(250, 28);
            label2.TabIndex = 2;
            label2.Text = "Explicar extra functionality";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(254, 191);
            label3.Name = "label3";
            label3.Size = new Size(250, 28);
            label3.TabIndex = 3;
            label3.Text = "Explicar extra functionality";
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Center;
            pictureBox7.Location = new Point(587, 408);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(216, 44);
            pictureBox7.TabIndex = 12;
            pictureBox7.TabStop = false;
            // 
            // ExtraFunctionality
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox7);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(targetBtn);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ExtraFunctionality";
            Text = "ExtraFunctionality";
            Load += ExtraFunctionality_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button targetBtn;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox7;
    }
}