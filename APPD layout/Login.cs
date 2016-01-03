using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPD_layout
{
    public partial class Login : Form
    {
        public static AccountContainer accounts = new AccountContainer("./uStem/accounts.txt");
        private Image buttonBg;
        private string userfile = "./uStem/user.txt";
        private string lastUser = "";
        private string lastPassword = "";
        private bool rememberPw = false;

        //Singleton
        public static Login loginForm;

        public Login()
        {
            InitializeComponent();
            this.AcceptButton = button1;
            loginForm = this;

            /*** Populating Accounts ***/
            accounts.LoadAccounts();

            /*** Styling ***/
            buttonBg = button1.BackgroundImage;
            button1.BackgroundImage = base.BackgroundImage;
            button1.Enabled = false;
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent

            /*** Previous user details ***/
            if (File.Exists(userfile))
            {
                string[] content = File.ReadAllLines(userfile);

                if (!content[0].Equals(""))
                {
                    lastUser = content[0];
                }

                if (!content[1].Equals(""))
                {
                    lastPassword = content[1];
                    rememberPw = true;
                }
            }

            textBox1.Text = lastUser;
            textBox2.Text = lastPassword;
            checkBox1.Checked = rememberPw;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
            {
                button1.BackgroundImage = buttonBg;
                button1.Enabled = true;
            }
            else
            {
                button1.BackgroundImage = base.BackgroundImage;
                button1.Enabled = false;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
            {
                button1.BackgroundImage = buttonBg;
                button1.Enabled = true;
            }
            else
            {
                button1.BackgroundImage = base.BackgroundImage;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExecuteLogin();
        }

        private void ToggleLoginControls(bool b)
        {
            this.SuspendLayout();
            textBox1.Enabled = b;
            textBox2.Enabled = b;
            checkBox1.Enabled = b;
            button1.BackgroundImage = b ? buttonBg : base.BackgroundImage;
            button1.Enabled = b;
            button3.BackgroundImage = b ? buttonBg : base.BackgroundImage;
            button3.Enabled = b;
            button4.BackgroundImage = b ? buttonBg : base.BackgroundImage;
            button4.Enabled = b;
            textBox1.Refresh();
            textBox2.Refresh();
            this.ResumeLayout(true);
            this.PerformLayout();

        }

        private void HideLoginError()
        {
            if (flowLayoutPanel2.Controls.Find("errorPanel", true).Any())
            {
                ((Panel)flowLayoutPanel2.Controls.Find("errorPanel", true)[0]).Visible = false;
            }
        }

        private void DisplayLoginError()
        {
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.Controls.Add(ControlsGenerator.GenerateLoginError());
            textBox2.Clear();
        }


        private void ExecuteLogin()
        {
            ToggleLoginControls(false);
            bool usernameFound = false;
            bool loginSucessful = false;
            Account logedInAccount = new Account();

            HideLoginError();

            foreach (Account a in accounts.GetContainer())
            {
                if (textBox1.Text.ToLower().Equals(a.Username.ToLower()))
                {
                    usernameFound = true;
                }

                if (usernameFound)
                {
                    if (textBox2.Text.Equals(a.Password))
                    {
                        loginSucessful = true;
                        logedInAccount = a;
                        break;
                    }
                }
            }

            if (!loginSucessful)
            {
                DisplayLoginError();
                ToggleLoginControls(true);
                textBox2.Select();
            }
            else
            {
                string[] content = new string[2];
                content[0] = textBox1.Text;
                content[1] = checkBox1.Checked ? textBox2.Text : null;

                File.WriteAllLines(userfile, content);

                Store store = new Store(logedInAccount, this);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signup frm5 = new Signup();
            frm5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Signup frm5 = new Signup();
            frm5.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExecuteLogin();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExecuteLogin();
            }
        }
    }
}
