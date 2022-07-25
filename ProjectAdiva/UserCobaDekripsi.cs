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
    public partial class UserCobaDekripsi : Form
    {
        private int vId;
        private readonly KnowledgeEntities _db;
        public UserCobaDekripsi(int vId)
        {
            InitializeComponent();
            this.vId = vId;
            _db = new KnowledgeEntities();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            int key = Convert.ToInt32(txtKey.Text);
            string cipher = txtCipher.Text;
            txtPlainteks.Text = ceasercipher.decrypt(cipher, key); //pass the data to output text 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCipher.Clear();
            txtKey.Clear();
            txtPlainteks.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var user = _db.tbl_pengguna.SingleOrDefault(a => a.id.Equals(vId));
           
            var dashboard = new Dashboard(vId, user.score);
            this.Hide();
            dashboard.ShowDialog();
        }

        private void txtCipher_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows only letters
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void encodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ujicobaenkripsi = new UserCobaEnkripsi(vId);
            this.Hide();
            ujicobaenkripsi.ShowDialog();
        }

        private void UserCobaDekripsi_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

