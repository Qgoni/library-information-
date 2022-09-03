using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProcesses
{
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Label1Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Close();
        }

        private void Label1MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void Label1MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor= Color.Black;
        }

        Point lastPoint;
        private void SupplierMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void SupplierMouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Label4Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string path = @"C:\VSP\InfoOtLibrian.txt";
            using (StreamReader sr = new StreamReader(path, true))
            {
                string text = sr.ReadToEnd();//.Last().ToString();
                richTextBox1.Text = text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"C:\VSP\TextInfoOtSupplier1.txt";
            using (StreamWriter text2 = new StreamWriter(path, false))
            {
                text2.WriteLine(textBox2.Text);
            }
        }
    }
}
