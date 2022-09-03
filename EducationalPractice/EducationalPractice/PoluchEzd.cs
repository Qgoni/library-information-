using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace EducationalPractice
{
    public partial class PoluchEzd : Form
    {
        public PoluchEzd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Avtor = textBox1.Text;
            string Naz = textBox2.Text;
            string GodV = textBox3.Text;
            string Poluch = textBox5.Text;
            dataGridView3.Rows.Add(Avtor, Naz, GodV + " год", Poluch);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = dataGridView3.SelectedCells[0].RowIndex;
                dataGridView3.Rows.RemoveAt(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = @"C:\VSP\SAVEdlPoluchEzd.txt";
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                try
                {
                    for (int j = 0; j < dataGridView3.Rows.Count; j++)
                    {
                        for (int i = 0; i < dataGridView3.Rows[j].Cells.Count; i++)
                        {
                            streamWriter.Write(dataGridView3.Rows[j].Cells[i].Value + "    ");
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || e.KeyChar == '.' );
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || e.KeyChar == '.');
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

    }
}
