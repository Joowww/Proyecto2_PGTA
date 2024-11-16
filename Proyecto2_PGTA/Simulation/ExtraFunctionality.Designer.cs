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
            cancelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(31, 75);
            label1.Name = "label1";
            label1.Size = new Size(744, 28);
            label1.TabIndex = 0;
            label1.Text = "This additional feature allows you to input two target identification and visualize";
            // 
            // targetBtn
            // 
            targetBtn.FlatAppearance.BorderColor = Color.DarkGray;
            targetBtn.FlatAppearance.BorderSize = 3;
            targetBtn.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            targetBtn.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            targetBtn.FlatStyle = FlatStyle.Flat;
            targetBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            targetBtn.Location = new Point(254, 268);
            targetBtn.Name = "targetBtn";
            targetBtn.Size = new Size(280, 50);
            targetBtn.TabIndex = 1;
            targetBtn.Text = "Enter 2 target identification";
            targetBtn.UseVisualStyleBackColor = true;
            targetBtn.Click += targetBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(31, 117);
            label2.Name = "label2";
            label2.Size = new Size(738, 28);
            label2.TabIndex = 2;
            label2.Text = "the simulation of both, as well as the distance between them with each update.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(31, 196);
            label3.Name = "label3";
            label3.Size = new Size(649, 28);
            label3.TabIndex = 3;
            label3.Text = "Note: You can use all the buttons and settings, just as you did before.";
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.Location = new Point(738, 398);
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
            cancelBtn.Location = new Point(590, 340);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(115, 40);
            cancelBtn.TabIndex = 14;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // ExtraFunctionality
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cancelBtn);
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
        private Button cancelBtn;
    }
}