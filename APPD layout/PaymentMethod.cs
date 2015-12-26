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
    public partial class PaymentMethod : Form
    {
        public PaymentMethod()
        {
            InitializeComponent();
            textBox1.MaxLength = 16;
            textBox2.MaxLength = 3;
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox1.CharacterCasing = CharacterCasing.Upper;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string S = "";
            try {
                if (checkBox1.CheckState.Equals(CheckState.Unchecked))
             {
                label16.Visible = true;
                    S += "• Checkbox was not ticked.\n";
             }
                if(textBox1.Text.Length != 16)
                {
                    label16.Visible = true;
                    S += "• Invalid card number. Please ensure that you key in all 16 digits correctly.\n";
                    textBox1.Clear();
                }
                if(textBox8.Text.Length != 8)
                {
                    label16.Visible = true;
                    S += "• Invalid phone number. Please ensure you that you key in all 8 digits correctly.\n";
                    textBox8.Clear();
                }
                label16.Text = S;
            }
            catch (Exception ex) {
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
