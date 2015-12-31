using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPD_layout
{
    class Genre : GenericContainer<Games>
    {

        private string genreName;

        #region Accessors and Mutators
        public string Name
        {
            get { return genreName; }
            set { genreName = value; }
        }
        #endregion

        public Genre(string name) {
            genreName = name;
        }
    }
}
