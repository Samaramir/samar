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
    public partial class cowHealth : Form
    {
        public cowHealth()
        {
            InitializeComponent();
            FillCowId();
            Populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samar\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void FillCowId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CowId form CowTb1", Con);
            SqlDataReader Rdr;
            try
            {
                Rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("CowId", typeof(int));
                dt.Load(Rdr);
                CowIdCb.ValueMember = "CowId";
                CowIdCb.DataSource = dt;
            }
            catch
            {
            }

            Con.Close();
        }
        private void Populate()
        {
            Con.Open();
            string quary = "Select * From HealthTb1";
            SqlDataAdapter sda = new SqlDataAdapter(quary, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            try
            {
                var ds = new DataSet();
                sda.Fill(ds);
                HealthyDGV.DataSource = ds.Tables[0];

            }
            catch
            {

            }
            Con.Close();

        }
        private void GetCowName()
        {
            Con.Open();
            String query = "select * from CowTb1 Where CowId" + CowIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)

                CowNameTb.Text = dr["CowName"].ToString();


            Con.Close();
        }
        private void clear()
        {
            CowNameTb.Text = "";
            EventTb.Text = "";
            CostTb.Text = "";
            DiagnosisTb.Text = "";
            VetNameTb.Text = "";
            TreatmentTb.Text="";
        }

        private void cowHealth_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label18_Click(object sender, EventArgs e)
        {

            Mailk_Producation ob = new Mailk_Producation();
            ob.Show();
            this.Hide();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
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

        private void label19_Click(object sender, EventArgs e)
        {
            cows ob = new cows();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }
       

        private void Savebt_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || EventTb.Text == "" || CostTb.Text == "" || VetNameTb.Text == "" || DiagnosisTb.Text == ""||TreatmentTb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into HealthTb1 Values(" + CowIdCb.SelectedValue.ToString() + ", '" + CowNameTb.Text + "','" + Date.Value.Date + "','" + EventTb.Text + "','" + DiagnosisTb.Text + "' ,'" + TreatmentTb.Text + "','" + CostTb.Text + "','" + VetNameTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Healthy Issue Saved");
                    Con.Close();
                    Populate();
                    clear();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
