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
            //double cvv;
            //double exp;
            bool going;
            going = true;
            #region Validation for Credit Card #
            do
            {
                Console.WriteLine("What is you credit card number? PLease enter 16 digits...");
                ccnum = Console.ReadLine();
                Console.WriteLine("\n");
                double cc;
                if(!Double.TryParse(ccnum,out cc)){
                    Console.WriteLine( "Invalid credit card #....");
                }
                else if (Double.TryParse(ccnum, out cc))
                {
                    if (ccnum.Length > 16 || ccnum.Length < 16)
                    {
                        Console.WriteLine("Invalid Credit Card #..Try again");
                        going = true;
                    }
                    else if (ccnum.Length == 16)
                    {
                        Console.WriteLine("This is a valid card number: " + ccnum);
                        Console.WriteLine("\n");
                        going = false;
                    }
                }
                
            } while (going);
                #endregion

          //  bool control = true;
            bool ctl = true;
            #region Validation for CVV #
            while (ctl)
            {

                string num = "";
                double result;
                    Console.WriteLine("What is your CVV? 3 digit code on the back of your card");
                    num = Console.ReadLine();
                if(!Double.TryParse(num, out result) )
                {
                    ctl = true;
                }
                else if (Double.TryParse(num, out result))
                {
                    if (result < 100 || result > 999)
                    {
                        Console.WriteLine("Invalid CCV #...");
                        Console.WriteLine("\n");
                        ctl = true;
                    }
                    else if (result <= 999 & result >= 100)
                    {
                        Console.WriteLine("Valid CVV #...");
                        Console.WriteLine("\n");
                        string something = "";
                        bool keep = true;
                        do
                        {
                            Console.WriteLine("What is your exiration date?");
                            something = Console.ReadLine();
                            double cc;
                            if (!Double.TryParse(something, out cc))
                            {
                                Console.WriteLine("Invalid expiration date");
                                keep = true;
                            }
                            else if (Double.TryParse(something, out cc))
                            {
                                if (something.Length > 4 || something.Length < 4)
                                {
                                    Console.WriteLine("I need the correct numbers for the dte to process your transaction..");
                                    keep = true;
                                }
                                else if (something.Length == 4)
                                {
                                    Console.WriteLine("Correct #'s for the date have been put in..");
                                    keep = false;
                                }


                            }
                        } while (keep);
                     

                        Console.WriteLine("You card is being charged...");
                        Console.WriteLine("+++++++++++++++++++++++++++++++");
                        Console.WriteLine("You was charged " + gt.ToString("n2") + " to your credit card: " + ccnum + " with the CVv # " + result + " and exp date of " + something);
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                        ctl = false;
                    }
                    
                }

            }
            #endregion
        }
    }
}
