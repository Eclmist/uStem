using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPD_layout
{
    public enum Process
    {
        Features,
        CreateAccount,
        Email,
        Information
    }
    public partial class Signup : Form
    {
        List<string> Account = new List<string>();
        Panel[] panelList;
        bool errorCheck = true;
        private Process currentProcess = Process.Features;
        public Signup()
        {
            InitializeComponent();
            progressBar1.Maximum = 85;

            panelList = new Panel[] { panel1, panel2, panel5, panel4 };
        }
        public void NavButtonClick(Process targetProcess)
        {
            currentProcess = targetProcess;
            UpdateCurrentPanel();
        }
        public void UpdateCurrentPanel()
        {

            //currentPanel should be updated before this method is to be called
            Panel targetPanel;

            switch (currentProcess)
            {
                case Process.Features:
                    targetPanel = panel1;
                    break;
                case Process.CreateAccount:
                    targetPanel = panel2;
                    break;
                case Process.Email:
                    targetPanel = panel5;
                    break;
                case Process.Information:
                    targetPanel = panel4;
                    break;
                default:
                    targetPanel = panel1;
                    break;
            }
            foreach (Panel panel in panelList)
            {
                if (object.ReferenceEquals(panel, targetPanel))
                {
                    panel.Visible = true;
                }
                else
                {
                    panel.Visible = false;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

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
            if (progressBar1.Value > 70 && textBox2.Text.Length > 8)
            {
                progressBar1.ForeColor = Color.YellowGreen;
                label24.Text = "Password is very strong.";
                label24.ForeColor = Color.YellowGreen;
            }
            else if (progressBar1.Value > 50 && progressBar1.Value <= 70 && textBox2.Text.Length > 8)
            {
                progressBar1.ForeColor = Color.YellowGreen;
                label24.Text = "Password is fairly strong.";
                label24.ForeColor = Color.LightGray;
            }
            else if (progressBar1.Value > 30 && progressBar1.Value <= 50 && textBox2.Text.Length > 8)
            {
                progressBar1.ForeColor = Color.Yellow;
                label24.Text = "Password is acceptable.";
                label24.ForeColor = Color.LightGray;
            }
            else if (progressBar1.Value >= 1 && progressBar1.Value <= 30)
            {
                progressBar1.ForeColor = Color.DarkRed;
                label24.Text = "Password is short and\nis weak.";
                label24.ForeColor = Color.DarkRed;
            }
            if (textBox2.Text.Length >= 24)
            {
                MessageBox.Show("The password that you have input is too long. The maximum number of characters for a password is 28", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox3.Clear();
            }
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
            string s = @"([<>?/,!])+";
            foreach (char c in s)
            {
                if (password.Contains(c))
                {
                    score += 15;
                    break;
                }

            }
            if (password.Any(char.IsDigit)) score += 15;
            if (password.Any(char.IsUpper)) score += 15;
            if (password.Contains(s)) score += 15;
            return score;
        }

        private void panel2next_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length <= 8)
            {
                MessageBox.Show("The password that you have input is too short. The minimum number of characters for a password is 9", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox3.Clear();
                errorCheck = false;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("The password does not match. Please try again", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox3.Clear();
                errorCheck = false;
            }
            if (errorCheck == true)
            {
                NavButtonClick(Process.Email);
            }
            errorCheck = true;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
        private void panel1Next_Click(object sender, EventArgs e)
        {
            NavButtonClick(Process.CreateAccount);
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            NavButtonClick(Process.CreateAccount);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            NavButtonClick(Process.Information);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
