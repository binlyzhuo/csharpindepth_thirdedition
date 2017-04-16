using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chpt1
{
    public class ProductNameComparer:IComparer<Product>
    {
        public int Compare(Product x,Product y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
