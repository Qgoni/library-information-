using LibraryProcesses;
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
    public partial class MessageLibrary : Form
    {
        public MessageLibrary()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\VSP\InfoOtLibrian.txt";
            using(StreamWriter strew = new StreamWriter(path,false))
            {
                strew.WriteLine(MeesagerBoxOtLib.Text);
            }
        }
    }
}
