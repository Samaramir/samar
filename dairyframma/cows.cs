using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace dairyframma
{
    public partial class cows : Form
    {
        public cows()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samar\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label21_Click(object sender, EventArgs e)
        {
            MilkSales ob = new MilkSales();
            ob.Show();
            this.Hide();
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

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
           
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

        private void label22_Click(object sender, EventArgs e)
        {
            Finance ob = new Finance();
            ob.Show();
            this.Hide();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            DashBoard ob = new DashBoard();
            ob.Show();
            this.Hide();
        }

        private void bunifuMaterialTextbox4_OnValueChanged(object sender, EventArgs e)
        {

        }
        int age = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowNameTb.Text=="" || EarTagTb.Text=="" ||ColorTb.Text=="" ||BreedTb.Text==""||WidgetOfBirthTb.Text==""||AgeTb.Text==""||PasturTb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into CowTb1 Values('" + CowNameTb.Text + "', '" + EarTagTb.Text + "','" + ColorTb.Text + "','" + BreedTb.Text + "',"+age+" ,"+ WidgetOfBirthTb.Text+ ",'" + PasturTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Saved Seccessfully");
                    Con.Close();

                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DOFDate_ValueChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DOFDate.Value.Date - DateTime.Today.Date).Days) / 365;
             
        }

        private void DOFDate_MouseLeave(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DOFDate.Value.Date - DateTime.Today.Date).Days) / 365;
            AgeTb.Text = "" + age;
        }
    }
}
