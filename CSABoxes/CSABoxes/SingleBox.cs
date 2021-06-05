using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSABoxes
{
    class SingleBox
    {
        public string Name { get; set; }

        public string NameOfBox { get; set; }
        public DateTime DeliveryDate { get; set; }
        public List<CSABoxProduct> ProductList { get; private set; }

        public SingleBox()
        {
            ProductList = new List<CSABoxProduct>();
        }

        public void Add_Product(string name, int quantity)
        {
            CSABoxProduct newProduct = new CSABoxProduct(name, quantity);
            ProductList.Add(newProduct);
        }
        
        public bool DeleteItemByIndex(int removeProductIndex)
        {

            if(removeProductIndex >=0 && removeProductIndex < ProductList.Count)
            {
                CSABoxProduct removeProduct = ProductList[removeProductIndex];
                ProductList.RemoveAt(removeProductIndex);
                Console.WriteLine($"Your item {removeProduct.ProductName} has been successfully removed.");
                return true;

            } else
            {
                return false;
            }
            
        }
        //public bool DeleteItemInProductList(string removeItem)
        //{
        //    CSABoxProduct deleteItem = null;

        //    foreach (CSABoxProduct item in ProductList)
        //    {
        //        if (item.ProductName.Equals(removeItem))
        //        {
        //            deleteItem = item;
        //            break;
        //        }
        //    }

        //    if (deleteItem != null)
        //    {
        //        ProductList.Remove(deleteItem);
        //        Console.WriteLine($"Your item {deleteItem} has been successfully removed.");
        //        Console.WriteLine($"You have {ProductList.Count} items in your box.");
        //        foreach(CSABoxProduct item in ProductList)
        //        {
        //            Console.WriteLine($"{item.ProductName}, {item.ProductQuantity}\n");
        //        }
        //        return true;
        //    } else
        //    {
        //        return false;
        //    }

        //}
    }
}
