using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace dairyframma
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }
        int startppoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startppoint += 5;
            MyProgress.Value = startppoint;
            if (MyProgress.Value == 100)
            {
                MyProgress.Value = 0;
                timer1.Stop();
                login Log = new login();
                this.Hide();
                Log.Show();
            }
        }

        private void splash_Load(object sender, EventArgs e)
        {  
            timer1.Start();

        }
    }
}
