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
        private bool JePrvocislo(int cislo)
        {
            bool prvocislo = true;
            if (cislo == 2) prvocislo = true;
            else
            {
                if (cislo == 1 || cislo % 2 == 0) prvocislo = false;
                else for (int delitel = 3; delitel <= Math.Sqrt(cislo) && prvocislo; ++delitel)
                    {
                        if (cislo % delitel == 0) prvocislo = false;
                    }
            }
            return prvocislo;
        }
        private void Prepis(ListBox listboxik,TextBox textboxik,int []polecisel)
        {
            listboxik.Items.Clear();
            foreach(int i in polecisel )
            {
                if (JePrvocislo(i)) listBox1.Items.Add(i);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            int n = Convert.ToInt32(numericUpDown1.Value);
            int[] polecisel = new int[n];
            Random rng = new Random();
            for (int i = 0; i < n; i++)
            {
                polecisel[i] = rng.Next(2, 16);
                textBox1.Text += Convert.ToString(polecisel[i]) + Environment.NewLine;
            }
            Prepis(listBox1, textBox1, polecisel);
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
