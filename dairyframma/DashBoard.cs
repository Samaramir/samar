using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            Finance();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            cows ob = new cows();
            ob.Show();
            this.Hide();
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

        private void label21_Click(object sender, EventArgs e)
        {
            MilkSales ob = new MilkSales();
            ob.Show();
            this.Hide();
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {
            Finance ob = new Finance();
            ob.Show();
            this.Hide();

        }

        private void label20_Click(object sender, EventArgs e)
        {
            Breeding ob = new Breeding();
            ob.Show();
            this.Hide();

        }

        private void label17_Click(object sender, EventArgs e)
        {
            cowHealth ob = new cowHealth();
            ob.Show();
            this.Hide();

        }

        private void label18_Click(object sender, EventArgs e)
        {
            Mailk_Producation ob = new Mailk_Producation();
            ob.Show();
            this.Hide();
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samar\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Finance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select sum(IncAmt) from IncomeTb1", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Incleb.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

    
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }
    }
}
