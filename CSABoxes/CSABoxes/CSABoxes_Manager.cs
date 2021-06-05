using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSABoxes
{
    class CSABoxes_Manager
    {
        private CSABoxes csaBoxes;
        private string firstAndLastName;
        public CSABoxes_Manager()
        {
            csaBoxes = new CSABoxes();
        }

        

        public void ShowMenu()
        {
            Console.Write("\nWhat is your first and last name? ");
            firstAndLastName = Console.ReadLine();

            char menuOption;

            do
            {
                Console.WriteLine("\n1. Start a CSA Box.");
                Console.WriteLine("2. Open an Existing CSA Box.");
                Console.WriteLine("3. Add a Product to your CSA Box.");
                Console.WriteLine("4. Delete a Product from your CSA Box.");
                Console.WriteLine("5. Exit from the App.");

                menuOption = Console.ReadKey().KeyChar;

                switch (menuOption)
                {
                    case '1':
                        StartCSABoxUI();
                        break;

                    case '2':
                        OpenExistingCSABoxUI();
                        break;

                    case '3':
                        AddProductUI();
                        break;

                    case '4':
                        DeleteProductUI();
                        break;

                }
            } while (menuOption != '5');
        }

        private void StartCSABoxUI()
        {
            Console.Write("\nWhat name would you like to give this box? ");
            string nameOfBox = Console.ReadLine();
            string deliveryDateString;

            SingleBox newBox;

            do
            {
                Console.Write("\nWhat day would you like your box to be delivered? (Please type in month/day/year) ");
                deliveryDateString = Console.ReadLine();

                if (deliveryDateString.Equals("ABORT", StringComparison.OrdinalIgnoreCase))
                    return;

                if (DateTime.TryParse(deliveryDateString, out DateTime deliveryDate))
                {
                    newBox = csaBoxes.Add(firstAndLastName, nameOfBox, deliveryDate);
                    Console.WriteLine($"\nThanks {firstAndLastName}, your delivery date is {deliveryDate.ToShortDateString()}.");
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid response. Please try again or hit \"abort\" to quit.");
                }
            } while (true);

            AddProductsToBox(newBox);

        }

        private bool ValidateProductIndexEntry(string optionNum, out int result)
        {
            if (!Int32.TryParse(optionNum, out result))
            {
                Console.Write("\nError: You must enter a number. ");
                return false;
            }

            if (result < 1 || result > FarmProducts.Options().Count)
            {
                Console.Write("\nError: You must enter a valid product number. ");
                return false;
            }
            return true;
        }

        private bool ValidateNumberOfItemsRequested(string numOfChosenItem, out int numOfItem)
        {
            if (!Int32.TryParse(numOfChosenItem, out numOfItem))
            {
                Console.Write("\nError: You must enter a number. ");
                return false;
            }
            if (numOfItem < 1)
            {
                Console.Write("\nError: You must enter a whole number greater than zero.");
                return false;
            }
            return true;
        }
        public void OpenExistingCSABoxUI()
        {

            Console.Write($"\nHi, {firstAndLastName}. ");

            if (csaBoxes.ListYourBoxes(firstAndLastName))
            {
                Console.Write("Please enter the name of the box you would like to open: ");
                string desiredBox = Console.ReadLine();
                csaBoxes.OpenYourDesiredBox(firstAndLastName, desiredBox);

            }
            else
            {
                Console.WriteLine("You have no boxes. Please go to \"Open a CSA Box\".");
                return;
            }
        }

        public void AddProductUI()
        {
            SingleBox newBox;


            Console.Write($"\nHi, {firstAndLastName}. ");

            if (csaBoxes.ListYourBoxes(firstAndLastName))
            {
                Console.Write("Please enter the name of the box you would like to open: ");
                string desiredBox = Console.ReadLine();
                newBox = csaBoxes.SetYourDesiredBox(firstAndLastName, desiredBox);

                foreach (CSABoxProduct product in newBox.ProductList)
                {
                    Console.WriteLine($"{product.ProductName}, {product.ProductQuantity}\n");
                }

            }
            else
            {
                return;
            }

            AddProductsToBox(newBox);
           

        }

        public void AddProductsToBox(SingleBox box)
        {
            bool addAnother = false;

            do
            {
                
                Console.WriteLine("\nOur farm products:\n");

                List<string> options = FarmProducts.Options();
                int optionIndex = 1;

                foreach (string option in options)
                {
                    Console.WriteLine(optionIndex + " " + option);
                    optionIndex++;
                }

                Console.Write("\nWhat would you like to add to your box? (Please type in the number or \"ABORT\" to exit.) ");
                string optionNum = Console.ReadLine();

                if (optionNum.Equals("abort", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                if (ValidateProductIndexEntry(optionNum, out int result))
                {

                    do
                    {
                        Console.Write("\nHow many would you like? (Or, type in \"ABORT\" to exit.) ");
                        string numOfChosenItem = Console.ReadLine();
                        if (numOfChosenItem.Equals("abort", StringComparison.OrdinalIgnoreCase))
                        {
                            return;
                        }

                        if (ValidateNumberOfItemsRequested(numOfChosenItem, out int numOfItem))
                        {
                            string newProductValue = options[result - 1];

                            box.Add_Product(newProductValue, numOfItem);

                            Console.WriteLine($"\nYour item {newProductValue} has been successfully added.");

                            Console.Write("\nWould you like to add another item to your box? ");
                            string addAnotherItemYesOrNo = Console.ReadLine();

                            if (addAnotherItemYesOrNo.Equals("yes", StringComparison.OrdinalIgnoreCase))
                            {
                                addAnother = true;
                            }
                            else if (addAnotherItemYesOrNo.Equals("no", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("\nYou have the following items in your box:");
                                foreach (CSABoxProduct product in box.ProductList)
                                {

                                    Console.WriteLine($"{product.ProductName}, {product.ProductQuantity}");
                                }
                                addAnother = false;
                            }
                            break;
                        }
                    } while (true);
                    
                }
                else
                {
                    addAnother = true;
                }

            } while (addAnother);
        }

        public void DeleteProductUI()
        {
            SingleBox newBox;

            Console.Write($"\nHi, {firstAndLastName}. ");
            int optionIndex = 1;

            if (csaBoxes.ListYourBoxes(firstAndLastName))
            {
                Console.Write("\nPlease enter the name of the box you would like to open: ");
                string desiredBox = Console.ReadLine();
                newBox = csaBoxes.SetYourDesiredBox(firstAndLastName, desiredBox);

                foreach (CSABoxProduct product in newBox.ProductList)
                {
                    Console.WriteLine($"{optionIndex} {product.ProductName}, {product.ProductQuantity}");
                    optionIndex++;
                }

            }
            else
            {
                return;
            }

            Console.Write("\nWhich product would you like to remove? (Please type in the number.) ");
            string productToRemove = Console.ReadLine();
            Int32.TryParse(productToRemove, out int removeProduct);
            newBox.DeleteItemByIndex(removeProduct - 1);

            if (newBox.ProductList.Count == 0)
            {
                Console.WriteLine($"You have no items in your box.");
            }

            while (newBox.ProductList.Count > 0)
            {
                Console.Write("\nWould you like to remove another item? ");
                string deleteAnotherItemYesOrNo = Console.ReadLine();


                if (deleteAnotherItemYesOrNo.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    optionIndex = 1;

                    foreach (CSABoxProduct product in newBox.ProductList)
                    {
                        Console.WriteLine($"{optionIndex} {product.ProductName}, {product.ProductQuantity}");
                        optionIndex++;
                    }

                    Console.Write("\nWhat item would you like to remove? ");
                    productToRemove = Console.ReadLine();
                    Int32.TryParse(productToRemove, out removeProduct);
                    newBox.DeleteItemByIndex(removeProduct - 1);

                    if(newBox.ProductList.Count == 0)
                    {
                        Console.WriteLine($"You have no items in your box.");
                    }
                }
                else if (deleteAnotherItemYesOrNo.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter \"yes\" or \"no\".");
                }
            }
        }
    }
}
