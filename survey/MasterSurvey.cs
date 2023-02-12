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

namespace survey
{
    public partial class MasterSurvey : Form
    {
        public MasterSurvey()
        {
            InitializeComponent();
            load_data();
        }

        Database db = new Database();

        public void load_data()
        {
            DataTable dt = db.getTable("select id_kuisioner as ID, label as Label, tgl_create as Tanggal from kuisioner");
            tblSurvey.DataSource = dt;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuVSlider1_Scroll(object sender, Utilities.BunifuSlider.BunifuVScrollBar.ScrollEventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if(txtLabel.Text == "")
            {
                MessageBox.Show("Field Empty");
            }
            else
            {   
                if (id == 0)
                {
                    try
                    {
                        string query = $"insert into kuisioner (label,tgl_create) values ('{txtLabel.Text}',@tgl)";
                        SqlCommand cmd = new SqlCommand(query);
                        cmd.Parameters.AddWithValue("@tgl", DateTime.Today);
                        db.insertCmd(cmd);
                        txtLabel.Text = "";
                        id = 0;
                        load_data();
                        MessageBox.Show("success");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    try
                    {
                        string query = $"update kuisioner set label='{txtLabel.Text}' where id_kuisioner='{id}'";
                        SqlCommand cmd = new SqlCommand(query);
                        db.insertCmd(cmd);
                        txtLabel.Text = "";
                        id = 0;
                        load_data();
                        MessageBox.Show("success");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                DataTable dt = db.getTable("select id_kuisioner as ID, label as Label, tgl_create as Tanggal from kuisioner");
                tblSurvey.DataSource = dt;
            }
            else
            {
                try
                {
                    DataTable dt = db.getTable($"select id_kuisioner as ID, label as Label, tgl_create as Tanggal from kuisioner where id_kuisioner = '{int.Parse(txtSearch.Text)}' OR label = '{txtSearch.Text}'");
                    tblSurvey.DataSource = dt;
                }
                catch
                {
                    MessageBox.Show("Fail");
                }
            }
        }

        int id;

        private void tblSurvey_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            

        }

        private void tblSurvey_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.RowIndex;
            id = int.Parse(tblSurvey.Rows[i].Cells[0].Value.ToString());
            txtLabel.Text = tblSurvey.Rows[i].Cells[1].Value.ToString();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (txtLabel.Text == "")
            {
                MessageBox.Show("Field Empty");
            }
            else
            {
                try
                {
                    if(MessageBox.Show("are you sure you want to delete survey?", "Delete Survey", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        string query = $"delete from kuisioner where id_kuisioner='{id}'";
                        SqlCommand cmd = new SqlCommand(query);
                        db.insertCmd(cmd);
                        txtLabel.Text = "";
                        id = 0;
                        load_data();
                        MessageBox.Show("success");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterQuestion mq = new MasterQuestion();
            mq.Show();
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            
        }

        private void MasterSurvey_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterSurveyor mq = new MasterSurveyor();
            mq.Show();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard d = new Dashboard();
            d.Show();
        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterResponden m = new MasterResponden();
            m.Show();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterRespond m = new MasterRespond();
            m.Show();
        }
    }
}
