namespace Simulation
{
    partial class Loading2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading2));
            miLoad = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)miLoad).BeginInit();
            SuspendLayout();
            // 
            // miLoad
            // 
            miLoad.Location = new Point(53, 145);
            miLoad.Name = "miLoad";
            miLoad.Size = new Size(264, 209);
            miLoad.TabIndex = 0;
            miLoad.TabStop = false;
            // 
            // Loading2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 527);
            Controls.Add(miLoad);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Loading2";
            Opacity = 0.7D;
            Text = "Loading2";
            WindowState = FormWindowState.Maximized;
            Load += Loading2_Load;
            ((System.ComponentModel.ISupportInitialize)miLoad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox miLoad;
    }
}