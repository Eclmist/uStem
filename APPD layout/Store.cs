//TODO: remove unused winform click methods

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
    public enum Page {
        Browsing,
        GameDetails,
        Cart,
        Billing
    }

    public partial class Store : Form
    {
        Panel[] panelList;
        private Page currentPage = Page.Browsing;
        private List<Page> pageHistroy = new List<Page>();
        Bitmap nullBitmap = new Bitmap(1, 1);
        Image backArrow;

        public Store()
        {
            InitializeComponent();

            panelList = new Panel[] { panel1, panel7, panel10, panel9 };    //panel1 = Browsing
                                                                            //panel7 = GameDetails
                                                                            //panel10 = cart
                                                                            //panel9 = billing
            UpdatePageHistory();
            UpdateCurrentPanel();
            //
            /*********************************************************************************/
            //

            


            textBox4.MaxLength = 16;
            textBox3.MaxLength = 3;
            textBox7.MaxLength = 6;
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox4.CharacterCasing = CharacterCasing.Upper;

            /*** TEST ***/
            Catalogue.LoadGames();
            LoadGameClickHandler();

            BrowsingScreenHandler browsingScreenHandler = new BrowsingScreenHandler(this.flowLayoutPanel1);
            browsingScreenHandler.PopulateGameList();
        }

        public void UpdatePageHistory()
        {
            pageHistroy.Add(currentPage);
        }

        public void UpdateCurrentPanel()
        {

            //currentPanel should be updated before this method is to be called
            Panel targetPanel;     

            switch (currentPage)
            {
                case Page.Browsing:
                    targetPanel = panel1;
                    break;
                case Page.GameDetails:
                    targetPanel = panel7;
                    break;
                case Page.Cart:
                    targetPanel = panel10;
                    break;
                case Page.Billing:
                    targetPanel = panel9;
                    break;
                default:
                    targetPanel = panel1;
                    break;
            }

            if (currentPage != Page.Browsing)
                pictureBox1.Image = backArrow;
            else
                pictureBox1.Image = nullBitmap;

            foreach (Panel p in panelList)
            {
                //Check reference equility
                if (Object.ReferenceEquals(p, targetPanel))
                    p.Visible = true;
                else
                    p.Visible = false;
            }
        }

        public void NavButtonClick(Page targetPage)
        {
            UpdatePageHistory();
            currentPage = targetPage;
            UpdateCurrentPanel();
        }

        public void BackButtonClick()
        {
            currentPage = pageHistroy.Last<Page>();
            if (pageHistroy.Count > 1)
            {
                int indexOfLastItem = pageHistroy.LastIndexOf(pageHistroy.Last<Page>());
                pageHistroy.RemoveAt(indexOfLastItem);
            }

            UpdateCurrentPanel();
        }

        public static System.EventHandler gameLabelClickHandler;
        public static System.EventHandler gamePicClickHandler;


        private void GameLabelClickHandler(object sender, EventArgs e)
        {
            GameClick((Games)((Label)sender).Tag);
        }

        private void GamePicClickHandler(object sender, EventArgs e)
        {
            GameClick((Games)((PictureBox)sender).Tag);
        }

        private void GameClick(Games game)
        {
            NavButtonClick(Page.GameDetails);
            //TODO: Code to modify gamedetails page
        }

        private void LoadGameClickHandler()
        {
            gameLabelClickHandler = GameLabelClickHandler;
            gamePicClickHandler = GamePicClickHandler;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Item1_Click(object sender, EventArgs e)
        {

        }private void Item2_Click(object sender, EventArgs e)
        {

        }
        private void Item3_Click(object sender, EventArgs e)
        {
            NavButtonClick(Page.Cart);
        }
        private void Item4_Click(object sender, EventArgs e)
        {

        }
        private void label20_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            NavButtonClick(Page.Cart);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            NavButtonClick(Page.Browsing);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            NavButtonClick(Page.GameDetails);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NavButtonClick(Page.Billing);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NavButtonClick(Page.Billing);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            BackButtonClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string S = "";
            try
            {
                if (checkBox1.CheckState.Equals(CheckState.Unchecked))
                {
                    label41.Visible = true;
                    S += "• Checkbox was not ticked.\n\n";
                }
                if (textBox4.Text.Length != 16)
                {
                    label41.Visible = true;
                    S += "• Invalid card number. Please ensure that you key in all 16 digits correctly.\n\n";
                    textBox4.Clear();
                }
                if (textBox8.Text.Length != 8)
                {
                    label41.Visible = true;
                    S += "• Invalid phone number. Please ensure you that you key in all 8 digits correctly.\n\n";
                    textBox8.Clear();
                }
                label41.Text = S;
            }
            catch (Exception ex)
            {
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
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
