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
    public partial class RegNewEzdanei : Form
    {
        public RegNewEzdanei()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string Avtor = textBox1.Text;
            string Naz = textBox2.Text;
            string GodV = textBox3.Text;
            string Kolich = textBox4.Text;
            string Zareg = textBox5.Text;
            dataGridView2.Rows.Add(Avtor, Naz, GodV+" год","Количество-"+ Kolich, Zareg);     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = dataGridView2.SelectedCells[0].RowIndex;
                dataGridView2.Rows.RemoveAt(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = @"C:\VSP\SaveNewExd.txt";
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                try
                {
                    for (int j = 0; j < dataGridView2.Rows.Count; j++)
                    {
                        for (int i = 0; i < dataGridView2.Rows[j].Cells.Count; i++)
                        {
                            streamWriter.Write(dataGridView2.Rows[j].Cells[i].Value + "    ");
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || e.KeyChar == '.');
        }
    }
}
