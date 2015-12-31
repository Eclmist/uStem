//Adding game to CartList
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace APPD_layout
{
    class Cart
    {
        FlowLayoutPanel cartListPanel;
        public static List<Games> gameCart = new List<Games>();

        public static void AddGamesToCart(Games choiceofgame)
        {
            gameCart.Add(choiceofgame);
        }

        public void PopulateGameCart()
        {
            foreach (Games game in gameCart)
            {
                cartListPanel.Controls.Add(GenerateGameInCart(game));
            }
        }

        public Cart(FlowLayoutPanel flowLayoutPanel)
        {
            cartListPanel = flowLayoutPanel;
        }

        public Panel GenerateGameInCart(Games gameref)
        {
            Panel panel = new Panel();

            panel.Controls.Add(GameNameLabel(gameref));
            panel.Controls.Add(GamePicturebox(gameref));
            panel.Controls.Add(GameCostLabel(gameref));
            panel.Location = new Point(3, 3);
            panel.Size = new Size(884, 120);
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
            label.Location = new Point(1, 6);
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
            picbox.Location = new Point(-1, 30);
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
            label.Location = new Point(1, 6);
            label.Margin = new Padding(2, 0, 2, 0);
            label.Name = "Label" + gameref.Cost;
            label.Size = new Size(218, 16);
            label.Text = gameref.Name;
            label.Click += Store.gameLabelClickHandler;
            label.Tag = gameref;

            return label;
        }
    }
}
