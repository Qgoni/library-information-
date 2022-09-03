using EducationalPractice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProcesses
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void ButtonEntranceClick(object sender, EventArgs e)
        {

          if (textBox1.Text != "123" && textBox1.Text != "1234" && textBox1.Text !="12345")
          {
             MessageBox.Show("Пароль не верный");
          }

          if (textBox1.Text == "123")
          {
               //Hide();
               Supplier GlavnoeOknoSupplier = new Supplier();
               GlavnoeOknoSupplier.Show();
          }

          else if (textBox1.Text == "1234")
          {
              //Hide();
              Librarian GlavnoeOknoLibrarian = new Librarian();
              GlavnoeOknoLibrarian.Show();
          }       
          else if (textBox1.Text == "12345")
            {
               //Hide();
               Registrator GlavnoeOknoAddInfoClient = new Registrator();
                GlavnoeOknoAddInfoClient.Show();
            }
        }

        private void CloseAuthorizationClick(object sender, EventArgs e)
        {
            Application.Exit();  
        }

        private void CloseAuthorizationMouseEnter(object sender, EventArgs e)
        {
            CloseAuthorization.ForeColor = Color.Red;
        }

        private void CloseAuthorizationMouseLeave(object sender, EventArgs e)
        {
            CloseAuthorization.ForeColor = Color.Black;
        }


        private void Label5Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        Point lastPoint;
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        public Librarian Librarian
        {
            get => default;
            set
            {
            }
        }

        public Supplier Supplier
        {
            get => default;
            set
            {
            }
        }

        public Registrator Registrator
        {
            get => default;
            set
            {
            }
        }
    }
}
