namespace Simulation
{
    partial class GeographicFilter
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
            label2 = new Label();
            label3 = new Label();
            applyBtn = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            autofillBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(118, 154);
            label1.Name = "label1";
            label1.Size = new Size(593, 20);
            label1.TabIndex = 0;
            label1.Text = "Insert minimum and maximum values for latitude and longitude (separator with a coma)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(310, 233);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 1;
            label2.Text = "< Longitude <";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(310, 196);
            label3.Name = "label3";
            label3.Size = new Size(91, 20);
            label3.TabIndex = 2;
            label3.Text = "< Latitude <";
            // 
            // applyBtn
            // 
            applyBtn.Location = new Point(589, 278);
            applyBtn.Name = "applyBtn";
            applyBtn.Size = new Size(94, 29);
            applyBtn.TabIndex = 3;
            applyBtn.Text = "Apply";
            applyBtn.UseVisualStyleBackColor = true;
            applyBtn.Click += applyBtn_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(179, 193);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(420, 196);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(179, 230);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(420, 230);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 7;
            // 
            // autofillBtn
            // 
            autofillBtn.Location = new Point(589, 243);
            autofillBtn.Name = "autofillBtn";
            autofillBtn.Size = new Size(94, 29);
            autofillBtn.TabIndex = 8;
            autofillBtn.Text = "Autofill";
            autofillBtn.UseVisualStyleBackColor = true;
            autofillBtn.Click += autofillBtn_Click;
            // 
            // GeographicFilter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(autofillBtn);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(applyBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GeographicFilter";
            Text = "GeographicFilter";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button applyBtn;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button autofillBtn;
    }
}