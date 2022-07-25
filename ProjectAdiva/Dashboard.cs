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
    public partial class Dashboard : Form
    {
        private readonly KnowledgeEntities _db;
        private int vId;
        private int score;
        public Dashboard(int vId, int score)
        {
            InitializeComponent();
            this.vId = vId;
            _db = new KnowledgeEntities();
            this.score = score;

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            var user = _db.tbl_pengguna.SingleOrDefault(a => a.id.Equals(vId));
            var high_score = _db.tbl_pengguna.Max(a => a.score);
            

            label1.Text = $"Selamat Datang {user.username}!";
            label5.Text = $"{user.username}";
            label6.Text = $"{user.score}";
            //leaderboard tertinggi
            label2.Text = high_score.ToString();
            
           
            
        }

        private void kelolaUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ujicobaenkripsi = new UserCobaEnkripsi(vId);
            this.Hide();
            ujicobaenkripsi.ShowDialog();
        }

        private void kuisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var halamankuis = new UserHalamanKuis(vId);
            this.Hide();
            halamankuis.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Yakin ingin logout ?", "Logout", MessageBoxButtons.YesNoCancel,
        MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                var halamanlogin = new Form1();
                this.Hide();
                halamanlogin.ShowDialog();
            }
            
        }

        private void sandiCaesarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var halamanMateri = new UserMateriPersandian(vId);
            this.Hide();
            halamanMateri.ShowDialog();
        }

        private void kelolaBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
