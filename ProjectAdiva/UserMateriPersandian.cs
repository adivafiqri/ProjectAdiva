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
    public partial class UserMateriPersandian : Form
    {
        private int vId;
        public UserMateriPersandian(int vId)
        {
            InitializeComponent();
            this.vId = vId;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserMateriPersandian_Load(object sender, EventArgs e)
        {

        }

        private void kelolaUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ujicobaenkripsi = new UserCobaEnkripsi(vId);
            this.Hide();
            ujicobaenkripsi.ShowDialog();
        }

        private void sandiCaesarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var halamanMateri = new UserMateriPersandian(vId);
            this.Hide();
            halamanMateri.ShowDialog();
        }

        private void kuisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var halamankuis = new UserHalamanKuis(vId);
            this.Hide();
            halamankuis.ShowDialog();
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
    }
}
