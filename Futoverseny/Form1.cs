using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futoverseny
{
    public partial class Form1 : Form
    {

        List<Resztvevo> resztvevok;

        public Form1()
        {
            InitializeComponent();
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void megnyitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                resztvevok = new List<Resztvevo>();
                StreamReader sr = new StreamReader(dialog.FileName);

                while (!sr.EndOfStream)
                {
                    Resztvevo r = new Resztvevo(sr.ReadLine());
                    resztvevok.Add(r);
                }
                sr.Close();

                foreach (Resztvevo item in resztvevok)
                {
                    listBox1.Items.Add(item.nev);
                }
            }

            

            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = resztvevok[listBox1.SelectedIndex].rajtszam;
            textBox2.Text = resztvevok[listBox1.SelectedIndex].orszag;
            textBox3.Text = $"{resztvevok[listBox1.SelectedIndex].idoperc}:{resztvevok[listBox1.SelectedIndex].idomasodperc.ToString("00.00")}";

            DateTime zeroTime = new DateTime(1, 1, 1);
            DateTime szulTime = DateTime.Parse(resztvevok[listBox1.SelectedIndex].szuldatum);
            

            textBox4.Text = ((zeroTime + (TimeSpan)(DateTime.Now - szulTime)).Year - 1).ToString();
        }

        private void eredménylistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Resztvevo> rendezett = new List<Resztvevo>(resztvevok);
            rendezett.Sort((a, b) => string.Concat(a.idoperc, a.idomasodperc).CompareTo(string.Concat(b.idoperc, b.idomasodperc)));

            Form2 f2 = new Form2();

            foreach (Resztvevo item in rendezett)
            {
                Debug.WriteLine(item.idoperc + " " + item.idomasodperc);
            }

            f2.SetLista(rendezett);

            f2.Show();
        }
    }
}
