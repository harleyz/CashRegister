using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.Models.Repositories;

/* 
    The 3 main requirements are:

    It needs to be able to scan items in by quantity and weight
    It needs to be able to handle discount coupons… allow for two different types of coupons
    % off total
    Buy ‘x’ get ‘y’ free (i.e. buy 3 get 1 free)
    It should be able to provide a caller with a total cost and a list of items
 
 */

namespace CashRegister
{
    class Program
    {
        const string errormsg = "Unable to parse command, please type HELP for assistance.";

        static void Main(string[] args)
        {
            ItemRepository itemRepo;
            ReceiptRepository recieptRepo;

            Console.WriteLine("Welcome to cash register, type help for assistance.");

            while (true)
            {
                string input = Console.ReadLine();

                input = input.ToUpper();

                switch (input)
                {
                    case "EXIT":
                        {
                            return;
                        }
                    case "HELP":
                        {
                            Console.WriteLine("- Enter EXIT to exit this application");
                            Console.WriteLine("- Enter CLS to clear the screen");
                            Console.WriteLine("- Enter BEGIN to begin a new transaction");
                            Console.WriteLine("- Enter PURCHASE to buy an item");
                            Console.WriteLine("- Enter COUPON to enter discount");
                            Console.WriteLine("- Enter RECEIPT to view the receipt");
                            Console.WriteLine("- Enter END to finish the transaction");
                            break;
                        }
                    case "CLS":
                        {
                            Console.Clear();
                            break;
                        }

                    case "BEGIN":
                        {
                            try
                            {
                                recieptRepo = new ReceiptRepository();
                                Console.WriteLine(input + recieptRepo._receipt.Id);
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.InnerException);
                            }

                            break;
                        }

                    case "PURCHASE":
                        {
                            try
                            {
                                Console.WriteLine("- Enter Product Name or SKU");
                                string purchaseInput = Console.ReadLine();
                                if (Guid.TryParse(purchaseInput, out Guid newOutGuid))
                                    Console.WriteLine("- Entered {0}", newOutGuid);
                                else
                                    Console.WriteLine("- Entered {0}", purchaseInput);
                            }
                            catch
                            {
                                Console.WriteLine(errormsg);
                            }

                            break;
                        }

                    case "COUPON":
                        {
                            try
                            {
                                Console.WriteLine(input);
                            }
                            catch
                            {
                                Console.WriteLine(errormsg);
                            }

                            break;
                        }

                    case "RECEIPT":
                        {
                            try
                            {
                                Console.WriteLine(input);
                            }
                            catch
                            {
                                Console.WriteLine(errormsg);
                            }

                            break;
                        }
                    case "END":
                        {
                            try
                            {
                                Console.WriteLine(input);
                            }
                            catch
                            {
                                Console.WriteLine(errormsg);
                            }

                            break;
                        }
                    default:
                        {
                            Console.WriteLine(errormsg);
                            break;
                        }
                }
            }
        }
    }
}
