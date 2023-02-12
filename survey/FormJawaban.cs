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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace survey
{
    public partial class FormJawaban : Form
    {
        public FormJawaban()
        {
            InitializeComponent();
            idpertanyaan = FormQuestion.id_pertanyaan;
            load_data();
        }

        int idpertanyaan;
        int idjawaban;
        Database db = new Database();

        public void load_data()
        {
            
            DataTable dt = db.getTable($"select * from pilihan_jawaban where id_pertanyaan = '{idpertanyaan}'");
            tblJawaban.DataSource = dt;
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterQuestion f = new MasterQuestion();
            f.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            txtJawaban.Text = "";
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (txtJawaban.Text == "")
            {
                MessageBox.Show("Field Empty");
            }
            else
            {
                if (idjawaban == 0)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand($"insert into pilihan_jawaban (isi,id_pertanyaan) values ('{txtJawaban.Text}', '{idpertanyaan}')");
                        db.insertCmd(cmd);
                        txtJawaban.Text = "";
                        load_data();
                        MessageBox.Show("success");
                        idjawaban = 0;

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
                        SqlCommand cmd = new SqlCommand($"update [pilihan_jawaban] set isi='{txtJawaban.Text}' where id_jawaban = '{idjawaban}'");
                        db.insertCmd(cmd);
                        txtJawaban.Text = "";
                        idjawaban = 0;
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

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            if (idjawaban == 0)
            {
                MessageBox.Show("Invalid");
            }
            else
            {
                try
                {
                    db.insert($"delete from pilihan_jawaban where id_jawaban = '{idjawaban}'");
                    txtJawaban.Text = "";
                    MessageBox.Show("success");
                    idjawaban = 0;
                    load_data();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void tblJawaban_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.RowIndex;
            idjawaban = int.Parse(tblJawaban.Rows[i].Cells[0].Value.ToString());
            txtJawaban.Text = tblJawaban.Rows[i].Cells[1].Value.ToString();
        }
    }
}
