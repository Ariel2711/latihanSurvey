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
    public partial class MasterSurveyor : Form
    {
        public MasterSurveyor()
        {
            InitializeComponent();
            load_data();
        }

        Database db = new Database();

        public void load_data()
        {
            DataTable dt = db.getTable("select id_surveyor as ID, nama as nama, telepon as Telepon, id_user as ID_user from surveyor");
            tblSurvey.DataSource = dt;
        }

        public static int id { get; set; }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterQuestion mq = new MasterQuestion();
            mq.Show();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterSurvey ms = new MasterSurvey();
            ms.Show();
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void MasterSurveyor_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSurveyor fs = new FormSurveyor();
            fs.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                DataTable dt = db.getTable("select id_surveyor as ID, nama as nama, telepon as Telepon, id_user as ID_user from surveyor");
                tblSurvey.DataSource = dt;
            }
            else
            {
                DataTable dt = db.getTable($"select id_surveyor as ID, nama as nama, telepon as Telepon, id_user as ID_User from surveyor where id_surveyor='{txtSearch.Text}' OR nama='{txtSearch.Text}'");
                tblSurvey.DataSource = dt;
            }
        }

        private void tblSurvey_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tblSurvey_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.RowIndex;
            id = int.Parse(tblSurvey.Rows[i].Cells["ID_User"].Value.ToString());
            this.Hide();
            FormSurveyor fs = new FormSurveyor();
            fs.Show();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard d = new Dashboard();
            d.Show();
        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
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
