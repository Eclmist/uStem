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
    enum Page { Home, GameScreen, Cart, Bill }
    public partial class Store : Form
    {
        Panel[] panelList;
        private int count;
        public Store()
        {
            InitializeComponent();
            panelList = new Panel[] { panel1, panel7, panel10, panel9 };
            textBox4.MaxLength = 16;
            textBox3.MaxLength = 3;
            textBox7.MaxLength = 6;
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox4.CharacterCasing = CharacterCasing.Upper;
        }

    private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Item1_Click(object sender, EventArgs e)
        {

        }private void Item2_Click(object sender, EventArgs e)
        {

        }
        private void Item3_Click(object sender, EventArgs e)
        {
            count = 3;
            State(count);
        }
        private void Item4_Click(object sender, EventArgs e)
        {

        }
        private void label20_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            count = 3;
            State(count);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            count = 1;
            State(count);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            count = 2;
            State(count);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            count = 4;
            State(count);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            count = 4;
            State(count);
        }
        private void State(int n)
        {
            panelList[n - 1].Visible = true;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel10.Visible == true)
            {
                pictureBox1.Visible = true;
                panel1.Visible = false;
                panel7.Visible = true;
                panel10.Visible = false;
            }
            else if (panel7.Visible == true)
            {
                pictureBox1.Visible = true;
                panel1.Visible = true;
                panel7.Visible = false;
                panel10.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string S = "";
            try
            {
                if (checkBox1.CheckState.Equals(CheckState.Unchecked))
                {
                    label41.Visible = true;
                    S += "• Checkbox was not ticked.\n";
                }
                if (textBox4.Text.Length != 16)
                {
                    label41.Visible = true;
                    S += "• Invalid card number. Please ensure that you key in all 16 digits correctly.\n";
                    textBox4.Clear();
                }
                if (textBox8.Text.Length != 8)
                {
                    label41.Visible = true;
                    S += "• Invalid phone number. Please ensure you that you key in all 8 digits correctly.\n";
                    textBox8.Clear();
                }
                label41.Text = S;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
