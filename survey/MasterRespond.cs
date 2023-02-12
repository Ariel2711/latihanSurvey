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
    public partial class MasterRespond : Form
    {
        public MasterRespond()
        {
            InitializeComponent();
            load_data();
        }

        Database db = new Database();

        public void load_data()
        {
            DataTable dt = db.getTable("select hr.id_hasil as id, hr.jawaban as jawaban, p.isi as pertanyaan, s.nama as surveyor, rd.nama as responden from hasil_respond hr inner join respond r on r.id_respond = hr.id_respond inner join pertanyaan p on p.id_pertanyaan=hr.id_pertanyaan inner join surveyor s on s.id_surveyor = r.id_surveyor inner join responden rd on rd.id_responden=r.id_responden");
            tblRespond.DataSource = dt;
            DataTable dt2 = db.getTable("select * from kuisioner");
            cmbkuisioner.DataSource = dt2;
            cmbkuisioner.DisplayMember = dt2.Columns["label"].ToString();
            cmbkuisioner.ValueMember = dt2.Columns["id_kuisioner"].ToString();
            DataTable dt3 = db.getTable("select * from responden");
            cmbResponden.DataSource = dt3;
            cmbResponden.DisplayMember = dt3.Columns["nama"].ToString();
            cmbResponden.ValueMember = dt3.Columns["id_responden"].ToString();
            DataTable dt4 = db.getTable($"select * from pertanyaan");
            cmbPertanyaan.DataSource = dt4;
            cmbPertanyaan.DisplayMember = dt4.Columns["isi"].ToString();
            cmbPertanyaan.ValueMember = dt4.Columns["id_pertanyaan"].ToString();
            DataTable dt5 = db.getTable($"select * from surveyor");
            cmbSurveyor.DataSource = dt5;
            cmbSurveyor.DisplayMember = dt5.Columns["nama"].ToString();
            cmbSurveyor.ValueMember = dt5.Columns["id_surveyor"].ToString();

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

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterResponden m = new MasterResponden();
            m.Show();
        }

        private void MasterRespond_Load(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = db.getTable($"select hr.id_hasil as id, hr.jawaban as jawaban, p.isi as pertanyaan, s.nama as surveyor, rd.nama as responden from hasil_respond hr inner join respond r on r.id_respond = hr.id_respond inner join pertanyaan p on p.id_pertanyaan=hr.id_pertanyaan inner join surveyor s on s.id_surveyor = r.id_surveyor inner join responden rd on rd.id_responden=r.id_responden where r.id_kuisioner='{cmbkuisioner.SelectedValue}'");
            tblRespond.DataSource = dt;
            
        }

        private void cmbPertanyaan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = db.getTable($"select hr.id_hasil as id, hr.jawaban as jawaban, p.isi as pertanyaan, s.nama as surveyor, rd.nama as responden from hasil_respond hr inner join respond r on r.id_respond = hr.id_respond inner join pertanyaan p on p.id_pertanyaan=hr.id_pertanyaan inner join surveyor s on s.id_surveyor = r.id_surveyor inner join responden rd on rd.id_responden=r.id_responden where hr.id_pertanyaan = '{cmbPertanyaan.SelectedValue}'");
            tblRespond.DataSource = dt;
        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void cmbResponden_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = db.getTable($"select hr.id_hasil as id, hr.jawaban as jawaban, p.isi as pertanyaan, s.nama as surveyor, rd.nama as responden from hasil_respond hr inner join respond r on r.id_respond = hr.id_respond inner join pertanyaan p on p.id_pertanyaan=hr.id_pertanyaan inner join surveyor s on s.id_surveyor = r.id_surveyor inner join responden rd on rd.id_responden=r.id_responden where r.id_responden = '{cmbResponden.SelectedValue}'");
            tblRespond.DataSource = dt;
        }

        private void cmbSurveyor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = db.getTable($"select hr.id_hasil as id, hr.jawaban as jawaban, p.isi as pertanyaan, s.nama as surveyor, rd.nama as responden from hasil_respond hr inner join respond r on r.id_respond = hr.id_respond inner join pertanyaan p on p.id_pertanyaan=hr.id_pertanyaan inner join surveyor s on s.id_surveyor = r.id_surveyor inner join responden rd on rd.id_responden=r.id_responden where r.id_surveyor = '{cmbSurveyor.SelectedValue}'");
            tblRespond.DataSource = dt;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            load_data();
        }
    }
}
