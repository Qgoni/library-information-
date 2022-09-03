using EducationalPractice;
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
using System.Text.RegularExpressions;

namespace LibraryProcesses
{
    public partial class Librarian : Form
    {
        public Librarian()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void LibrarianLoad(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
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
            label1.ForeColor = Color.Black;
        }

        Point lastPoint;
        private void LibrarianMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void LibrarianMouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Label4Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageLibrary MessagePostavshiky = new MessageLibrary();
            MessagePostavshiky.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int id = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Writer = Avtor.Text;
            string Naz = Nazvanie.Text;
            string Ezd = PostZaOtchGod.Text;
            string God = GodVypyska.Text;
            string Col = KolEkzNaOnchGod.Text;
            dataGridView1.Rows.Add(Writer, Naz, Ezd, God + " год", "Количество-" + Col);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Visible == false)
            {
                dataGridView1.Visible = true;
            }
            else if (dataGridView1.Visible == true)
            {
                dataGridView1.Visible = false;
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = @"C:\VSP\DlTableZaprosPopFondSave.txt";
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                try
                {
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        for (int i = 0; i < dataGridView1.Rows[j].Cells.Count; i++)
                        {
                            streamWriter.Write(dataGridView1.Rows[j].Cells[i].Value + "    ");   
                        }
                        streamWriter.WriteLine();
                    }
                    MessageBox.Show("Файл сохранен");
                }
                catch
                {
                    MessageBox.Show("Ошибка при сохранении файла!");
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            InformationOtSupplire infoOtSupplire = new InformationOtSupplire();
            infoOtSupplire.Show();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            string path = @"C:\VSP\InfoOtLibrian.txt";
            using (StreamWriter streamWriter = new StreamWriter(path,true))
            {  
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                  for (int i = 0; i < dataGridView1.Rows[j].Cells.Count; i++)
                  {
                    streamWriter.Write(dataGridView1.Rows[j].Cells[i].Value + "    ");
                  }
                  streamWriter.WriteLine();
                }  
            }

        }

     

        private void GodVypyska_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void KolEkzNaOnchGod_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }


        private void Avtor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || e.KeyChar == '.' || e.KeyChar == ',');
        }


        private void button8_Click(object sender, EventArgs e)
        {
            RegNewEzdanei regNewEzdanei = new RegNewEzdanei();
            regNewEzdanei.Show();

        }

        private void button9_Click(object sender, EventArgs e)
        {
         PoluchEzd poluchEzd = new PoluchEzd();
            poluchEzd.Show();
        }

        public PoluchEzd PoluchEzd
        {
            get => default;
            set
            {
            }
        }

        public MessageLibrary MessageLibrary
        {
            get => default;
            set
            {
            }
        }

        public RegNewEzdanei RegNewEzdanei
        {
            get => default;
            set
            {
            }
        }

        public InformationOtSupplire InformationOtSupplire
        {
            get => default;
            set
            {
            }
        }
    }
}
