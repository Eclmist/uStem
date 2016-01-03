using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace APPD_layout
{
    public class Cart : GenericContainer<Games>
    {
        FlowLayoutPanel cartListPanel;
        Label subtotalLabel;
        private double discount = 1;
        private bool discounted = false;

        public double Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
            }
        }

        public bool Discounted
        {
            get
            {
                return discounted;
            }

            set
            {
                discounted = value;
            }
        }

        public Cart(FlowLayoutPanel flowLayoutPanel, Label subtotalLabel)
        {
            cartListPanel = flowLayoutPanel;
            this.subtotalLabel = subtotalLabel;
        }

        public void PopulateGameCart()
        {
            cartListPanel.Controls.Clear();

            foreach (Games game in GetContainer())
            {
                Panel p = ControlsGenerator.GenerateCartPanel(game);
                ((LinkLabel)p.Controls.Find("remove", true)[0]).Click += Remove_Click;
                cartListPanel.Controls.Add(p);
            }
            UpdateSubtotal();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (((Games)((LinkLabel)sender).Tag).Quantity > 1)
            {
                ((Games)((LinkLabel)sender).Tag).Quantity--;
            }
            else
            {
                GetContainer().Remove((Games)((LinkLabel)sender).Tag);
            }

            PopulateGameCart();
            UpdateSubtotal();

        }

        public void UpdateSubtotal()
        {
            subtotalLabel.Text = "S" + string.Format("{0:C}", CalculateSubtotal());
        }

        public double CalculateSubtotal()
        {
            double subtotal = 0;
            foreach (Games game in GetContainer())
            {
                subtotal += game.Cost * game.Quantity;
            }

            return discounted ? subtotal * discount : subtotal;
        }

        public override void AddToContainer(Games item)
        {
            if (!GetContainer().Exists(x => x.Name.Equals(item.Name)))
            {
                base.AddToContainer(item);
            }
            else
            {
                GetContainer().Find(x => x.Name.Equals(item.Name)).Quantity ++;
            }
        }
    }
}
