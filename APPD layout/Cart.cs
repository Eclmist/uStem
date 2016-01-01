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
        public Cart(FlowLayoutPanel flowLayoutPanel)
        {
            cartListPanel = flowLayoutPanel;
        }
        public void PopulateGameCart()
        {
            foreach (Games game in GetContainer())
            {
                cartListPanel.Controls.Add(GenerateGameInCart(game));
            }
        }
        public Panel GenerateGameInCart(Games gameref)
        {
            Panel panel = new Panel();

            panel.Controls.Add(GameNameLabel(gameref));
            panel.Controls.Add(GamePicturebox(gameref));
            panel.Controls.Add(GameCostLabel(gameref));
            panel.Size = new Size(870, 130);
            panel.BackColor = Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            panel.TabIndex = 0;

            return panel;
        }

        public Label GameNameLabel(Games gameref)
        {
            Label label = new Label();

            label.AutoSize = true;
            label.BackColor = Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(73)))));
            label.Font = new Font("Arial", 9.75F, ((FontStyle)((FontStyle.Bold | FontStyle.Underline))), GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = Color.WhiteSmoke;
            label.Location = new Point(240, 19);
            label.Margin = new Padding(2, 0, 2, 0);
            label.Name = "Label" + gameref.Name;
            label.Size = new Size(218, 16);
            label.Text = gameref.Name;
            label.Click += Store.gameLabelClickHandler;
            label.Tag = gameref;

            return label;
        }

        public PictureBox GamePicturebox(Games gameref)
        {
            PictureBox picbox = new PictureBox();

            picbox.BackgroundImage = Image.FromFile("./img/" + gameref.Imgsrc);
            picbox.BackgroundImageLayout = ImageLayout.Stretch;
            picbox.Location = new Point(10, 19);
            picbox.Name = "Picbox" + gameref.Name;
            picbox.Size = new Size(200, 120);
            picbox.Click += Store.gamePicClickHandler;
            picbox.Tag = gameref;

            return picbox;
        }

        public Label GameCostLabel(Games gameref)
        {
            Label label = new Label();

            label.AutoSize = true;
            label.BackColor = Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(73)))));
            label.Font = new Font("Arial", 9.75F, ((FontStyle)((FontStyle.Bold | FontStyle.Underline))), GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = Color.WhiteSmoke;
            label.Location = new Point(790, 19);
            label.Margin = new Padding(2, 0, 2, 0);
            label.Name = "Label" + gameref.Cost;
            label.Size = new Size(218, 16);
            label.Text = gameref.Cost.ToString("0.00");
            label.Click += Store.gameLabelClickHandler;
            label.Tag = gameref;

            return label;
        }
    }
}
