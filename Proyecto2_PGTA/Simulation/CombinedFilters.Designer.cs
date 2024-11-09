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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CombinedFilters));
            checkedListBox1 = new CheckedListBox();
            acceptBtn = new Button();
            pictureBox7 = new PictureBox();
            cancelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.Cursor = Cursors.Hand;
            checkedListBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(195, 96);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(389, 149);
            checkedListBox1.TabIndex = 0;
            checkedListBox1.ThreeDCheckBoxes = true;
            // 
            // acceptBtn
            // 
            acceptBtn.FlatAppearance.BorderColor = Color.DarkGray;
            acceptBtn.FlatAppearance.BorderSize = 3;
            acceptBtn.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            acceptBtn.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            acceptBtn.FlatStyle = FlatStyle.Flat;
            acceptBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            acceptBtn.Location = new Point(256, 315);
            acceptBtn.Name = "acceptBtn";
            acceptBtn.Size = new Size(280, 50);
            acceptBtn.TabIndex = 1;
            acceptBtn.Text = "Accept";
            acceptBtn.UseVisualStyleBackColor = true;
            acceptBtn.Click += acceptBtn_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Center;
            pictureBox7.Location = new Point(563, 421);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(216, 44);
            pictureBox7.TabIndex = 11;
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
            cancelBtn.Location = new Point(650, 375);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(115, 40);
            cancelBtn.TabIndex = 14;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // CombinedFilters
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 461);
            Controls.Add(cancelBtn);
            Controls.Add(pictureBox7);
            Controls.Add(acceptBtn);
            Controls.Add(checkedListBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CombinedFilters";
            Text = "CombinedFilters";
            Load += CombinedFilters_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private Button acceptBtn;
        private PictureBox pictureBox7;
        private Button cancelBtn;
    }
}