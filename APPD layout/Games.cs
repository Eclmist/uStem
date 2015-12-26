using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPD_layout
{
    class Games //Base class
    {
        private string game_name;
        private string description;
        private double cost;

        public Games(string gn, string d, double c)
        {
            game_name = gn;
            description = d;
            cost = c;
        }

        public string Name
        {
            get { return game_name; }
            set { game_name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description  = value; }
        }

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
    }
}
