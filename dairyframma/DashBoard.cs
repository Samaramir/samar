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
using static System.Windows.Forms.LinkLabel;

namespace dairyframma
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            Finance();
            LogistecCalc();
            getMax();
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
            SqlDataAdapter sda1 = new SqlDataAdapter("Select sum(ExpAmount) from ExpenditureTb1", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int inc, Exp;
            double  bal;
            inc = Convert.ToInt32(dt.Rows[0][0].ToString());
            Incleb.Text ="Rs" + dt.Rows[0][0].ToString();
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            Exp = Convert.ToInt32(dt1.Rows[0][0].ToString());
            bal = inc - Exp;
            Explb.Text = "Rs" + dt1.Rows[0][0].ToString();
            Ballb.Text = "Rs" + bal;
            Con.Close();
        }
        private void LogistecCalc()
        {
            String Query = "Select count(*) from CowTbl";
            LCow.Text = Con.GetData(Query).Rows[0][0].ToString();

            String Query2 = "Select sum(TotalMilk) from MilkTbl";
            LMilk.Text = Con.GetData(Query2).Rows[0][0].ToString() + " Litters";

            String Query3 = "Select count(*) from EmpTbl";
            LEmp.Text = Con.GetData(Query3).Rows[0][0].ToString();
        }

        private void getMax()
        {
            String Query = "Select Max(IncAmount) from IncomeTbl";
            SMax.Text = "$ " + Con.GetData(Query).Rows[0][0].ToString();

            String Query2 = "Select Max(ExpAmount) from ExpenditureTbl";
            ExpMax.Text = "$ " + Con.GetData(Query2).Rows[0][0].ToString();
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
