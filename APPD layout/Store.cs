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
    public partial class Store : Form
    {
        Panel[] panelList;
        private int count;
        public Store()
        {
            InitializeComponent();
            panelList = new Panel[] { panel1, panel7, panel10 };
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
            count = 2;
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
        private void State(int n)
        {
            panelList[n-1].Visible = true;
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
    }
}
