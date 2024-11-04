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
            label1 = new Label();
            targetBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(293, 100);
            label1.Name = "label1";
            label1.Size = new Size(184, 20);
            label1.TabIndex = 0;
            label1.Text = "Explicar extra functionality";
            // 
            // targetBtn
            // 
            targetBtn.Location = new Point(274, 289);
            targetBtn.Name = "targetBtn";
            targetBtn.Size = new Size(231, 38);
            targetBtn.TabIndex = 1;
            targetBtn.Text = "Enter 2 target addresses";
            targetBtn.UseVisualStyleBackColor = true;
            // 
            // ExtraFunctionality
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(targetBtn);
            Controls.Add(label1);
            Name = "ExtraFunctionality";
            Text = "ExtraFunctionality";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button targetBtn;
    }
}