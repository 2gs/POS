using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class Check:Payment
    {
        public override void payment(double gt)
        {
            string checknumber = "";
            bool going = true;
            do
            {
                Console.WriteLine("Enter your check #..");
                checknumber = Console.ReadLine();
                if (checknumber.Length < 7)
                {
                    going = true;
                }
                else if (checknumber.Length == 7)
                {
                    Console.WriteLine(checknumber + " is a valid Check number");
                    going = false;
                }
            } while (going);
            
            Console.WriteLine("\n");
            Console.WriteLine("Processing...");
            Console.WriteLine("You have wrote a check:" + checknumber + " for the amount of " + gt);
         }
    }
}
