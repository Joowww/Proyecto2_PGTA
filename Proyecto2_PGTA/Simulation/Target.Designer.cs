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
            label1 = new Label();
            acceptBtn = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label4 = new Label();
            autofillBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(302, 142);
            label1.Name = "label1";
            label1.Size = new Size(171, 20);
            label1.TabIndex = 0;
            label1.Text = "Enter 2 target addresses:";
            // 
            // acceptBtn
            // 
            acceptBtn.Location = new Point(554, 300);
            acceptBtn.Name = "acceptBtn";
            acceptBtn.Size = new Size(94, 29);
            acceptBtn.TabIndex = 1;
            acceptBtn.Text = "Accept";
            acceptBtn.UseVisualStyleBackColor = true;
            acceptBtn.Click += acceptBtn_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(212, 206);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(451, 206);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(212, 183);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 4;
            label2.Text = "Target address 1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(451, 183);
            label4.Name = "label4";
            label4.Size = new Size(117, 20);
            label4.TabIndex = 6;
            label4.Text = "Target address 2";
            // 
            // autofillBtn
            // 
            autofillBtn.Location = new Point(554, 265);
            autofillBtn.Name = "autofillBtn";
            autofillBtn.Size = new Size(94, 29);
            autofillBtn.TabIndex = 7;
            autofillBtn.Text = "Autofill";
            autofillBtn.UseVisualStyleBackColor = true;
            autofillBtn.Click += autofillBtn_Click;
            // 
            // Target
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(autofillBtn);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(acceptBtn);
            Controls.Add(label1);
            Name = "Target";
            Text = "Target";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button acceptBtn;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label4;
        private Button autofillBtn;
    }
}