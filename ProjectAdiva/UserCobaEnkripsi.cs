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
    public partial class UserCobaEnkripsi : Form
    {
        private readonly KnowledgeEntities _db;
        private int vId;
        public UserCobaEnkripsi(int vId)
        {
            InitializeComponent();
            this.vId = vId;
            _db = new KnowledgeEntities();
        }

        private void UserCobaEnkripsi_Load(object sender, EventArgs e)
        {

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            int key = Convert.ToInt32(txtKey.Text);
            string message = txtPlainteks.Text;
            txtCipher.Text = ceasercipher.encrypt(message, key); //pass the data to output text 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCipher.Clear();
            txtKey.Clear();
            txtPlainteks.Clear();
        }

        private void txtKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPlainteks_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows only letters
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            int key = Convert.ToInt32(txtKey.Text);
            string cipher = txtCipher.Text;
            txtPlainteks.Text = ceasercipher.decrypt(cipher, key); //pass the data to output text 
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            var user = _db.tbl_pengguna.SingleOrDefault(a => a.id.Equals(vId));
            
            var dashboard = new Dashboard(vId, user.score);
            this.Hide();
            dashboard.ShowDialog();
        }

        private void encodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ujicobaenkripsi = new UserCobaEnkripsi(vId);
            this.Hide();
            ujicobaenkripsi.ShowDialog();
        }

        private void decodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ujicobadekripsi = new UserCobaDekripsi(vId);
            this.Hide();
            ujicobadekripsi.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

public class ceasercipher
{
    public static string encrypt(string text, int key)
    {
        string result = " ";

        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsUpper(text[i]))
            {

                result += Convert.ToChar(Convert.ToInt32(text[i] + key - 65) % 26 + 65);
            }
            else
            {
                result += Convert.ToChar(Convert.ToInt32(text[i] + key - 97) % 26 + 97);
            }

        }
        return result;
    }

    public static string decrypt(string cipher, int key)
    {
        string result = " ";

        for (int i = 0; i < cipher.Length; i++)
        {
            if (char.IsUpper(cipher[i]))
            {

                result += Convert.ToChar(Convert.ToInt32(cipher[i] - key - 65) % 26 + 65);
            }
            else
            {
                result += Convert.ToChar(Convert.ToInt32(cipher[i] - key - 97) % 26 + 97);
            }

        }
        return result;
    }
}
