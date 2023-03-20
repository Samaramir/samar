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
    }
    }
}
