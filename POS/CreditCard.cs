using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class CreditCard:Payment
    {

        public override void payment(double gt)
        {
            string ccnum;
            ccnum = "";
            double ccv;
            double exp;
            bool going;
            going = true;
            do
            {
                Console.WriteLine("What is you credit card number?");
                ccnum = Console.ReadLine();

                if (ccnum.Length > 16)
                {
                    Console.WriteLine("Invalid Credit Card #..Try again");
                }
            } while (going);
            

           

            Console.WriteLine("What is your CCV? 3 digit code on the back of your card");
            ccv = double.Parse(Console.ReadLine());
            Console.WriteLine("What is your exiration date?");
            exp = double.Parse(Console.ReadLine());
            Console.WriteLine("You card is being charged...");
            Console.WriteLine("You were charged" + gt.ToString("n2") + " to your credit card");

  

        }
    }
}
