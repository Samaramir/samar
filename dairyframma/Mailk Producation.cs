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
    public partial class Mailk_Producation : Form
    {
        public Mailk_Producation()
        {
            InitializeComponent();
            FillCowId();
            Populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samar\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void FillCowId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CowId From CowTb1", Con);
            SqlDataReader Rdr;
            
            try {
                Rdr = cmd.ExecuteReader();
               
                DataTable dt = new DataTable();
                dt.Columns.Add("CowId", typeof(int));
                dt.Load(Rdr);
                CowIdcb.ValueMember = "CowId";
                CowIdcb.DataSource = dt;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);

            }

            Con.Close();
        }
        private void Populate()
        {
            Con.Open();
            string quary = "Select * From MilkTb";
            SqlDataAdapter sda = new SqlDataAdapter(quary, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            try
            {
                var ds = new DataSet();
                sda.Fill(ds);
                MilkDGV.DataSource = ds.Tables[0];

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

        private void bunifuMaterialTextbox6_OnValueChanged(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(AmMilkTb.Text) + Convert.ToInt32(PmMilkTb.Text) + Convert.ToInt32(NoonMilkTb.Text);
            TotalMilkTb.Text = "" + total;
        }
        private void Clear()
        {
            CowIdcb.SelectedIndex= -1;
            CowNaTb.Text = "";
            AmMilkTb.Text = "";
            NoonMilkTb.Text = "";
            PmMilkTb.Text = "";
            TotalMilkTb.Text = "";
            Date.Text = "";
            Key = 0;

        }

        private void GetCowName()
        {
            Con.Open();
            String query = "select * from CowTb1 Where CowId" + CowIdcb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            
                CowNaTb.Text = dr["CowName"].ToString();
            

            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CowIdcb.SelectedIndex == -1 ||  CowNaTb.Text == "" || AmMilkTb.Text == "" || NoonMilkTb.Text == "" || PmMilkTb.Text == "" || TotalMilkTb.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into MilkTb Values(" + CowIdcb.SelectedValue.ToString() + ", '" +CowNaTb.Text  + "'," + AmMilkTb.Text + "," + NoonMilkTb.Text + "," + PmMilkTb.Text + " ," + TotalMilkTb.Text + ",'"+Date.Value.Date+"')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Milk Saved Seccessfully");
                    Con.Close();
                    Populate();
                    Clear();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void MilkDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           CowIdcb.SelectedValue = MilkDGV.SelectedRows[0].Cells[1].Value.ToString();
            CowNaTb.Text = MilkDGV.SelectedRows[0].Cells[2].Value.ToString();
            AmMilkTb.Text = MilkDGV.SelectedRows[0].Cells[3].Value.ToString();
            NoonMilkTb.Text = MilkDGV.SelectedRows[0].Cells[4].Value.ToString();
            PmMilkTb.Text = MilkDGV.SelectedRows[0].Cells[5].Value.ToString();
            TotalMilkTb.Text = MilkDGV.SelectedRows[0].Cells[6].Value.ToString();
            Date.Text = MilkDGV.SelectedRows[0].Cells[7].Value.ToString();

            if (CowNaTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(MilkDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void CowIdcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void CowNameTb_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void CowIdcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void PmMilkTb_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void PmMilkTb_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (Key == 0)
            {
                MessageBox.Show("Select The Milk product To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "delete from MilkTb1 where MId=" + Key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Seccessfully");
                    Con.Close();
                    Populate();
                    Clear();



                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CowIdcb.SelectedIndex == -1 || CowNaTb.Text == "" || AmMilkTb.Text == "" || NoonMilkTb.Text == "" || PmMilkTb.Text == "" || TotalMilkTb.Text == "")
                {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = " Update MilkTb1 set CowName='" + CowNaTb.Text + "', AmMilk= " + AmMilkTb.Text + ", NoonMilk= " + NoonMilkTb.Text + ",PmMilk=" + PmMilkTb.Text + ", TotalMilk=" + TotalMilkTb + " ,  DateProd= '" + Date.Value.Date +  "' where MId=" + Key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Updated Seccessfully");
                    Con.Close();
                    Populate();
                    Clear();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}