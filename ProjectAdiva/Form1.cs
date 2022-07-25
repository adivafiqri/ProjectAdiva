using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAdiva
{
    public partial class Form1 : Form
    {
        private readonly KnowledgeEntities _db;
        public Form1()
        {
            InitializeComponent();
            _db = new KnowledgeEntities();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var user = Login(txtUsername.Text.ToLower(), txtPassword.Text);
            if (txtUsername.Text == String.Empty || txtPassword.Text == String.Empty)
            {
                MessageBox.Show("Anda harus mengisi form secara utuh!");
            }
            else if (user == null)
            {
                MessageBox.Show("Username/Password Salah!");
            }
            else if (user.role == "draft")
            {
                MessageBox.Show($"Akun anda sedang direview admin!");
            }
            else if(user.role == "admin")
            {
                MessageBox.Show($"Selamat datang {user.username}!");
                var dashboardAdmin = new DashboardAdmin();
                this.Hide();
                dashboardAdmin.ShowDialog();
            }
            else
            {
                
                MessageBox.Show($"Selamat datang {user.username}!");
                var dashboard = new Dashboard(user.id, user.score);
                this.Hide();
                dashboard.ShowDialog();
            }
        }

        private tbl_pengguna Login(string username, string password)
        {

            var user = _db.tbl_pengguna.SingleOrDefault(a => a.username.Equals(username));
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.password))
                {
                    return user;
                }

            }
            return null;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            var formRegister = new Register();
            this.Hide();
            formRegister.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
