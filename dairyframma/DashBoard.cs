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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            cows ob = new cows();
            ob.Show();
            this.Hide();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            Mailk_Producation ob = new Mailk_Producation();
            ob.Show();
            this.Hide();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
             cowHealth ob = new cowHealth();
            ob.Show();
            this.Hide();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            Breeding ob = new Breeding();
            ob.Show();
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            MilkSales ob = new MilkSales();
            ob.Show();
            this.Hide();
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
            Finance ob = new Finance();
            ob.Show();
            this.Hide();
        }
    }
}
