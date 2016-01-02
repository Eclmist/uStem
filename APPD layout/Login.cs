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
    public partial class Login : Form
    {
        AccountContainer accounts = new AccountContainer();
        Image buttonBg;

        public Login()
        {
            InitializeComponent();

            /*** Populating Accounts ***/
            accounts.LoadAccounts("./accounts.txt");

            /*** Styling ***/
            buttonBg = button1.BackgroundImage;
            button1.BackgroundImage = base.BackgroundImage;
            button1.Enabled = false;

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
            bool usernameFound = false;
            bool loginSucessful = false;

            HideLoginError();



            //Emulating login time
            System.Threading.Thread.Sleep(500);

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
                        this.Hide();
                        Store store = new Store(a);
                        store.Show();
                        break;
                    }
                    else
                    {
                        DisplayLoginError();
                    }
                }
            }

            if (!loginSucessful)
            {
                DisplayLoginError();

            }
        }

        private void HideLoginError()
        {
            flowLayoutPanel2.Controls.Clear();
        }

        private void DisplayLoginError()
        {
            flowLayoutPanel2.Controls.Add(ControlsGenerator.GenerateLoginError());
            textBox2.Clear();
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
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
            if (button1.Enabled)
            {
                button1.ForeColor = Color.Silver;
            }
            else
            {
                button1.ForeColor = Color.FromArgb(115, 115, 115);
            }
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
