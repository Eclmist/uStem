using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPD_layout
{
    class Games
    {
        private string name, desc, imgsrc;
        private double cost, discountrRate;
        private DateTime releaseDate;


        #region Accessors and Mutators
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        public string Imgsrc
        {
            get { return imgsrc; }
            set { imgsrc = value; }
        }

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public double DiscountRate
        {
            get { return discountrRate; }
            set { discountrRate = value; }
        }

        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        #endregion

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
    }
}
