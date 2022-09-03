using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducationalPractice
{
    public partial class InformationOtSupplire : Form
    {
        public InformationOtSupplire()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"C:\VSP\TextInfoOtSupplier1.txt";
            using (StreamReader streamRead = new StreamReader(path,true))
            {
                string text = streamRead.ReadToEnd();
                richTextBox1.Text = text;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
