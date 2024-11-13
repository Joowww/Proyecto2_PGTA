namespace Simulation
{
    partial class CloseApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloseApp));
            label1 = new Label();
            buttonYes = new Button();
            buttonNo = new Button();
            pictureBox7 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(90, 122);
            label1.Name = "label1";
            label1.Size = new Size(595, 28);
            label1.TabIndex = 0;
            label1.Text = "Are you sure you want to close the Asterix Decoder application?";
            // 
            // buttonYes
            // 
            buttonYes.FlatAppearance.BorderColor = Color.DarkGray;
            buttonYes.FlatAppearance.BorderSize = 3;
            buttonYes.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            buttonYes.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            buttonYes.FlatStyle = FlatStyle.Flat;
            buttonYes.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonYes.Location = new Point(149, 241);
            buttonYes.Name = "buttonYes";
            buttonYes.Size = new Size(200, 50);
            buttonYes.TabIndex = 1;
            buttonYes.Text = "Yes";
            buttonYes.UseMnemonic = false;
            buttonYes.UseVisualStyleBackColor = true;
            buttonYes.Click += buttonYes_Click;
            // 
            // buttonNo
            // 
            buttonNo.FlatAppearance.BorderColor = Color.DarkGray;
            buttonNo.FlatAppearance.BorderSize = 3;
            buttonNo.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            buttonNo.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            buttonNo.FlatStyle = FlatStyle.Flat;
            buttonNo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonNo.Location = new Point(390, 241);
            buttonNo.Name = "buttonNo";
            buttonNo.Size = new Size(200, 50);
            buttonNo.TabIndex = 2;
            buttonNo.Text = "No";
            buttonNo.UseVisualStyleBackColor = true;
            buttonNo.Click += buttonNo_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.Location = new Point(723, 353);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(50, 50);
            pictureBox7.TabIndex = 10;
            pictureBox7.TabStop = false;
            // 
            // CloseApp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 415);
            Controls.Add(pictureBox7);
            Controls.Add(buttonNo);
            Controls.Add(buttonYes);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CloseApp";
            Text = "CloseApp";
            Load += CloseApp_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttonYes;
        private Button buttonNo;
        private PictureBox pictureBox7;
    }
}