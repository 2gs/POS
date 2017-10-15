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
                        double quantity = 0;
                        double price = 0;


                        bool going = true;
                        #region Display cart
                        Console.WriteLine("Add to cart");
                        Console.WriteLine("==================");
                        Console.WriteLine("==================");
                        Console.WriteLine("\n");

                        List<Product> ProductList = PrintList();                    //put list in array list and display product list

                        Console.WriteLine("=========================");
                        #endregion

                        List<Product> AddtoCart = new List<Product>();                        //New List to add their items to 
                        List<string> Name = new List<string>();                              //holds name of items being added to the receipt
                        List<Double> Total = new List<Double>();                           //holds totals of items being added to the receipt

                        #region Handles add to cart functionality
                        do
                        {
                            #region Variables to hold before tax, after tax, grand total, & sales tax amount
                            double bft, aft, gt, stx;       
                            bft = 0;
                            aft = 0;
                            gt = 0;
                            stx = .06;
                            #endregion

                            #region What does the user want

                            Console.WriteLine("\n");
                            Console.WriteLine("What do you want?" + " " + "If you want the 1st item select 1 etc....");
                            want = int.Parse(Console.ReadLine());
                            Console.WriteLine("How many do you want?");
                            quantity = double.Parse(Console.ReadLine());
                            Console.WriteLine("\n");

                            string name;
                            double total = 0;
                            
                            name = ProductList[want - 1].Name;  //get name of product user selected
                            price = ProductList[want - 1].Price;     //gets price of product that the user selected
                            total = price * quantity;       //stores subtotal for item


                           
                            Total.Add(quantity * price);     //Adds the item total to arraylist so I can use it later to find the before tax amount

                            //Adds up all totals to get the before tax amount
                            for (int i = 0; i < Total.Count; i++)
                            {
                                bft += Total[i];
                            }

                            aft = bft * stx;     //after tax amount
                            gt = bft + aft;             //grand total amount

                            //Add to Cart list which displays what the user added to their cart
                            AddtoCart.Add(new Product(ProductList[want - 1].Name, ProductList[want - 1].Price, ProductList[want - 1].Quantity, ProductList[want - 1].Total));

                            //Adds each item to Name ArrayList which is used as a receipt and will be displayed later
                            Name.Add("Item: " + name);
                            Name.Add("price: " + price.ToString("n2"));
                            Name.Add("qty: " + quantity.ToString());
                            Name.Add("total: " + total.ToString("n2"));

                            //Remove item from list selected by user
                            ProductList.RemoveAt(want - 1);

                            //Display list that the user is removing from removing from
                            Console.WriteLine("List you are removing from");
                            Console.WriteLine("++++++++++++++++++++++++++++");
                            for (int i = 0; i < ProductList.Count; i++)
                            {
                                Console.WriteLine(ProductList[i]);
                            }
                            Console.WriteLine("++++++++++++++++++++++++++++");
                            string choice = "";

                            bool control = true;
                            #region Do while loop to control question validation
                            do
                            {
                                Console.WriteLine("Do you want to Add another item?");
                                choice = Console.ReadLine();
                                Console.WriteLine("\n");
                                if (choice == "y" || choice == "n")
                                {
                                    control = false;
                                }
                                else if (choice != "y" || choice != "n")
                                {

                                    control = true;
                                }
                            } while (control);
                            #endregion
                            if (choice == "y" && ProductList.Count < 0)
                            {

                                Console.WriteLine("There re no more items left!!!!");
                                Console.WriteLine("Here is you list");

                                Console.WriteLine("The is the add cart list....");
                                Console.WriteLine();

                                //AddToCart ==> list that displays what user added to cart
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

                                //AddToCart ==> list that displays what user added to cart

                                Console.WriteLine("The is the add cart list....");
                                Console.WriteLine("++++++++++++++++++++++++++++");
                                Console.WriteLine();

                                for (int i = 0; i < AddtoCart.Count; i++)
                                {
                                    Console.WriteLine(AddtoCart[i]);
                                }
                                Console.WriteLine("++++++++++++++++++++++++++++");
                                Console.WriteLine("\n");

                                #region Display total, grand total, sales tax, before tax, after tax
                                Console.WriteLine("++++++++++++++++++++++++++++");
                                Console.WriteLine("Total before tax:" + " " + bft.ToString("n2"));
                                Console.WriteLine("Sales Tax:" + " " + stx);
                                Console.WriteLine("=========================");
                                Console.WriteLine("Total after tax:" + " " + aft);
                                Console.WriteLine("Grand total:" + " " + gt.ToString("n2"));
                                Console.WriteLine("++++++++++++++++++++++++++++");
                                Console.WriteLine("\n");
                                #endregion

                                #region Payment
                                string payment = "";
                                Console.WriteLine("How would you like to pay?");
                                payment = Console.ReadLine();


                                if (payment == "check")
                                {
                                    Check c = new Check();
                                    c.payment(gt);
                                }
                                else if (payment == "cash")
                                {
                                    Cash cash = new Cash();
                                    cash.payment(gt);
                                }
                                else if (payment == "credit card")
                                {
                                    CreditCard cc = new CreditCard();
                                    cc.payment(gt);
                                }
                                #endregion

                                Console.WriteLine("\n");

                                #region Receipt
                                Console.WriteLine("++++++++++++++++++++++++++++");
                                Console.WriteLine("Here is your receipt");
                                Console.WriteLine("++++++++++++++++++++++++++++");

                                for (int i = 0; i < Name.Count; i++)
                                {
                                    Console.Write(Name[i] + " ");
                                    Console.WriteLine("\n");

                                }


                                Console.WriteLine("++++++++++++++++++++++++++++");
                                Console.WriteLine("Total before tax:" + " " + bft.ToString("n2"));
                                Console.WriteLine("Sales Tax:" + " " + stx);
                                Console.WriteLine("=========================");
                                Console.WriteLine("Total after tax:" + " " + aft);
                                Console.WriteLine("Grand total:" + " " + gt.ToString("n2"));
                                Console.WriteLine("++++++++++++++++++++++++++++");
                                #endregion

                                going = false;


                            }
                        } while (going);
                        #endregion
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
