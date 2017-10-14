using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class Program
    {
        //List<Product>
        public static List<Product> PrintList()
        {
            Console.WriteLine("What do you want ot buy?");
            StreamReader rd = new StreamReader("products.txt");


            List<Product> ProductList = new List<Product>();

            string str = rd.ReadLine();// read one line (first line)

            while (str != null)// while we still have more lines to read 
            {
                string[] tempCar = str.Split(',');

                ProductList.Add(new Product(tempCar[0],
                     tempCar[1],
                    tempCar[2],
                     double.Parse(tempCar[3])));

                str = rd.ReadLine();// read the next line
            }

            foreach (Product Element in ProductList)
            {
                Console.WriteLine(Element.ToString());
            }
            return ProductList;

        }

        public static void removeFromList(int want, List<Product> AddToCart, List<Product> ProductList)
        {
            for (int i = 0; AddToCart.Count < i; i++)
            {
                AddToCart.Add(ProductList[want - 1]);
            }
            // return AddToCart;
        }
        public static void AddToCart(int want, List<Product> AddToCart, List<Product> ProductList)
        {
            string choice;
            bool going = true;
            for (int i = 0; AddToCart.Count < i; i++)
            {
                AddToCart.Add(ProductList[want - 1]);
            }
            //Display items left
            //   ItemsLeft(ProductList);

            //   AddtoCart.Add(ProductList[want]);
            // ProductList.RemoveAt(want);
            Console.WriteLine("\n");
            Console.WriteLine("Do you want to Add another item?");
            choice = Console.ReadLine();
            if (choice == "y")
            {
                going = true;
            }
            else if (choice == "n")
            {
                going = false;
            }
        }


        public static void ItemsLeft(List<Product> ProductList)
        {
            Console.WriteLine("Items left on the cart");
            Console.WriteLine("=======================");

            for (int i = 0; i < ProductList.Count; i++)
            {
                Console.WriteLine(ProductList[i]);
            }
            Console.WriteLine("=======================");
        }
        static void Main(string[] args)
        {


            //int input = 0;
            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine("MENU");
                Console.WriteLine("Please enter the number that you want to do:");
                Console.WriteLine("1. View");
                Console.WriteLine("2. Add");
                Console.WriteLine("3.exit");

                int menuchoice = int.Parse(Console.ReadLine());

                switch (menuchoice)
                {
                    case 1:
                        PrintList();

                        break;
                    case 2:
                        int want = 0;
                          double  quantity= 0;
                        double price,total = 0;
                        string choice;
                        bool going = true;

                        Console.WriteLine("Add to cart");
                        Console.WriteLine("==================");
                        Console.WriteLine("==================");
                        Console.WriteLine("\n");

                        List<Product> ProductList = PrintList();                    //put list in array list and display product list
                        List<Product> AddtoCart = new List<Product>();      //New List to add their items to 
                        //List<Product> Receipt = new List<Product>();
                        
                        do
                        {
                            List<Receipt> str = new List<Receipt>();
                            Console.WriteLine("\n");
                            Console.WriteLine("What do you want?" + "If you wnt the 1st item select 1 etc....");
                            want = int.Parse(Console.ReadLine());
                            Console.WriteLine("How many do you want?");
                            quantity = double.Parse(Console.ReadLine());
                            
                            string name;
                         

                            //List<Receipt> str = new List<Receipt>();
                            //str.Add(new Receipt(ProductList[1 - want].Name, ProductList[1 - want].Price,quantity,total));

                          //  Console.WriteLine(name + " " + "quantity:" + quantity + " "  + "Total:" + total);
                            //Add to Cart
                            AddtoCart.Add(new Product(ProductList[want-1].Name, ProductList[want-1].Price, ProductList[want-1].Quantity, ProductList[want-1].Total));
                            name = ProductList[want - 1].Name;
                            price = ProductList[want - 1].Price;
                            total = price * quantity;

                            str.Add(new Receipt(name, price, quantity, total));
                                //(new Receipt(ProductList[want-1].Name, ProductList[want-1].Price, quantity, total));


                            ProductList.RemoveAt(want-1);                         //remove item from list

                            //Display list you removing from
                            Console.WriteLine("List you are removing from");
                            Console.WriteLine("++++++++++++++++++++++++++++");
                            for (int i = 0; i < ProductList.Count; i++)
                            {
                                Console.WriteLine(ProductList[i]);
                            }
                            Console.WriteLine("++++++++++++++++++++++++++++");


                            Console.WriteLine("Do you want to Add another item?");
                            choice = Console.ReadLine();
                            if (choice == "y" && ProductList.Count < 0)
                            {

                                Console.WriteLine("There re no more items left!!!!");
                                Console.WriteLine("Here is you list");

                                Console.WriteLine("The is the add cart list....");
                                Console.WriteLine();
                                for (int i = 0; i < AddtoCart.Count; i++)
                                {
                                    Console.WriteLine(AddtoCart[i]);
                                }
                                Console.WriteLine("\n");

                                going = false;
                            }
                            else if (choice == "y" && ProductList.Count > 0)
                            {
                                going = true;
                            }
                            else if (choice == "n")
                            {
                                Console.WriteLine("The is the add cart list....");
                                Console.WriteLine();
                                for (int i = 0; i < AddtoCart.Count; i++)
                                {
                                    Console.WriteLine(AddtoCart[i]);
                                }
                                Console.WriteLine("++++++++++++++++++++++++++++");

                                Console.WriteLine("Here is your receipt");
                                Console.WriteLine("++++++++++++++++++++++++++++");
                                for (int i = 0; i < str.Count; i++)
                                {
                                    Console.WriteLine(str[i].Name + " " + str[i].Price + "" + str[i].Quantity + " "  + str[i].Total);
                                }
                                Console.WriteLine("++++++++++++++++++++++++++++");
                                going = false;

                                
                            }
                        } while (going);

                        
                        /*
                        #region Payment
                        string payment = "";
                        Console.WriteLine("How would you like to pay?");
                        payment = Console.ReadLine();

                        if(payment == "check")
                        {

                        }
                        else if(payment == "cash")
                        {

                        }
                        else if (payment == "check")
                        {

                        }
#endregion
*/
                        break;
                    case 3:
                        Console.WriteLine("exit");
                        Environment.Exit(1); //edit
                        break;
                    default:
                        Console.WriteLine("Sorry, invalid selection");
                        break;
                }

            }
        }
    }
}
