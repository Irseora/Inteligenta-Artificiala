using C1___Geometrie_Vectoriala;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inteligenta_Artificiala
{
    public partial class Form1 : Form
    {
        MyGraphics grp; //, grp2, grp3;
        Population population;
        int etapa;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            etapa = 1000;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AG.Init();

            grp = new MyGraphics(pictureBox1);
            /*grp2 = new MyGraphics(pictureBox3);
            grp3 = new MyGraphics(pictureBox2);*/

            population = new Population();

            /*population.Sort();
            population.Selection();*/

            /*Solution test = population.Cross(population.par[0], population.par[1]);
            test.Mutate(200);

            population.par[0].Draw(grp1.g);
            population.par[1].Draw(grp2.g);
            test.Draw(grp3.g);*/

            grp.RefreshGraphics();
            /*grp2.RefreshGraphics();
            grp3.RefreshGraphics();*/

            /*textBox1.Text = population.par[0].Fitness().ToString("0.000");
            textBox3.Text = population.par[1].Fitness().ToString("0.000");
            textBox2.Text = test.Fitness().ToString("0.000");*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            etapa--;
            population.Do(etapa / 3 + 1);

            grp.ClearGraphics();
            population.par[0].Draw(grp.g);
            grp.RefreshGraphics();

            textBox1.Text = population.par[0].Fitness().ToString();

            if (etapa == 20)
                timer1.Stop();
        }
    }
}
