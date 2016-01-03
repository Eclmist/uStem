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
    public partial class Receipt : Form
    {
        private Account currentLoggedInUser;
        private Cart cart;
        private Store store;

        public Receipt()
        {
            InitializeComponent();
        }
        public Receipt(Account a, Cart c, Store s) : this ()
        {
            currentLoggedInUser = a;
            store = s;
            cart = c;
        }

        public void GenerateReceipt()
        {
            this.flowLayoutPanel2.Controls.Clear();
            double total = 0;
            string gamestring = "";

            label11.Text = currentLoggedInUser.Username;
            label13.Text = currentLoggedInUser.Username;
            label14.Text = currentLoggedInUser.Email;

            cart.GetContainer();
            foreach (Games game in cart.GetContainer())
            {
                total += game.Cost;
                this.flowLayoutPanel2.Controls.Add(ControlsGenerator.GenerateRecepitPanel(game));
            }

            label15.Text = total.ToString("0.00");
            label16.Text = store.paymentMethod;
            label17.Text = DateTime.Now.ToString("dd MMMM yyyy");
            label18.Text = RandomGenerator.GenerateRandomDigits(16);
            label19.Text = gamestring;
            label25.Text = "S" + String.Format("{0:C}", total);

        }

        private void Receipt_Load(object sender, EventArgs e)
        {

        }
    }
}