using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPD_layout
{
    class Action : Games
    {
        public int game_number;
        public Action(int g_no, string gn, string d, double c) : base (gn, d, c) {
            game_number = g_no;
            }
        public int GameNumber
        {
            get { return game_number; }
            set { game_number = value; }
        }
        public string ActionGetInfo()
        {
            string info = "";
            GameDetails gd = new GameDetails();
            return info;
        }
    }
}
