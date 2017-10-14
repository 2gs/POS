using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class CreditCard:Payment
    {

        public override double payment()
        {
            double ccnum;

            Console.WriteLine("What is you credit card number?");
            ccnum = double.Parse(Console.ReadLine());

            return ccnum;

        }
    }
}
