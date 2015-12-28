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

        /*
            THREE REQUIRED ELEMENTS FOR EACH GAME TO BE DISPLAYED IN THE MAIN SCREEN
            1) PANEL
            2) LABEL
            3) PICTUREBOX
        */

        /*
        Controls template for PANEL
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(307, 208);
            this.panel3.TabIndex = 0;

        CONTROLS FOR LABEL
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(73)))));
            this.label17.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label17.Location = new System.Drawing.Point(1, 6);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(218, 16);
            this.label17.TabIndex = 22;
            this.label17.Text = "Holy Potatoes! A Weapon Shop?!";

        CONTROLS FOR PICTUREBOX
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(-1, 30);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(307, 175);
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
        */

        FlowLayoutPanel gamesListPanel;

        public BrowsingScreenHandler(FlowLayoutPanel flp)
        {
            gamesListPanel = flp;
        }

        public void PopulateGameList()
        {
            foreach (Games game in Catalogue.gameList)
            {
                gamesListPanel.Controls.Add(GenerateGamePanel(game));
            }
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
