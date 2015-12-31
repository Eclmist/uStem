using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPD_layout
{   
    public class GenreContainer : GenericContainer<Games>
    {

        private string genreName;

        #region Accessors and Mutators
        public string Name
        {
            get { return genreName; }
            set { genreName = value; }
        }
        #endregion

        public GenreContainer(string name) {
            genreName = name.First().ToString().ToUpper() + String.Join("", name.Skip(1));
        }
    }
}
