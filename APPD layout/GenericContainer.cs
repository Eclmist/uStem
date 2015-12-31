using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPD_layout
{
    class GenericContainer<T>
    {
        List<T> items = new List<T>();

        public void AddToContainer(T item)
        {
            items.Add(item);
        }

        public List<T> GetContainer()
        {
            return items;
        }
    }
}
