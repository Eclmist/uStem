using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APPD_layout
{
    class Games
    {
        private string name, desc, imgsrc;
        private double cost, discountrRate;
        private DateTime releaseDate;

        public Games()
        {
            name = "";
            desc = "";
            imgsrc = "";
            cost = 0;
            discountrRate = 0;
            releaseDate = DateTime.MaxValue;
        }

        public Games(string name, string desc, double cost, DateTime rdate, string imgsrc, double drate)
        {
            this.name = name;
            this.desc = desc;
            this.cost = cost;
            this.releaseDate = rdate;
            this.imgsrc = imgsrc;
            this.discountrRate = drate;
        }

        public void SetInfo(string name, string desc, double cost, DateTime rdate, string imgsrc, double drate)
        {
            this.name = name;
            this.desc = desc;
            this.cost = cost;
            this.releaseDate = rdate;
            this.imgsrc = imgsrc;
            this.discountrRate = drate;
        }

        public static void LoadGames()
        {
            string productFile = System.IO.File.ReadAllText("./product.txt");
            string[] key = { "name", "desc", "cost", "rdate", "imgsrc", "drate" };

            Regex gameSeperator = new Regex(@"<game>(.*?)</game>", RegexOptions.Singleline);
            MatchCollection match = gameSeperator.Matches(productFile);
            foreach (Match m in match)
            {
                Games game = new Games();

                string[] info = new string[key.Length];
                Regex seperator;    

                for (int i = 0; i < key.Length; i++)
                {
                    seperator = new Regex(@"<" + key[i] + @">(.*?)</" + key[i] + @">", RegexOptions.Singleline);
                    info[i] = Regex.Replace(seperator.Match(m.ToString()).ToString(), @"<" + key[i] + @">", "");
                    info[i] = Regex.Replace(info[i], @"</" + key[i] + @">", "");

               }

                game.SetInfo(info[0], info[1], double.Parse(info[2]), DateTime.Parse(info[3]), info[4], double.Parse(info[5]));
                Catalogue.allGames.Add(game);
            }
        }
    }
}
