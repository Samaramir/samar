using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dairyframma
{
    public partial class Finance : Form
    {
        public Finance()
        {
            InitializeComponent();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label19_Click(object sender, EventArgs e)
        {
            cows ob = new cows();
            ob.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Mailk_Producation ob = new Mailk_Producation();
            ob.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            cowHealth ob = new cowHealth();
            ob.Show();
            this.Hide();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            Breeding ob = new Breeding();
            ob.Show();
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            MilkSales ob = new MilkSales();
            ob.Show();
            this.Hide();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            DashBoard ob = new DashBoard();
            ob.Show();
            this.Hide();
        }
    }
}
