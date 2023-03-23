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
using System.Windows.Forms.Design;

namespace dairyframma
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            Populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samar\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void Populate()
        {
            Con.Open();
            string quary = "Select * From EmployeeTb1";
            SqlDataAdapter sda = new SqlDataAdapter(quary, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            try
            {
                var ds = new DataSet();
                sda.Fill(ds);
                EmployeeDGV.DataSource = ds.Tables[0];

            }
            catch
            {

            }
            Con.Close();

        }
        private void label25_Click(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            PhoneTb.Text = "";
            EmpName.Text = "";
            AddressTb.Text = "";
            GenCb.SelectedIndex = -1;
            Key = 0;
        }
        private void Savebt_Click(object sender, EventArgs e)
        {
            if (EmpName.Text== "" ||GenCb.SelectedIndex == -1 ||PhoneTb.Text == "" ||AddressTb.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into EmployeeTb1 Values('" + EmpName.Text + "', '" + DOB.Value.Date+ "','" +GenCb.SelectedItem.ToString()+ "','" + PhoneTb.Text + "','" + AddressTb.Text + "' )";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Saved Successfully");
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

        private void Editbt_Click(object sender, EventArgs e)
        {
            if (EmpName.Text == "" || GenCb.SelectedIndex == -1 || PhoneTb.Text == "" || AddressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = " Update EmployeeTb1 set EmpName =" + EmpName.Text + ",  EmpDob='" +DOB.Value.Date + "', Gender=' " + GenCb.SelectedItem.ToString() + "',  Phone=' " + PhoneTb.Text + "',Address='" + AddressTb.Text + "' where EmpId=" + Key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Updated Seccessfully");
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
        int Key = 0;
        private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpName.Text=EmployeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            DOB.Text = EmployeeDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenCb.SelectedItem = EmployeeDGV.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = EmployeeDGV.SelectedRows[0].Cells[4].Value.ToString();
            AddressTb.Text = EmployeeDGV.SelectedRows[0].Cells[5].Value.ToString();
          

            if (EmpName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EmployeeDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void Deletebt_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Employee To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "delete from EmployeeTb1 where EmpId=" + Key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Seccessfully");
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
    }
    }
    

