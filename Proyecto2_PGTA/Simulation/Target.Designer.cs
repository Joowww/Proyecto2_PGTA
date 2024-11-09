namespace Simulation
{
    partial class Target
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Target));
            label1 = new Label();
            acceptBtn = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            autofillBtn = new Button();
            pictureBox7 = new PictureBox();
            label3 = new Label();
            label5 = new Label();
            cancelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(272, 71);
            label1.Name = "label1";
            label1.Size = new Size(237, 28);
            label1.TabIndex = 0;
            label1.Text = "Enter 2 target addresses:";
            // 
            // acceptBtn
            // 
            acceptBtn.FlatAppearance.BorderColor = Color.DarkGray;
            acceptBtn.FlatAppearance.BorderSize = 3;
            acceptBtn.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            acceptBtn.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            acceptBtn.FlatStyle = FlatStyle.Flat;
            acceptBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            acceptBtn.Location = new Point(234, 278);
            acceptBtn.Name = "acceptBtn";
            acceptBtn.Size = new Size(280, 50);
            acceptBtn.TabIndex = 1;
            acceptBtn.Text = "Accept";
            acceptBtn.UseVisualStyleBackColor = true;
            acceptBtn.Click += acceptBtn_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(192, 143);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(436, 143);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            // 
            // autofillBtn
            // 
            autofillBtn.FlatAppearance.BorderColor = Color.DarkGray;
            autofillBtn.FlatAppearance.BorderSize = 3;
            autofillBtn.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            autofillBtn.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            autofillBtn.FlatStyle = FlatStyle.Flat;
            autofillBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            autofillBtn.Location = new Point(306, 206);
            autofillBtn.Name = "autofillBtn";
            autofillBtn.Size = new Size(140, 40);
            autofillBtn.TabIndex = 7;
            autofillBtn.Text = "Autofill";
            autofillBtn.UseVisualStyleBackColor = true;
            autofillBtn.Click += autofillBtn_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Center;
            pictureBox7.Location = new Point(590, 409);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(216, 44);
            pictureBox7.TabIndex = 13;
            pictureBox7.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(192, 112);
            label3.Name = "label3";
            label3.Size = new Size(134, 23);
            label3.TabIndex = 14;
            label3.Text = "Target address 1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(436, 112);
            label5.Name = "label5";
            label5.Size = new Size(134, 23);
            label5.TabIndex = 15;
            label5.Text = "Target address 2";
            // 
            // cancelBtn
            // 
            cancelBtn.FlatAppearance.BorderColor = Color.DarkGray;
            cancelBtn.FlatAppearance.BorderSize = 3;
            cancelBtn.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            cancelBtn.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cancelBtn.Location = new Point(673, 363);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(115, 40);
            cancelBtn.TabIndex = 16;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // Target
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cancelBtn);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(pictureBox7);
            Controls.Add(autofillBtn);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(acceptBtn);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Target";
            Text = "Target";
            Load += Target_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button acceptBtn;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button autofillBtn;
        private PictureBox pictureBox7;
        private Label label3;
        private Label label5;
        private Button cancelBtn;
    }
}