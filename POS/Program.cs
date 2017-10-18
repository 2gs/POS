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
            Console.WriteLine("What do you want to buy?");
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
            
           
            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine("MENU");
                Console.WriteLine("++++++++++++++++++++++++++++");
                Console.WriteLine("Please select a option:");
                Console.WriteLine("1. View");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Exit");
                Console.WriteLine("++++++++++++++++++++++++++++");

                int menuchoice = int.Parse(Console.ReadLine());

                switch (menuchoice)
                {
                    case 1:
                        PrintList();

                        break;
                    case 2:
                        MenuOption2.option2();
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