using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace ProjectAdiva
{
    public partial class UserHalamanKuis : Form
    {
        int seconds = 0;
        private SoundPlayer _benar;
        private SoundPlayer _salah;

        private int vId;
        
        public UserHalamanKuis(int vId)
        {
            InitializeComponent();
            this.vId = vId;
            _benar = new SoundPlayer("correct.wav");
            _salah = new SoundPlayer("wrong.wav");

        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            
            lblScreen.Text = seconds--.ToString();
            if(seconds < 0)
            {
                countdownTimer.Stop();
                MessageBox.Show("Waktu anda telah habis !");
                var halamankuis2 = new UserHalamanKuis2(vId, int.Parse(label6.Text));
                this.Hide();
                halamankuis2.ShowDialog();
            }

        }

        private void UserHalamanKuis_Load(object sender, EventArgs e)
        {
            seconds = 10;
            countdownTimer.Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _benar.Play();
            button2.BackColor = Color.YellowGreen;
            label6.Text = "1";
            countdownTimer.Stop();
            MessageBox.Show("Selamat jawaban anda benar!");
            var halamankuis2 = new UserHalamanKuis2(vId, int.Parse(label6.Text));
            this.Hide();
            halamankuis2.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var halamankuis2 = new UserHalamanKuis2(vId,int.Parse(label6.Text));
            this.Hide();
            halamankuis2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //jawaban salah
            _salah.Play();
            button4.BackColor = Color.Red;
            button2.BackColor = Color.YellowGreen;
            countdownTimer.Stop();
            MessageBox.Show("Maaf jawaban anda salah!");
            button2.Enabled = false;
            button1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //jawaban salah
            _salah.Play();
            button3.BackColor = Color.Red;
            button2.BackColor = Color.YellowGreen;
            countdownTimer.Stop();
            MessageBox.Show("Maaf jawaban anda salah!");
            button2.Enabled = false;
            button1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //jawaban salah
            _salah.Play();
            button5.BackColor = Color.Red;
            button2.BackColor = Color.YellowGreen;
            countdownTimer.Stop();
            MessageBox.Show("Maaf jawaban anda salah!");
            button2.Enabled = false;
            button1.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


