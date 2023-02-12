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
    public partial class FormSurveyor : Form
    {
        public FormSurveyor()
        {
            InitializeComponent();
            load_data();
            if(id == 0)
            {
                bunifuButton5.Visible = false;
            }
            else
            {
                bunifuButton5.Visible = true;
            }
            
        }

        string foto;
        int id;
        int iduser;

        public void load_data()
        {
            id = MasterSurveyor.id;
            if (id == 0)
            {

            }
            else
            {
                
                DataTable dt = db.getTable($"select * from surveyor where id_user = '{id}'");
                DataRow dr = dt.Rows[0];
                pictureBox1.ImageLocation = dr["image"].ToString();
                txtNama.Text = dr["nama"].ToString();
                txtNomor.Text = dr["telepon"].ToString();
            }
        }

        public void clear_data()
        {
            pictureBox1.ImageLocation = "";
            id = 0;
            iduser = 0;
            txtNama.Text = "";
            txtNomor.Text = "";
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "all files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foto = dialog.FileName.ToString();
                pictureBox1.ImageLocation = foto;
            }
        }

        Database db = new Database();

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtNomor.Text == "" || foto == "")
            {
                MessageBox.Show("Field Empty");
            }
            else
            {
                if(id == 0)
                {
                    try
                    {
                        db.insert($"insert into [user] (username,password,role) values ('{txtNama.Text}', '{int.Parse(txtNomor.Text)}', '{"surveyor"}')");
                        DataTable dt = db.getTable("select * from [user] order by id_user desc");
                        DataRow dr = dt.Rows[0];
                        iduser = int.Parse(dr["id_user"].ToString());
                        SqlCommand cmd = new SqlCommand($"insert into surveyor (nama,image,telepon,id_user) values ('{txtNama.Text}', '{foto}', '{int.Parse(txtNomor.Text)}', '{iduser}')");
                        db.insertCmd(cmd);
                        clear_data();
                        MessageBox.Show("success");
                        this.Hide();
                        MasterSurveyor ms = new MasterSurveyor();
                        ms.Show();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    try
                    {
                        db.insert($"update [user] set username='{txtNama.Text}' where id_user = '{id}'");
                        SqlCommand cmd = new SqlCommand($"update [surveyor] set nama='{txtNama.Text}', telepon = @telepon where id_user='{id}'");
                        cmd.Parameters.AddWithValue("@telepon", int.Parse(txtNomor.Text));
                        db.insertCmd(cmd);
                        clear_data();
                        MessageBox.Show("success");
                        this.Hide();
                        MasterSurveyor ms = new MasterSurveyor();
                        ms.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
            }
        }

        private void FormSurveyor_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            clear_data();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtNomor.Text == "" || foto == "")
            {
                MessageBox.Show("Field Empty");
            }
            else
            {
                try
                {
                    db.insert($"delete from [user] where id_user = '{id}'");
                    db.insert($"delete from surveyor where id_user = '{id}'");
                    clear_data();
                    MessageBox.Show("success");
                    this.Hide();
                    MasterSurveyor ms = new MasterSurveyor();
                    ms.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterSurveyor ms = new MasterSurveyor();
            ms.Show();
        }
    }
}
