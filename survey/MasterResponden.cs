using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace survey
{
    public partial class MasterResponden : Form
    {
        public MasterResponden()
        {
            InitializeComponent();
            load_data();
        }

        Database db = new Database();

        public void load_data()
        {
            DataTable dt = db.getTable("select * from responden");
            tblResponden.DataSource = dt;
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard d = new Dashboard();
            d.Show();
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterSurvey m = new MasterSurvey();
            m.Show();
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterQuestion m = new MasterQuestion();
            m.Show();
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterSurveyor m = new MasterSurveyor();
            m.Show();
        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterRespond m = new MasterRespond();
            m.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                DataTable dt = db.getTable("select * from responden");
                tblResponden.DataSource = dt;
            }
            else
            {
                DataTable dt = db.getTable($"select * from responden where nama = '{txtSearch.Text}'");
                tblResponden.DataSource = dt;
            }
        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }
    }
}
