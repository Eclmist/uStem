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
        double subtotal;

        public Cart(FlowLayoutPanel flowLayoutPanel, Label subtotalLabel)
        {
            cartListPanel = flowLayoutPanel;
            this.subtotalLabel = subtotalLabel;
            subtotal = 0;
        }

        public void PopulateGameCart()
        {
            cartListPanel.Controls.Clear();

            foreach (Games game in GetContainer())
            {
                Panel p = ControlsGenerator.GenerateCartPanel(game);
                ((Label)p.Controls.Find("remove", true)[0]).Click += Remove_Click;
                cartListPanel.Controls.Add(p);
            }
            UpdateSubtotal();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (((Games)((Label)sender).Tag).Quantity > 1)
            {
                ((Games)((Label)sender).Tag).Quantity--;
            }
            else
            {
                GetContainer().Remove((Games)((Label)sender).Tag);
            }

            PopulateGameCart();

        }

        public void UpdateSubtotal()
        {
            subtotal = 0;
            foreach (Games game in GetContainer())
            {
                subtotal +=  game.Cost;
            }
            subtotalLabel.Text = "S" + String.Format("{0:C}", subtotal);
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
