using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APPD_layout
{
    class Catalogue : GenericContainer<Games>
    {

        public void LoadGames(string filepath, List<Genre> storeGenresReference)
        {
            string productFile = System.IO.File.ReadAllText(filepath);
            string[] key = { "name", "desc", "cost", "rdate", "imgsrc", "drate", "genre" };

            Regex gameSeperator = new Regex(@"<game>(.*?)</game>", RegexOptions.Singleline);
            MatchCollection match = gameSeperator.Matches(productFile);
            foreach (Match m in match)
            {
                Games game = new Games();

                object[] info = new string[key.Length];
                List<Genre> genres = new List<Genre>();

                Regex seperator;

                for (int i = 0; i < key.Length; i++)
                {
                    seperator = new Regex(@"<" + key[i] + @">(.*?)</" + key[i] + @">", RegexOptions.Singleline);

                    if (!key[i].Equals("genre"))
                    {
                        info[i] = Regex.Replace(seperator.Match(m.ToString()).ToString(), @"<" + key[i] + @">", "");
                        info[i] = Regex.Replace(info[i].ToString(), @"</" + key[i] + @">", "");
                    }
                    else
                    {
                        MatchCollection genreMatches = seperator.Matches(m.ToString());

                        foreach (Match gMatch in genreMatches)
                        {
                            string matchedString = Regex.Replace(gMatch.ToString(), @"<genre>", "");
                            matchedString = Regex.Replace(matchedString, @"</genre>", "");
                            bool genreRecordExist = false;

                            foreach (Genre g in storeGenresReference)
                            {
                                if (g.Name.Equals((matchedString)))
                                {
                                    genreRecordExist = true;
                                }
                            }

                            if (!genreRecordExist)
                            {
                                storeGenresReference.Add(new Genre(matchedString));
                            }

                            genres.Add(new Genre(matchedString));
                        }
                    }
                }

                game.SetInfo(
                    info[0].ToString(),
                    info[1].ToString(),
                    double.Parse(info[2].ToString()),
                    DateTime.Parse(info[3].ToString()),
                    info[4].ToString(),
                    double.Parse(info[5].ToString()),
                    genres);

                AddToContainer(game);
            }
        }
    }
}
