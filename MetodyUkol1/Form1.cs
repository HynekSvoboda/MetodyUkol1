using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodyUkol1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private bool JePrvocislo(int n, ref int[] poleprvocisel)
        {
            bool prvocislo = true;
            int cislo;
            for (int y = 0; n > y; y++)
            {
                cislo = Convert.ToInt32(textBox1.Lines[y]);
                if (cislo == 2 || cislo == 3)
                {
                    prvocislo = true;
                    poleprvocisel[y] = cislo;
                }
                else
                {
                    for (int i = 2; i <= Math.Sqrt(cislo); i++)
                    {
                        if (cislo % i == 0)
                        {
                            prvocislo = false;
                            break;
                        }
                        else
                        {
                            poleprvocisel[y] = cislo;
                        }
                    }
                }
            }
            return prvocislo;
        }
        private void Prepis(ListBox listboxik, int n, ref int[] poleprvocisel)
        {
            listboxik.Items.Clear();
            for (int i = 0; i < n; i++)
            {
                if (poleprvocisel[i] != 0) listboxik.Items.Add(poleprvocisel[i]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            int n = Convert.ToInt32(numericUpDown1.Value);
            int[] poleprvocisel = new int[n];
            Random rng = new Random();
            for (int i = 0; i < n; i++)
            {
                textBox1.Text += Convert.ToString(rng.Next(2, 16)) + Environment.NewLine;
            }
            JePrvocislo(n, ref poleprvocisel);
            Prepis(listBox1, n, ref poleprvocisel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Napište metodu JePrvocislo, která pro dané číslo jako parametr vrátí bool.\nDále napište metodu Prepis.\nMetoda Prepis do komponenty listBox přepíše všechna čísla, která jsou prvočísla z komponenty textBox.\nDo komponenty textBox vygenerujte N celých náhodnýchčísel z intervalu<2,15 >.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
