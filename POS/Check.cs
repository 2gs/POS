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
            Console.WriteLine("Enter your check #..");
            checknumber = Console.ReadLine();
            Console.WriteLine("Processing...");
            Console.WriteLine("You have wrote a check:" + checknumber + " for the amount of " + gt);
         }
    }
}
