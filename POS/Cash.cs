using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class Cash:Payment
    {
        public override void payment(double gt)
        {
            double payment;
            double change;
            Console.WriteLine("Enter in your payment:");
            payment = Double.Parse(Console.ReadLine());
            change = payment - gt;
            Console.WriteLine("Your payment amount: " + payment + " and your change: " + change);

        }
    }
}
