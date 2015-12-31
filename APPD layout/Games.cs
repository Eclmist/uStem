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
        private List<Genre> genres;

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

        public List<Genre> Genre
        {
            get { return genres; }
        }

        #endregion

        public Games()
        {
            name = "";
            desc = "";
            imgsrc = "game1.png";
            cost = 0;
            discountrRate = 0;
            releaseDate = DateTime.MaxValue;
            genres = new List<Genre>();
        }

        public Games(string name, string desc, double cost, DateTime rdate, string imgsrc, double drate, List<Genre> genres)
        {
            this.name = name;
            this.desc = desc;
            this.cost = cost;
            this.releaseDate = rdate;
            this.imgsrc = imgsrc;
            this.discountrRate = drate;
            this.genres = genres;
        }

        public void SetInfo(string name, string desc, double cost, DateTime rdate, string imgsrc, double drate, List<Genre> genres)
        {
            if (!name.Equals(""))
                this.name = name;
            if (!desc.Equals(""))
                this.desc = desc;
            if (!double.IsNaN(cost))
                this.cost = cost;
            if (releaseDate != null)
                this.releaseDate = rdate;
            if (!imgsrc.Equals(""))
                this.imgsrc = imgsrc;
            if (!double.IsNaN(discountrRate))
                this.discountrRate = drate;
            if (genres.Count > 0)
                this.genres = genres;
        }
    }
}
