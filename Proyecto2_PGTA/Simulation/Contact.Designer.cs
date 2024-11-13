namespace Simulation
{
    partial class Contact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contact));
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            pictureBox7 = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            buttonClose = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(201, 211);
            label9.Name = "label9";
            label9.Size = new Size(412, 28);
            label9.TabIndex = 27;
            label9.Text = "•  joel.moreno.de.toro@estudiantat.upc.edu";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(201, 301);
            label8.Name = "label8";
            label8.Size = new Size(353, 28);
            label8.TabIndex = 26;
            label8.Text = "•  mireia.viladot@estudiantat.upc.edu";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(201, 271);
            label7.Name = "label7";
            label7.Size = new Size(326, 28);
            label7.TabIndex = 25;
            label7.Text = "•  paula.valle@estudiantat.upc.edu";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(201, 241);
            label6.Name = "label6";
            label6.Size = new Size(324, 28);
            label6.TabIndex = 24;
            label6.Text = "•  erica.parra@estudiantat.upc.edu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(199, 181);
            label5.Name = "label5";
            label5.Size = new Size(471, 28);
            label5.TabIndex = 23;
            label5.Text = "•  jose.carlos.martinez.conde@estudiantat.upc.edu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(199, 151);
            label4.Name = "label4";
            label4.Size = new Size(413, 28);
            label4.TabIndex = 22;
            label4.Text = "•  marina.martin.ferrer@estudiantat.upc.edu";
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.Location = new Point(768, 422);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(50, 50);
            pictureBox7.TabIndex = 21;
            pictureBox7.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(37, 61);
            label3.Name = "label3";
            label3.Size = new Size(667, 28);
            label3.TabIndex = 20;
            label3.Text = "Listed below are the institutional contact emails of each group member.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(199, 121);
            label2.Name = "label2";
            label2.Size = new Size(436, 28);
            label2.TabIndex = 19;
            label2.Text = "•  alejandro.curiel.molina@estudiantat.upc.edu";
            // 
            // buttonClose
            // 
            buttonClose.FlatAppearance.BorderColor = Color.DarkGray;
            buttonClose.FlatAppearance.BorderSize = 3;
            buttonClose.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            buttonClose.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClose.Location = new Point(258, 366);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(280, 50);
            buttonClose.TabIndex = 13;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // Contact
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 484);
            Controls.Add(buttonClose);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(pictureBox7);
            Controls.Add(label3);
            Controls.Add(label2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Contact";
            Text = "Contact";
            Load += Contact_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private PictureBox pictureBox7;
        private Label label3;
        private Label label2;
        private Button buttonClose;
    }
}