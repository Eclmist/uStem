//TODO: remove unused winform click methods

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace APPD_layout
{
    public enum Page
    {
        Browsing,
        GameDetails,
        Cart,
        Billing,
        Confirmation
    }

    public partial class Store : Form
    {
        Panel[] panelList;
        Page currentPage = Page.Browsing;
        bool errorCheck = true;
        Cart cart;
        List<Page> pageHistroy = new List<Page>();
        Bitmap nullBitmap = new Bitmap(1, 1);
        Image backArrow; //TODO: add greying code to partial class after project is done
        
        List<GenreContainer> listOfGenres;

        public static Catalogue allGamesCatalogue;
        Catalogue winterSalesCatalogue;

        Account currentLoggedInUser;
        public Store()
        {
            InitializeComponent();

            panelList = new Panel[] { panel1, panel7, panel10, panel9, panel14 };    //panel1 = Browsing
                                                                                     //panel7 = GameDetails
                                                                                     //panel10 = cart
                                                                                     //panel9 = billing
            UpdatePageHistory();
            UpdateCurrentPanel();
            //
            /*********************************************************************************/
            //

            SetControlStyles();

            /*** Instantiate Genres List ***/
            listOfGenres = new List<GenreContainer>();

            /*** Populating Catalogue ***/
            allGamesCatalogue = new Catalogue();
            allGamesCatalogue.LoadGames("./product.txt", listOfGenres);

            winterSalesCatalogue = new Catalogue();
            //winterSalesCatalogue.LoadGames("");


            LoadGameClickHandler();
            BrowsingScreenHandler browsingScreenHandler = new BrowsingScreenHandler(this.flowLayoutPanel1, this.flowLayoutPanel2);
            cart = new Cart(flowLayoutPanel7, label8);
            browsingScreenHandler.PopulateGameList(allGamesCatalogue);
            browsingScreenHandler.PopulateGenreSelector(listOfGenres);
        }

        public Store(Account a) : this ()
        {
            /*** Update Logged Account ***/
            currentLoggedInUser = a;
        }

        public void SetControlStyles()
        {
            flowLayoutPanel1.BackColor = Color.FromArgb(10, Color.Black);
            label5.BackColor = Color.FromArgb(0, Color.Black);
            label21.BackColor = Color.FromArgb(10, Color.Black);
            panel11.BackColor = Color.FromArgb(70, Color.Black);
            panel5.BackColor = Color.FromArgb(70, Color.Black);
            panel10.BackColor = Color.FromArgb(70, Color.Black);
            panel8.BackColor = Color.FromArgb(30, Color.White);
            panel6.BackColor = Color.FromArgb(50, Color.Black);
            panel13.BackColor = Color.FromArgb(70, Color.Black);        
            
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
                case Page.Confirmation:
                    targetPanel = panel14;
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
            label31.Text = game.Name;
            pictureBox8.BackgroundImage = Image.FromFile("./img/" + game.Imgsrc);
            label29.Text = game.Desc;
            label25.Text = game.ReleaseDate.ToString("dd MMM yyyy");
            label24.Text = "Buy " + game.Name;
            label22.Text = "S" + String.Format("{0:C}", game.Cost);
            button2.Tag = game;
            if (game.DiscountRate > 0)
            {
                label23.Text = "SPECIAL PROMOTION! Offer ends on " + game.ReleaseDate.AddDays(36).ToString("MMMM dd");
            }
            else
                label23.Text = "Discounts not available in your region.";

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
            NavButtonClick(Page.Cart);
            cart.PopulateGameCart();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Item1_Click(object sender, EventArgs e)
        {

        }
        private void Item2_Click(object sender, EventArgs e)
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
                    errorCheck = false;
                }
                if (textBox4.Text.Length != 16)
                {
                    label41.Visible = true;
                    S += "• Invalid card number. Please ensure that you key in all 16 digits correctly.\n\n";
                    textBox4.Clear();
                    errorCheck = false;
                }
                if (textBox8.Text.Length != 8)
                {
                    label41.Visible = true;
                    S += "• Invalid phone number. Please ensure you that you key in all 8 digits correctly.\n\n";
                    textBox8.Clear();
                    errorCheck = false;
                }
                label41.Text = S;
                if(errorCheck == true)
                {
                    NavButtonClick(Page.Confirmation);
                }
                errorCheck = true;
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
        //Increase the number on items in the cart
        private void UpdateCartButtonText()
        {
            if (cart.GetContainer().Count < 1)
                button1.Text = "CART";
            else
                button1.Text = "CART(" + cart.GetContainer().Count + ")";
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Add_To_Cart_Click(object sender, EventArgs e)
        {
            cart.AddToContainer(((Games)((Button)sender).Tag));
            UpdateCartButtonText();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            NavButtonClick(Page.Browsing);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Receipt receipt = new Receipt();
            receipt.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NavButtonClick(Page.Browsing);
        }
    }
}
