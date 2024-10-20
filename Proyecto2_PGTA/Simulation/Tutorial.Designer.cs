namespace Simulation
{
    partial class Tutorial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tutorial));
            label1 = new Label();
            pictureBox7 = new PictureBox();
            panel1 = new Panel();
            buttonClose = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(25, 69);
            label1.Name = "label1";
            label1.Size = new Size(737, 28);
            label1.TabIndex = 0;
            label1.Text = "Explicación breve sobre los pasos a seguir para un uso correcto de la aplicación:";
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Center;
            pictureBox7.Location = new Point(664, 455);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(216, 44);
            pictureBox7.TabIndex = 10;
            pictureBox7.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonClose);
            panel1.Location = new Point(354, 409);
            panel1.Name = "panel1";
            panel1.Size = new Size(197, 60);
            panel1.TabIndex = 18;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(2, 4);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(192, 54);
            buttonClose.TabIndex = 13;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(124, 232);
            label2.Name = "label2";
            label2.Size = new Size(645, 28);
            label2.TabIndex = 19;
            label2.Text = "Segundo, añadimos en parámetros de simulación los datos restantes.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(124, 307);
            label3.Name = "label3";
            label3.Size = new Size(258, 28);
            label3.TabIndex = 20;
            label3.Text = "Tercero le damos a simular.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(124, 155);
            label4.Name = "label4";
            label4.Size = new Size(578, 28);
            label4.TabIndex = 21;
            label4.Text = "Primero, se deben introducir los datos de los vuelos a simular.";
            // 
            // Tutorial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(879, 496);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(pictureBox7);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Tutorial";
            Text = "Tutorial";
            Load += Tutorial_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox7;
        private Panel panel1;
        private Button buttonClose;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}