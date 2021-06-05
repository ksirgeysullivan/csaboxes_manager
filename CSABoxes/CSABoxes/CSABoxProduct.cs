using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSABoxes
{
    public class CSABoxProduct
    {
        public string ProductName { get; set; }

        public int ProductQuantity { get; set; }

        public CSABoxProduct(string name, int quantity)
        {
            ProductName = name;
            ProductQuantity = quantity;
        }
    }
}
