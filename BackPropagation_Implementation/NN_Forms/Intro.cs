using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace BackPropagation_Implementation.NN_Forms
{
    public partial class Intro : Telerik.WinControls.UI.RadForm
    {
        public static bool BP = false, BPM = false, Levenberg = false;
        public Intro()
        {
            InitializeComponent();
        }

        private void Intro_Load(object sender, EventArgs e)
        {

        }

        private void radLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Hide();
            TSP tsp = new TSP()
            {
                Owner = this
            };
            tsp.Show();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            BP = false;
            BPM = true;
            Levenberg = false;
            Hide();
            NN nn = new NN()
            {
                Owner = this
            };
            nn.Show();
        }

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            BP = true;
            BPM = false;
            Levenberg = false;
            Hide();
            NN nn = new NN()
            {
                Owner = this
            };
            nn.Show();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            BP = false;
            BPM = false;
            Levenberg = true;
            Hide();
            NN nn = new NN()
            {
                Owner = this
            };
            nn.Show();
        }
    }
}
