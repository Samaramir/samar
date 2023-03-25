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
    public partial class MilkSales : Form
    {
        public MilkSales()
        {
            InitializeComponent();
            FillEmpId();
            Populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samar\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void FillEmpId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select EmpId From EmployeeTb1", Con);
            SqlDataReader Rdr;

            try
            {
                Rdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Columns.Add("EmpId", typeof(int));
                dt.Load(Rdr);
                EmpIdCb.ValueMember = "EmpId";
                EmpIdCb.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            Con.Close();
        }
        private void Populate()
        {
            Con.Open();
            string quary = "Select * From MilkSalesTb1";
            SqlDataAdapter sda = new SqlDataAdapter(quary, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            try
            {
                var ds = new DataSet();
                sda.Fill(ds);
                SalasGV.DataSource = ds.Tables[0];

            }
            catch
            {

            }
            Con.Close();

        }

        private void label19_Click(object sender, EventArgs e)
        {
           cows ob = new cows();
            ob.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
             Mailk_Producation ob = new  Mailk_Producation();
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

        private void MilkSales_Load(object sender, EventArgs e)
        {

        }

        private void QuantityTb_Leave(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(Price.Text) * Convert.ToInt32(QuantityTb.Text) ;
            TotalTb.Text = "" + total;
        }
        private void clear()
        {
            Price.Text = "";
            QuantityTb.Text = "";
            ClientName.Text = "";
            PhoneTb.Text = "";
            TotalTb.Text = "";
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if (EmpIdCb.SelectedIndex == -1 || Price.Text == "" || ClientName.Text == "" || PhoneTb.Text == "" || QuantityTb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into MilkSalesTb1 Values(" + Date.Value.Date + ", '" + Price.Text + "'," + ClientName.Text + "," + PhoneTb.Text + "," +EmpIdCb.SelectedValue.ToString() + " ," + QuantityTb.Text + ",'" + TotalTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Milk Sold Seccessfully");
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

        private void Clear_Click(object sender, EventArgs e)
        {
           clear();
        }
    }
}
