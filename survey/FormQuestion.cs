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
    public partial class FormQuestion : Form
    {
        public FormQuestion()
        {
            InitializeComponent();
            clear_data();
            load_data();
            if (id == 0)
            {
                bunifuButton5.Visible = false;
            }
            else
            {
                bunifuButton5.Visible = true;
            }

        }

        public static int id_pertanyaan { get; set; }

        int id;
        int id_kuisioner;
        Database db = new Database();

        public void clear_data()
        {
            id = 0;
            id_kuisioner = 0;
            id_pertanyaan = 0;
            txtNama.Text = "";
            kuisioner.Text = "Select Kuisioner";
            tipe.Text = "Select Tipe";
        }

        public void load_data()
        {
            DataTable dt = db.getTable("select * from kuisioner");
            kuisioner.DataSource = dt;
            kuisioner.ValueMember = dt.Columns["id_kuisioner"].ToString();
            kuisioner.DisplayMember = dt.Columns["label"].ToString();
            id = MasterQuestion.id;
            if (id == 0)
            {

            }
            else
            {
                DataTable dt2 = db.getTable($"select * from Pertanyaan where id_pertanyaan = '{id}'");
                DataRow dr = dt2.Rows[0];
                txtNama.Text = dr["isi"].ToString();
                kuisioner.SelectedValue = dr["id_kuisioner"].ToString();
                tipe.Text = dr["tipe"].ToString();
            }
        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void tipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterQuestion m = new MasterQuestion();
            m.Show();
        }

        private void FormQuestion_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            clear_data();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Field Empty");
            }
            else
            {
                try
                {
                    db.insert($"delete from pertanyaan where id_pertanyaan = '{id}'");
                    clear_data();
                    MessageBox.Show("success");
                    this.Hide();
                    MasterQuestion ms = new MasterQuestion();
                    ms.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "")
            {
                MessageBox.Show("Field Empty");
            }
            else
            {
                if (id == 0)
                {
                    try
                    {
                        id_kuisioner = int.Parse(kuisioner.SelectedValue.ToString());
                        SqlCommand cmd = new SqlCommand($"insert into pertanyaan (isi,tipe,tgl_create,id_kuisioner) values ('{txtNama.Text}', @tipe, @date, '{id_kuisioner}')");
                        cmd.Parameters.AddWithValue("@date", DateTime.Today);
                        cmd.Parameters.AddWithValue("@tipe", tipe.Text);
                        db.insertCmd(cmd);
                        DataTable dt = db.getTable("select * from pertanyaan ORDER by id_pertanyaan desc");
                        DataRow dr = dt.Rows[0];
                        MessageBox.Show("success");
                        if (tipe.Text == "multiple") {
                            id_pertanyaan = int.Parse(dr["id_pertanyaan"].ToString());
                            this.Hide();
                            FormJawaban f = new FormJawaban();
                            f.Show();
                            
                        }
                        else
                        {
                            this.Hide();
                            MasterQuestion ms = new MasterQuestion();
                            ms.Show();
                        }
                        clear_data();
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
                        id_kuisioner = int.Parse(kuisioner.SelectedValue.ToString());
                        SqlCommand cmd = new SqlCommand($"update [pertanyaan] set isi='{txtNama.Text}', tipe = @tipe, id_kuisioner = '{id_kuisioner}' where id_pertanyaan='{id}'");
                        cmd.Parameters.AddWithValue("@tipe", tipe.Text);
                        db.insertCmd(cmd);
                        MessageBox.Show("success");
                        if (tipe.Text == "multiple")
                        {
                            id_pertanyaan = id;
                            this.Hide();
                            FormJawaban f = new FormJawaban();
                            f.Show();

                        }
                        else
                        {
                            this.Hide();
                            MasterQuestion ms = new MasterQuestion();
                            ms.Show();
                        }
                        clear_data();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
