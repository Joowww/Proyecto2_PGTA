namespace Simulation
{
    partial class CombinedFilters
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
            checkedListBox1 = new CheckedListBox();
            acceptBtn = new Button();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(250, 118);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(270, 202);
            checkedListBox1.TabIndex = 0;
            // 
            // acceptBtn
            // 
            acceptBtn.Location = new Point(339, 326);
            acceptBtn.Name = "acceptBtn";
            acceptBtn.Size = new Size(94, 29);
            acceptBtn.TabIndex = 1;
            acceptBtn.Text = "Accept";
            acceptBtn.UseVisualStyleBackColor = true;
            acceptBtn.Click += acceptBtn_Click;
            // 
            // CombinedFilters
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 450);
            Controls.Add(acceptBtn);
            Controls.Add(checkedListBox1);
            Name = "CombinedFilters";
            Text = "CombinedFilters";
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private Button acceptBtn;
    }
}