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
    public partial class Register : Form
    {
        private readonly KnowledgeEntities _db;
        public Register()
        {
            InitializeComponent();
            _db = new KnowledgeEntities();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string vUser = txtUsername.Text;
            string vPass = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);
            string konfirm_vPass = txtKonfirmasiPassword.Text.Trim();
            var ExistingUsername = _db.tbl_pengguna.FirstOrDefault(q => q.username == vUser);
            if (ExistingUsername != null)
            {
                MessageBox.Show("Username Sudah digunakan!");
            }
            else if (txtPassword.Text != konfirm_vPass)
            {
                MessageBox.Show("Password tidak sama!");
            }else if (txtUsername.Text == String.Empty || txtPassword.Text == String.Empty)
            {
                MessageBox.Show("Anda harus mengisi form secara utuh!");
            }
            else
            {

                var newUser = new tbl_pengguna
                {
                    username = vUser,
                    password = vPass,
                    role = "draft",
                    score = 0
                };
                _db.tbl_pengguna.Add(newUser);
                _db.SaveChanges();
                
                MessageBox.Show("Berhasil terdaftar! tunggu konfirmasi akun ya!");

                var formLogin = new Form1();
                this.Hide();
                formLogin.ShowDialog();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var formLogin = new Form1();
            this.Hide();
            formLogin.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
