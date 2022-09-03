using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EducationalPractice
{
    public partial class Registrator : Form
    {
        public Registrator()
        {
            InitializeComponent();
        }
    
        private string stringToPrint;
        private void button2_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument1 = new PrintDocument();
            string docPath = textBox4.Text;
            if (textBox4.Text == "")
            {
                docPath = @"C:\VSP\Clients.txt";
            }
            else {docPath = textBox4.Text;}
            using (StreamReader reader = new StreamReader(docPath))
            {
               stringToPrint = reader.ReadToEnd();
            }
                      
            printDocument1.PrintPage += PrintPageHendler;
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDialog1.Document.Print();
        }

        void PrintPageHendler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(stringToPrint, new Font("Aria", 20), Brushes.Black, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string kart = textBox6.Text;
            string path = @"C:\VSP\Clients.txt";
            string id = textBox1.Text;
            string name = textBox2.Text;
            string sername = textBox3.Text;
            string otchestve = textBox5.Text;
            string date = dateTimePicker1.Value.ToShortDateString();

            if (textBox4.Text == "")
            {
                path = @"C:\VSP\Clients.txt";
            }
            else
            {
                path = textBox4.Text;
            }  

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(kart);
                writer.WriteLine($"id: {id}");
                writer.WriteLine($"Имя: {name}");
                writer.WriteLine($"Фамилия: {sername}");
                writer.WriteLine($"Отчество: {otchestve}");
                writer.WriteLine($"Дата: {date}");             
            }
        }

        private void CloseAuthorization_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseAuthorization_MouseEnter(object sender, EventArgs e)
        {
            CloseRegistrator.ForeColor = Color.Red;
        }

        private void CloseAuthorization_MouseLeave(object sender, EventArgs e)
        {
            CloseRegistrator.ForeColor = Color.Black;
        }

        private void MinSizeReg_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        Point lastPoint;
        private void AddInfoClient_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void AddInfoClient_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }


        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

    }
}
