using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace APPD_layout
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
            progressBar1.Maximum = 85;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frm1 = new Login();
            frm1.Show();
        }
        private void Form5_Load(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            progressBar1.Value = CheckStrength(textBox2.Text);
            if (progressBar1.Value > 70)
            {
                progressBar1.ForeColor = Color.YellowGreen;
                label1.Text = "Password is very strong.";
                label1.ForeColor = Color.YellowGreen;
            }
            else if (progressBar1.Value > 50 && progressBar1.Value <= 70)
            {
                progressBar1.ForeColor = Color.YellowGreen;
                label1.Text = "Password is fairly strong.";
                label1.ForeColor = Color.LightGray;
            }
            else if (progressBar1.Value > 30 && progressBar1.Value <= 50)
            {
                progressBar1.ForeColor = Color.Yellow;
                label1.Text = "Password is acceptable.";
                label1.ForeColor = Color.LightGray;
            }
            else if (progressBar1.Value >= 1 && progressBar1.Value <= 30)
            {
                progressBar1.ForeColor = Color.DarkRed;
                label1.Text = "Password is short and\nis weak.";
                label1.ForeColor = Color.DarkRed;
            }
            if (textBox2.Text.Length >= 24)
            {
                MessageBox.Show("The password that you have input is too long. The maximum number of characters for a password is 28", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox3.Clear();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frm = new Login();
            frm.Show();
        }
            public static int CheckStrength(string password)
            {
                int score = 0;
            if (password.Length > 0 && password.Length <= 4)
                score = 5;
            if (password.Length > 4 && password.Length <= 8)
                score = 10;
            if (password.Length > 8 && password.Length <= 12)
                score = 30;
            if (password.Length > 12)
                score = 40;
            string s1Pattern = @"[!@#\$%\^&\*\?_~\-\(\);\.\+:]+";
            string s2Pattern = "[0-9]";
            string s3Pattern = "[A-Z]";
            if (System.Text.RegularExpressions.Regex.IsMatch(password, s1Pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                score += 15;
            if (System.Text.RegularExpressions.Regex.IsMatch(password, s2Pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                score += 15;
            if (System.Text.RegularExpressions.Regex.IsMatch(password, s3Pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                score += 15;
            return score;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try {
                if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("The password does not match. Please try again", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Clear();
                    textBox3.Clear();
                if (textBox2.Text.Length <= 8)
                    {
                        MessageBox.Show("The password that you have input is too short. The minimum number of characters for a password is 9", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
