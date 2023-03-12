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
using static System.Windows.Forms.AxHost;

namespace dairyframma
{
    public partial class cows : Form
    {
        public cows()
        {
            InitializeComponent();
            Populate();
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
        private void Populate()
        {
            Con.Open();
            string quary = "Select * From CowTb1";
            SqlDataAdapter sda = new SqlDataAdapter(quary, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            try
            {
                var ds = new DataSet();
                sda.Fill(ds);
                CowsDGV.DataSource = ds.Tables[0];
                
            }
            catch
            {
               
            }
            Con.Close();

        }
        private void Clear()
        {
            CowNameTb.Text = "";
            EarTagTb.Text = "";
            ColorTb.Text = "";
            BreedTb.Text = "";
            AgeTb.Text = "";
            WidgetOfBirthTb.Text = "";
            PasturTb.Text = "";
            Key = 0;
        }
        int age = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowNameTb.Text=="" || EarTagTb.Text=="" ||ColorTb.Text=="" ||BreedTb.Text==""|| AgeTb.Text == ""|| WidgetOfBirthTb.Text == "" || PasturTb.Text=="")
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
                    Populate();
                    Clear();
                    

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
        int Key = 0;
        private void CowsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             CowNameTb.Text = CowsDGV.SelectedRows[0].Cells[1].Value.ToString();
            EarTagTb.Text = CowsDGV.SelectedRows[0].Cells[2].Value.ToString();
            ColorTb.Text = CowsDGV.SelectedRows[0].Cells[3].Value.ToString();
            BreedTb.Text =  CowsDGV.SelectedRows[0].Cells[4].Value.ToString();
           // AgeTb.Text = CowsDGV.SelectedRows[0].Cells[5].Value.ToString();
            WidgetOfBirthTb.Text = CowsDGV.SelectedRows[0].Cells[6].Value.ToString();
          
            PasturTb.Text = CowsDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (CowNameTb.Text == "")
            {
                Key = 0;
                age = 0;
            }
            else
            {
                Key = Convert.ToInt32(CowsDGV.SelectedRows[0].Cells[0].Value.ToString());
                age = Convert.ToInt32(CowsDGV.SelectedRows[0].Cells[5].Value.ToString());
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ( Key==0)
            {
                MessageBox.Show("Select The Cow To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "delete from CowTb1 where CowId="  + Key +";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Deleted Seccessfully");
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
            if (CowNameTb.Text == "" || EarTagTb.Text == "" || ColorTb.Text == "" || BreedTb.Text == "" || AgeTb.Text == "" || WidgetOfBirthTb.Text == "" || PasturTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = " Update CowTb1 set CowName='" + CowNameTb.Text + "', EarTag= '" + EarTagTb.Text + "', Color='" + ColorTb.Text + "',Breed='" + BreedTb.Text + "', Age=" + age + " , WeightAtBirth=" + WidgetOfBirthTb.Text + ", Pasture='" + PasturTb.Text + "' where CowId=" + Key +";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Updated Seccessfully");
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
    }
}
