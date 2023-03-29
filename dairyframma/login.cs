using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace dairyframma
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samar\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            if (UserName.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Enter UserName And Password");
            }
            else
            {
                if (RoleCb.SelectedIndex > -1)
                {
                    if (RoleCb.SelectedItem.ToString() == "Admin")
                    {
                        if (UserName.Text == "Admin" || Password.Text == "Admin")
                        {
                            Employees emp = new Employees();
                            emp.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("If You are Admin, Enter The Correct Id and Password");
                        }
                    }
                    else
                    {
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from EmployeeTbl where EmpName='" + UserName.Text + "'and EmpPass='" + Password.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            cows cow = new cows();
                            cow.Show();
                            this.Hide();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong UserName or Password");
                        }
                        con.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Select Role");
                }
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            UserName.Text = "";
            Password.Text = ""
        }
    }
}
