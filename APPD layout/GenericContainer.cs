using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPD_layout
{
    public class GenericContainer<T>
    {
        public GenericContainer()
            {}

        List<T> items = new List<T>();

        public virtual void AddToContainer(T item) //Override for Cart (add count instead of another item to list;
        {
            items.Add(item);
        }

        public List<T> GetContainer()
        {
            return items;
        }


    }
}
