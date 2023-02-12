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
    public partial class MasterQuestion : Form
    {
        public MasterQuestion()
        {
            InitializeComponent();
            load_data();
            id = 0;
        }

        Database db = new Database();

        public static int id { get; set; }

        public void load_data()
        {
            DataTable dt = db.getTable("select * from pertanyaan");
            tblSurvey.DataSource = dt;
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterSurveyor ms = new MasterSurveyor();
            ms.Show();
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterSurvey ms = new MasterSurvey();
            ms.Show();
        }

        private void MasterQuestion_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                DataTable dt = db.getTable("select * from pertanyaan");
                tblSurvey.DataSource = dt;
            }
            else
            {
                DataTable dt = db.getTable($"select * from pertanyaan where id_pertanyaan = '{int.Parse(txtSearch.Text)}' OR isi = '{txtSearch.Text}' OR tipe ='{txtSearch.Text}'");
                tblSurvey.DataSource = dt;
            }
        }

        private void tblSurvey_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.RowIndex;
            id = int.Parse(tblSurvey.Rows[i].Cells[0].Value.ToString());
            this.Hide();
            FormQuestion fq = new FormQuestion();
            fq.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormQuestion fq = new FormQuestion();
            fq.Show();
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

        private void tblSurvey_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
