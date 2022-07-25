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
    public partial class DashboardAdmin : Form
    {
        private readonly KnowledgeEntities _db;
        public DashboardAdmin()
        {
            InitializeComponent();
            _db = new KnowledgeEntities();
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

        private void kelolaBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kelolaUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var HalManageuser = new AdminManageUser();
            this.Hide();
            HalManageuser.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DashboardAdmin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
