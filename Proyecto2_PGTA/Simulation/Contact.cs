using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    public partial class Contact : Form
    {
        private bool isDarkMode;

        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recLbl1;
        private Rectangle recLbl2;
        private Rectangle recLbl3;
        private Rectangle recLbl4;
        private Rectangle recLbl5;
        private Rectangle recLbl6;
        private Rectangle recLbl7;
        private Rectangle recLbl8;
        private Rectangle recPtb1;
        public Contact()
        {
            InitializeComponent();
            this.Resize += Contact_Resiz;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(buttonClose.Location, buttonClose.Size);
            recLbl1 = new Rectangle(label9.Location, label9.Size);
            recLbl2 = new Rectangle(label2.Location, label2.Size);
            recLbl3 = new Rectangle(label3.Location, label3.Size);
            recLbl4 = new Rectangle(label4.Location, label4.Size);
            recLbl5 = new Rectangle(label5.Location, label5.Size);
            recLbl6 = new Rectangle(label6.Location, label6.Size);
            recLbl7 = new Rectangle(label7.Location, label7.Size);
            recLbl8 = new Rectangle(label8.Location, label8.Size);
            recPtb1 = new Rectangle(pictureBox7.Location, pictureBox7.Size);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }
        private void Contact_Resiz(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                resize_Control(buttonClose, recBut1);
                resize_Control(label9, recLbl1);
                resize_Control(label2, recLbl2);
                resize_Control(label3, recLbl3);
                resize_Control(label4, recLbl4);
                resize_Control(label5, recLbl5);
                resize_Control(label6, recLbl6);
                resize_Control(label7, recLbl7);
                resize_Control(label8, recLbl8);
                resize_Control(pictureBox7, recPtb1);
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                restore_ControlSize(buttonClose, recBut1);
                restore_ControlSize(label9, recLbl1);
                restore_ControlSize(label2, recLbl2);
                restore_ControlSize(label3, recLbl3);
                restore_ControlSize(label4, recLbl4);
                restore_ControlSize(label5, recLbl5);
                restore_ControlSize(label6, recLbl6);
                restore_ControlSize(label7, recLbl7);
                restore_ControlSize(label8, recLbl8);
                restore_ControlSize(pictureBox7, recPtb1);
            }
        }

        private void restore_ControlSize(Control control, Rectangle originalRect)
        {
            control.Location = originalRect.Location;
            control.Size = originalRect.Size;

            // Restauramos el tamaño de la fuente original
            control.Font = new Font(control.Font.FontFamily, 10, control.Font.Style);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;

        }
        private void resize_Control(Control control, Rectangle rect)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);

            int newX = (int)(rect.X * xRatio);
            int newY = (int)(rect.Y * yRatio);

            int newWidth = (int)(rect.Width * xRatio);
            int newHeight = (int)(rect.Height * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);

            // Ajustar tamaño de la fuente
            float fontSizeRatio = Math.Min(xRatio, yRatio); // Escala basada en la menor proporción
            control.Font = new Font(control.Font.FontFamily, control.Font.Size * fontSizeRatio, control.Font.Style);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;

        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Welcome Welc = new Welcome();
            // Oculta el Principal
            this.Hide();
        }

        private void Contact_Load(object sender, EventArgs e)
        {
            // Cargar el estado del tema guardado
            isDarkMode = Properties.Settings1.Default.IsDarkMode;

            // Aplicar el tema según el estado guardado
            ApplyTheme();

            // Si el modo oscuro está activo, aplicarlo
            if (isDarkMode)
            {
                Theme.SetDarkMode(this);
            }
            else
            {
                Theme.SetLightMode(this);
            }
        }
        private void ApplyTheme()
        {
            // Aplica el tema al formulario actual
            if (isDarkMode)
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
            }
            else
            {
                this.BackColor = Color.White;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
