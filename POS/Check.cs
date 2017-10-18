using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POS
{
    class Check : Payment
    {
        public override void payment(double gt)
        {
            //double Input = 0;
            string checkNumber;

            bool going = true;
            Console.WriteLine("Please enter your five digit check number");
            while (going == true)
            {

                // ReadValidInteger();
                checkNumber = Console.ReadLine();


                if (!Regex.IsMatch(checkNumber, "^\\d{5}$"))    //check check pattern for 5
                {
                    Console.WriteLine("Please enter a valid check number.");
                    // going = true;
                    // checkNumber = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You have wrote a check:" + checkNumber);
                    Console.WriteLine("Thank you for your purchase.");
                    going = false;
                }
            }
        }
    }
}
