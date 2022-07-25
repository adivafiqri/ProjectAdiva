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
    public partial class AdminManageUser : Form
    {
        private readonly KnowledgeEntities _db;
        public AdminManageUser()
        {
            InitializeComponent();
            _db = new KnowledgeEntities();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            string vUsername = textBox1.Text;
            string vPassword = textBox2.Text;
            string vRole = comboBox1.Text;


            var ExistingUsername = _db.tbl_pengguna.Select(q => q.username).ToList();
            if (ExistingUsername.Contains(vUsername))
            {
                MessageBox.Show("Username duplikat!");
            }

            var newUsers = new tbl_pengguna
            {
                username = vUsername,
                password = vPassword,
                role = vRole
            };
            _db.tbl_pengguna.Add(newUsers);
            _db.SaveChanges();
            MessageBox.Show("Akun berhasil di tambah!");
            this.Close();
            AdminManageUser main = new AdminManageUser();
            main.Show();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            string vUsername = textBox1.Text;
            var Ditem = _db.tbl_pengguna.FirstOrDefault(q => q.username == vUsername);
            if (Ditem != null)
            {
                _db.tbl_pengguna.Remove(Ditem);
                _db.SaveChanges();
                MessageBox.Show("Item telah terhapus");
                this.Close();
                AdminManageUser main = new AdminManageUser();
                main.Show();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string vUsername = textBox1.Text;
            
            string VRole = comboBox1.Text;
            int vId = int.Parse(txtId.Text);


            _db.tbl_pengguna.First(q => q.id == vId).username = vUsername;
            
            _db.tbl_pengguna.First(q => q.id == vId).role = VRole;
            _db.SaveChanges();
            MessageBox.Show("Akun berhasil di edit!");
            this.Close();
            AdminManageUser main = new AdminManageUser();
            main.Show();
        }

        private void AdminManageUser_Load(object sender, EventArgs e)
        {
            var dataPengguna = _db.tbl_pengguna.Select(q => new
            {
                q.id,
                q.username,
                q.password,
                q.role
            }).ToList();

            dataGridView1.DataSource = dataPengguna;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //saat klik
            try
            {
                if (e.RowIndex != -1)
                {
                    if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                    {
                        var id = (int)dataGridView1.CurrentRow.Cells["id"].Value;
                        var username = (string)dataGridView1.CurrentRow.Cells["username"].Value;
                        var password = (string)dataGridView1.CurrentRow.Cells["password"].Value;
                        var role = (string)dataGridView1.CurrentRow.Cells["role"].Value;
                        textBox1.Text = username;
                        textBox2.Text = password;
                        comboBox1.Text = role;
                        txtId.Text = id.ToString();

                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan: " + ex);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                    {
                        var id = (int)dataGridView1.CurrentRow.Cells["id"].Value;
                        var username = (string)dataGridView1.CurrentRow.Cells["username"].Value;
                        var password = (string)dataGridView1.CurrentRow.Cells["password"].Value;
                        var role = (string)dataGridView1.CurrentRow.Cells["role"].Value;

                        textBox1.Text = username;
                        textBox2.Text = password;
                        comboBox1.Text = role;
                        txtId.Text = id.ToString();

                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan: " + ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            DashboardAdmin dshbrd = new DashboardAdmin();
            dshbrd.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
