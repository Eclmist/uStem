using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APPD_layout
{
    public class Catalogue : GenericContainer<Games>
    {

        public void LoadGames(string filepath, List<GenreContainer> storeGenresReference)
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
                            string matchedString = gMatch.ToString();
                            matchedString = Regex.Replace(matchedString, "/n", "");
                            matchedString = Regex.Replace(matchedString, @"<genre>", "");
                            matchedString = Regex.Replace(matchedString, @"</genre>", "");
                            bool genreRecordExist = false;

                            foreach (GenreContainer g in storeGenresReference)
                            {
                                if (g.Name.Equals((matchedString)))
                                {
                                    genreRecordExist = true;
                                }
                            }

                            if (!genreRecordExist)
                            {
                                storeGenresReference.Add(new GenreContainer(matchedString));
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

                //Adding game to genrecontainers
                foreach (GenreContainer gc in storeGenresReference)
                {
                    foreach (Genre g in genres)
                    {
                        if (gc.Name.Equals(g.Name))
                        {
                            gc.AddToContainer(game);
                        }
                    }
                }
            }
        }
    }
}
