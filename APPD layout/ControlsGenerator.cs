using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPD_layout
{
    public class ControlsGenerator
    {
        public static Panel GenerateGamePanel(Games gameref)
        {
            Panel panel = new Panel();

            panel.Controls.Add(GenerateGameNameLabel(gameref));
            panel.Controls.Add(GenerateGamePicturebox(gameref));
            panel.Location = new Point(3, 3);
            panel.Name = "panel" + gameref.Name;
            panel.Size = new Size(307, 208);
            panel.TabIndex = 0;
            panel.BackColor = Color.FromArgb(0, Color.Black);

            return panel;
        }

        public static Label GenerateGameNameLabel(Games gameref)
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
            label.BackColor = Color.FromArgb(0, Color.Black);


            return label;
        }

        public static PictureBox GenerateGamePicturebox(Games gameref)
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

        public static CheckBox GenerateGenreSelectCheckbox(GenreContainer g, EventHandler e)
        {
            CheckBox checkbox = new CheckBox();

            checkbox.AutoSize = true;
            checkbox.FlatStyle = FlatStyle.Flat;
            checkbox.ForeColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(118)))), ((int)(((byte)(150)))));
            checkbox.Location = new Point(13, 43);
            checkbox.Name = g.Name;
            checkbox.Size = new Size(77, 17);
            checkbox.TabIndex = 11;
            checkbox.Text = g.Name;
            checkbox.UseVisualStyleBackColor = true;
            checkbox.Tag = g;
            checkbox.CheckedChanged += e;

            return checkbox;
        }

        public static Button GenerateBtn(string text)
        {
            Button button = new Button();
            button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            button.Dock = System.Windows.Forms.DockStyle.Bottom;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(118)))), ((int)(((byte)(150)))));
            button.Location = new System.Drawing.Point(2, 2);
            button.Margin = new System.Windows.Forms.Padding(2);
            button.Name = "button6";
            button.Size = new System.Drawing.Size(63, 23);
            button.TabIndex = 11;
            button.Text = text;
            button.UseVisualStyleBackColor = false;

            return button;
        }

    }
}
