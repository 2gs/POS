using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class Cash : Payment
    {
        public override void payment(double gt)
        {
            double payment;
            double change;
           
            payment = ReadValidInteger();
            change = payment - gt;
            Console.WriteLine("Thanks for your payment amount of: " + payment + ". Here is your change: " + change.ToString("n2"));
        }
        //method for validation of user input
        public static double ReadValidInteger()
        {
            Console.WriteLine("Please enter a number: ");
            //int Input = int.Parse(Console.ReadLine());
            double Input = 0;
            while (!double.TryParse(Console.ReadLine(), out Input)) //converts string to a number as long as the number is valid. returns true or false.
            {
                Console.WriteLine("Please enter a number");
            }
            return Input;
        }
    }
}
