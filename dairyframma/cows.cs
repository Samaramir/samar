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
    public partial class cows : Form
    {
        public cows()
        {
            InitializeComponent();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

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

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
            DashBoard ob = new DashBoard();
            ob.Show();
            this.Hide();
        }
    }
}
