using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSABoxes
{
    class CSABoxes
    {
        private List<SingleBox> boxes;

        public CSABoxes()
        {
            boxes = new List<SingleBox>();
        }

        public int Count
        {
            get { return boxes.Count; }
        }

        public void Add(SingleBox box)
        {
            boxes.Add(box);
        }

        public SingleBox Add(string name, string nameOfBox, DateTime deliveryDate)
        {
            SingleBox newBox = new SingleBox();
            newBox.Name = name;
            newBox.NameOfBox = nameOfBox;
            newBox.DeliveryDate = deliveryDate;
            Add(newBox);

            return newBox;
        }

        public bool ListYourBoxes(string firstAndLastName)
        {
            int counter = 0;
            string returnValue = String.Empty;
            foreach(SingleBox box in boxes)
            {
                if(box.Name.Equals(firstAndLastName,StringComparison.OrdinalIgnoreCase))
                {
                    counter++;
                    returnValue += $"{box.NameOfBox}\n";
                }
                
            }

            if (counter > 0)
            {
                Console.WriteLine($"You have {counter} boxes:");
                Console.WriteLine(returnValue);

                return true;
            }
            else
            {
                return false;
            }

        }

        public void OpenYourDesiredBox(string firstAndLastName, string nameOfBox)
        {
            foreach (SingleBox box in boxes)
            {
                if (box.Name.Equals(firstAndLastName, StringComparison.OrdinalIgnoreCase) && box.NameOfBox.Equals(nameOfBox, StringComparison.OrdinalIgnoreCase)
                    )
                {
                    Console.WriteLine($"You have {box.ProductList.Count} items in your box:\n");

                    foreach (CSABoxProduct product in box.ProductList)
                    {
                        Console.WriteLine($"{product.ProductName}, {product.ProductQuantity}\n");
                    }
                }

            }
        }

        public SingleBox SetYourDesiredBox(string firstAndLastName, string desiredBox)
        {
            foreach (SingleBox box in boxes)
            {
                if (box.Name.Equals(firstAndLastName, StringComparison.OrdinalIgnoreCase) && box.NameOfBox.Equals(desiredBox, StringComparison.OrdinalIgnoreCase)
                    )
                {
                    return box;

                }

            }

            return null;
        }
    }
}
