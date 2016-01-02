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


        #region cartpanel
        public static Panel GenerateCartPanel(Games gameref)
        {
            Label name = new Label();
            name.AutoSize = true;
            name.BackColor = Color.Transparent;
            name.Font = new Font("Calibri", 10F);
            name.ForeColor = Color.LightSteelBlue;
            name.Location = new Point(149, 25);
            name.Name = "label9";
            name.Size = new Size(46, 17);
            name.Text = gameref.Name;

            Label quantity = new Label();
            quantity.AutoSize = true;
            quantity.BackColor = Color.Transparent;
            quantity.Font = new Font("Calibri", 10F);
            quantity.ForeColor = Color.LightSteelBlue;
            quantity.Location = new Point(149, 42);
            quantity.Name = "label11";
            quantity.Size = new Size(29, 17);
            quantity.Text = "(x" + gameref.Quantity + ")";
            if (gameref.Quantity <= 1)
                quantity.Visible = false;

            Label price = new Label();
            price.Anchor = AnchorStyles.Top;
            price.AutoSize = true;
            price.BackColor = Color.Transparent;
            price.Font = new Font("Calibri", 11F);
            price.ForeColor = Color.LightSteelBlue;
            price.Location = new Point(14, 0);
            price.Name = "label10";
            price.Size = new Size(74, 18);
            price.Text = "S" + String.Format("{0:C}", gameref.Cost);
            if (gameref.Quantity > 1)
                price.Text += " x " + gameref.Quantity;

            price.TextAlign = ContentAlignment.MiddleCenter;

            LinkLabel remove = new LinkLabel();
            remove.ActiveLinkColor = Color.SkyBlue;
            remove.AutoSize = true;
            remove.BackColor = Color.Transparent;
            remove.Font = new Font("Calibri", 10F);
            remove.LinkColor = Color.SlateGray;
            remove.Location = new Point(34, 18);
            remove.Name = "remove";
            remove.Size = new Size(54, 17);
            remove.Text = "Remove";
            remove.VisitedLinkColor = Color.SlateGray;
            remove.Tag = gameref;

            PictureBox pic = GenerateGamePicturebox(gameref);
            pic.Location = new Point(16, 18);
            pic.Size = new Size(118, 44);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;

            PictureBox platform = new PictureBox();
            platform.Image = Image.FromFile("./img/Platform.png");
            platform.Location = new Point(370, 15);
            platform.Size = new Size(137, 34);
            platform.SizeMode = PictureBoxSizeMode.AutoSize;
            platform.BackColor = Color.Transparent;

            FlowLayoutPanel costAndRemoveGroup = new FlowLayoutPanel();
            costAndRemoveGroup.BackColor = Color.Transparent;
            costAndRemoveGroup.Controls.Add(price);
            costAndRemoveGroup.Controls.Add(remove);
            costAndRemoveGroup.FlowDirection = FlowDirection.RightToLeft;
            costAndRemoveGroup.Location = new Point(513, 18);
            costAndRemoveGroup.Name = "flowLayoutPanel6";
            costAndRemoveGroup.Size = new Size(91, 41);
            costAndRemoveGroup.TabIndex = 36;

            Panel panel = new Panel();
            panel.Controls.Add(name);
            panel.Controls.Add(costAndRemoveGroup);
            panel.Controls.Add(pic);
            panel.Controls.Add(quantity);
            panel.Controls.Add(platform);
            panel.ForeColor = SystemColors.InactiveCaption;
            panel.Location = new Point(0, 2);
            panel.Margin = new Padding(0, 2, 0, 2);
            panel.Name = "panel4";
            panel.Size = new Size(615, 80);
            panel.TabIndex = 34;
            panel.BackColor = Color.FromArgb(70, Color.Black);

            return panel;
        }

        #endregion

        #region GenerateLoginError
        public static Panel GenerateLoginError()
        {
            Label label8 = new Label();
            label8.Font = new Font("Arial", 8.25F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(8, 7);
            label8.Name = "label8";
            label8.Size = new Size(415, 33);
            label8.TabIndex = 0;
            label8.Text = "You have entered your password or account name incorrectly. Please check your pas" +
    "sword and account name and try again.";

            Panel panel3 = new Panel();
            panel3.BackColor = Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            panel3.Controls.Add(label8);
            panel3.Location = new Point(2, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(419, 45);
            panel3.TabIndex = 0;

            Panel panel = new Panel();
            panel.BackColor = Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(72)))), ((int)(((byte)(71)))));
            panel.Controls.Add(panel3);
            panel.Location = new Point(3, 3);
            panel.Name = "panel2";
            panel.Size = new Size(423, 49);
            panel.TabIndex = 0;

            return panel;
        }
        #endregion

    }
}
