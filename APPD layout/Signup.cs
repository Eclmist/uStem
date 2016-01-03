using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPD_layout
{
    public enum SignupPages
    {
        Intro,
        LoginCredentials,
        Email,
        Complete
    }
    public partial class Signup : Form
    {
        private List<string> Account = new List<string>();
        private Panel[] panelList;
        private bool errorCheck = true;
        private SignupPages _currentSignupPages = SignupPages.Intro;
        private string chosenUsername;
        private string chosenPassword;
        private string chosenEmail;

        public Signup()
        {
            InitializeComponent();
            progressBar1.Maximum = 85;

            panelList = new Panel[] { panel1, panel2, panel5, panel4 };

            label27.Visible = false;
            label28.Visible = false;
            label29.Visible = false;
            label30.Visible = false;


        }

        public void NavButtonClick(SignupPages targetSignupPages)
        {
            _currentSignupPages = targetSignupPages;
            UpdateCurrentPanel();
        }

        public void UpdateCurrentPanel()
        {
            //currentPanel should be updated before this method is to be called
            Panel targetPanel;

            switch (_currentSignupPages)
            {
                case SignupPages.Intro:
                    targetPanel = panel1;
                    break;
                case SignupPages.LoginCredentials:
                    targetPanel = panel2;
                    break;
                case SignupPages.Email:
                    targetPanel = panel5;
                    break;
                case SignupPages.Complete:
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
            progressBar1.ForeColor = Color.FromArgb(0, 94, 139);
        }

        public static int CheckStrength(string password)
        {
            int score = 0;
            if (password.Length > 0)
                score = 5;
            if (password.Length > 3)
                score = 10;
            if (password.Length > 6)
                score = 30;
            if (password.Length > 9)
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
            if (!label27.Visible && !label28.Visible &&
                !textBox1.Text.Equals("") && !textBox2.Text.Equals("") &&
                !textBox3.Text.Equals(""))
            {
                chosenUsername = textBox1.Text;
                chosenPassword = textBox3.Text;
                NavButtonClick(SignupPages.Email);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.loginForm.Show();
        }
        private void panel1Next_Click(object sender, EventArgs e)
        {
            NavButtonClick(SignupPages.LoginCredentials);
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            NavButtonClick(SignupPages.LoginCredentials);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            NavButtonClick(SignupPages.Complete);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.loginForm.Show();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool usernameValid = true;

            foreach (Account account in Login.accounts.GetContainer())
            {
                if (account.Username.Equals(((TextBox)sender).Text))
                {
                    usernameValid = false;
                }
            }

            label27.Visible = !usernameValid ? true : false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            bool password = textBox2.Text.Equals(((TextBox)sender).Text);

            label28.Visible = !password ? true : false;

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            bool emailValid = true;

            foreach (Account account in Login.accounts.GetContainer())
            {
                if (account.Email.Equals(((TextBox)sender).Text))
                {
                    emailValid = false;
                    label29.Text = "!This email is already in use";
                }
            }

            if (!IsValidEmail(((TextBox) sender).Text))
            {
                emailValid = false;
                label29.Text = "!This email is not valid";
            }

            label29.Visible = !emailValid ? true : false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            bool email = textBox4.Text.Equals(((TextBox)sender).Text);

            label30.Visible = !email ? true : false;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals(textBox6.Text) && IsValidEmail(textBox4.Text) && !label29.Visible &&
                !label30.Visible)
            {
                chosenEmail = textBox4.Text;

                label20.Text = chosenUsername;
                label21.Text = chosenPassword;
                label22.Text = chosenEmail;

                Account a = new Account(chosenUsername, chosenPassword, chosenEmail);
                Login.accounts.AddToContainer(a);
                Login.accounts.AddAccount(a);

                NavButtonClick(SignupPages.Complete);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.loginForm.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            NavButtonClick(SignupPages.Intro);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.loginForm.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            NavButtonClick(SignupPages.LoginCredentials);
        }
    }
}
