//TODO: Populate based on genre
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPD_layout
{
    class BrowsingScreenHandler
    {
        FlowLayoutPanel gamesListPanel;

        public BrowsingScreenHandler(FlowLayoutPanel flp)
        {
            gamesListPanel = flp;
        }

        public void PopulateGameList(Catalogue catalogue)
        {
            ClearGameListPanel();

            foreach (Games game in catalogue.GetContainer())
            {
                gamesListPanel.Controls.Add(GenerateGamePanel(game));
            }
        }

        public void PopulateGameList(Genre genre)
        {
            ClearGameListPanel();

            foreach (Games game in genre.GetContainer())
            {
                gamesListPanel.Controls.Add(GenerateGamePanel(game));
            }
        }

        public void ClearGameListPanel()
        {
            gamesListPanel.Controls.Clear();
        }

        public Panel GenerateGamePanel(Games gameref)
        {
            Panel panel = new Panel();

            panel.Controls.Add(GenerateGameNameLabel(gameref));
            panel.Controls.Add(GenerateGamePicturebox(gameref));
            panel.Location = new Point(3, 3);
            panel.Name = "panel" + gameref.Name;
            panel.Size = new Size(307, 208);
            panel.TabIndex = 0;

            return panel;
        }

        public Label GenerateGameNameLabel(Games gameref)
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

        public PictureBox GenerateGamePicturebox(Games gameref)
        {
            PictureBox picbox = new PictureBox();

            picbox.BackgroundImage = Image.FromFile("./img/" + gameref.Imgsrc);
            picbox.BackgroundImageLayout = ImageLayout.Stretch;
            picbox.Location = new Point(-1, 30);
            picbox.Name = "Picbox" + gameref.Name;
            picbox.Size = new Size(307, 175);
            picbox.Click += Store.gamePicClickHandler;
            picbox.Tag = gameref;

            return picbox;
        }
    }
}
