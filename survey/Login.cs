using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace survey
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            loadCaptchaImage();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        Database db = new Database();

        public static string Hashpw(string input)
        {
            var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

        int number;
        private void loadCaptchaImage()
        {
            Random r1 = new Random();
            number = r1.Next(1001, 10000);
            labelCaptcha.Text = number.ToString();
            labelCaptcha.Font = new Font(labelCaptcha.Font.FontFamily, 24, FontStyle.Bold);
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            if (txtPassword.UseSystemPasswordChar == true)
            {
                bunifuLabel5.Text = "Show";
            }
            else
            {
                bunifuLabel5.Text = "Hide";
            }
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Field Empty!");
                }
                else
                {
                    DataTable dt = db.getTable($"select * from [user] where username = '{txtUsername.Text}'");
                    if (dt.Rows.Count < 1)
                    {
                        MessageBox.Show("User not found");
                    }
                    else
                    {
                        DataRow dr = dt.Rows[0];
                        var hashpw = Hashpw(txtPassword.Text);
                        if (txtPassword.Text != dr["password"].ToString())
                        {
                            MessageBox.Show("Password don't match");
                        }
                        else
                        {
                            if (int.Parse(txtCaptcha.Text) == number)
                            {
                                if (dr["role"].ToString().ToLower() == "admin")
                                {
                                    UserClass.id = int.Parse(dr["id_user"].ToString());
                                    UserClass.name = dr["username"].ToString();
                                    UserClass.role = dr["role"].ToString();
                                    this.Hide();
                                    Dashboard ms = new Dashboard();
                                    ms.Show();
                                }

                                else
                                {
                                    MessageBox.Show("You don't have permission");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Captcha invalid");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bunifuGradientPanel1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
