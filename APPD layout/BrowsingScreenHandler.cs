using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPD_layout
{
    public class BrowsingScreenHandler
    {
        FlowLayoutPanel gamesListPanel, genreSelectorPanel;
        List<CheckBox> allGenreCheckbox = new List<CheckBox>();
        List<Games> gamesToBeDisplayed = new List<Games>();
        BackgroundWorker BWPopulateGameList = new BackgroundWorker();
        int gamesPerPage = 10;

        public BrowsingScreenHandler(FlowLayoutPanel flp, FlowLayoutPanel gsp)
        {
            gamesListPanel = flp;
            genreSelectorPanel = gsp;
            GenreCheckEventHandler = GenreCheckHandler;
            BWPopulateGameList.DoWork += BWPopulateGameList_DoWork;
            BWPopulateGameList.RunWorkerCompleted += BWPopulateGameList_RunWorkerCompleted;
        }

        private void BWPopulateGameList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DrawGameListPanelControls();
        }

        //Attempt to optimise loading of games by running it in the background thread instead of the UI thread
        private void BWPopulateGameList_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] args = e.Argument as object[];
            gamesToBeDisplayed.Clear();

            if ((bool)args[0])
            {
                foreach (Games g in ((Catalogue)args[1]).GetContainer())
                {
                    gamesToBeDisplayed.Add(g);
                }
            }
            else
            {
                foreach (CheckBox c in allGenreCheckbox)
                {
                    if (c.Checked == true)
                    {

                        GenreContainer genreContainer = (GenreContainer)c.Tag;

                        foreach (Games g in genreContainer.GetContainer())
                        {
                            gamesToBeDisplayed.Add(g);
                        }
                    }
                }
            }
        }

        private void ShowListPanel(bool b)
        {
            gamesListPanel.Visible = b;
        }

        public void PopulateGameList()
        {
            object[] args = { false };
            BWPopulateGameList.RunWorkerAsync(args);
        }

        public void PopulateGameList(Catalogue catalogue)
        {
            object[] args = { true, catalogue };
            BWPopulateGameList.RunWorkerAsync(args);
        }

        public void DrawGameListPanelControls(int pageNumber)
        {
            gamesListPanel.Controls.Clear();

            for (int i = gamesPerPage * pageNumber; i < (gamesPerPage * pageNumber) + gamesPerPage; i++)
            {
                if (i < gamesToBeDisplayed.Count)
                    gamesListPanel.Controls.Add(ControlsGenerator.GenerateGamePanel(gamesToBeDisplayed[i]));
            }

            if (pageNumber > 0)
            {
                Button back = ControlsGenerator.GenerateBtn("<< BACK");
                back.Click += Nav_Click;
                back.Tag = pageNumber - 1;
                gamesListPanel.Controls.Add(back);
            }

            if (gamesToBeDisplayed.Count > gamesPerPage * (pageNumber + 1))
            {
                Button next = ControlsGenerator.GenerateBtn("NEXT >>");
                next.Click += Nav_Click;
                next.Tag = pageNumber + 1;
                gamesListPanel.Controls.Add(next);
            }
        }

        private void Nav_Click(object sender, EventArgs e)
        {
            int nextPageNumber = (int)((Button)sender).Tag;
            DrawGameListPanelControls(nextPageNumber);
        }

        public void DrawGameListPanelControls()
        {
            DrawGameListPanelControls(0);
        }
  
        public void PopulateGenreList(GenreContainer genre)
        {

            foreach (Games game in genre.GetContainer())
            {
                gamesListPanel.Controls.Add(ControlsGenerator.GenerateGamePanel(game));
            }
        }

        public void ClearGameListPanel()
        {
            gamesListPanel.Controls.Clear();
        }

        public void PopulateGenreSelector(List<GenreContainer> genrelist)
        {
            foreach (GenreContainer g in genrelist)
            {
                CheckBox c = ControlsGenerator.GenerateGenreSelectCheckbox(g, GenreCheckEventHandler);
                allGenreCheckbox.Add(c);
                genreSelectorPanel.Controls.Add(c);
            }
        }

        public static System.EventHandler GenreCheckEventHandler;

        private void GenreCheckHandler(object sender, EventArgs e)
        {
            bool check = false;

            foreach (CheckBox c in allGenreCheckbox)
            {
                if (c.Checked == true)
                    check = true;
            }

            if (check)
                PopulateGameList();
            else
                PopulateGameList(Store.allGamesCatalogue);
        }
    }
}
