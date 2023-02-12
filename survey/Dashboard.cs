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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            load_data();
            load_chart();
        }

        Database db = new Database();

        public void load_data()
        {
            try
            {
                DataTable dt = db.getTable("select count(id_kuisioner) as total from kuisioner");
                DataRow dr = dt.Rows[0];
                survey.Text = dr["total"].ToString();
            }
            catch
            {
                survey.Text = "0";
            }
            try
            {
                DataTable dt = db.getTable("select count(id_hasil) as total from hasil_respond");
                DataRow dr = dt.Rows[0];
                respond.Text = dr["total"].ToString();
            }
            catch
            {
                respond.Text = "0";
            }
            try
            {
                DataTable dt = db.getTable("select count(id_surveyor) as total from surveyor");
                DataRow dr = dt.Rows[0];
                surveyor.Text = dr["total"].ToString();
            }
            catch
            {
                surveyor.Text = "0";
            }
            try
            {
                DataTable dt = db.getTable("select count(id_responden) as total from responden");
                DataRow dr = dt.Rows[0];
                responden.Text = dr["total"].ToString();
            }
            catch
            {
                responden.Text = "0";
            }
        }

        public void load_chart()
        {
            DataTable dt = db.getTable("select count(hr.id_hasil) as total, r.tgl_create from hasil_respond hr inner join respond r on r.id_respond=hr.id_respond group by tgl_create");
            chart1.Series["Tanggal"].Points.Clear();
            chart1.DataSource = dt;
            chart1.Series["Tanggal"].XValueMember = "tgl_create";
            chart1.Series["Tanggal"].YValueMembers = "total";
            chart1.Invalidate();
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterSurvey ms = new MasterSurvey();
            ms.Show();
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterQuestion ms = new MasterQuestion();
            ms.Show();
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterSurveyor ms = new MasterSurveyor();
            ms.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void bunifuChartCanvas1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterResponden m = new MasterResponden();
            m.Show();
        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterRespond m = new MasterRespond();
            m.Show();
        }
    }
}
