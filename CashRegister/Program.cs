using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.Models;
using CashRegister.Models.Repositories;


/* 
    I went with a repository approach - it was not necessary at all for this project however it is scalable and reusable 
    and hopefully a different approach than you usually recieve.  The DB is live on azure, and the firewall is removed, if you want to use it (I included the pass in source control).
    If not please publish the DB to a local DB using the SQL project, the data will seed itself during execution.  The Cheers!

    Sample input:
        help
        begin
        purchase
        apples
        2.5
        oranges
        2
        pinapple pizza
        1
        list
        total
        coupon
        3APPLES1FREE
        coupon
        20PERCENT
        end
        exit


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
            ItemRepository itemRepo = null;
            ReceiptRepository recieptRepo = null;
            TransactionRepository transactionRepo = null;
            DiscountRepository discountRepo = null;
            DiscountTransactionRepository discountTransactionRepo = null;

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
                            Console.WriteLine("- Enter TOTAL to view the total");
                            Console.WriteLine("- Enter LIST to view the receipt");
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
                                if(recieptRepo == null)
                                {
                                    recieptRepo = new ReceiptRepository();
                                    Console.WriteLine(input + " - reciept #" + recieptRepo._receipt.Id);
                                } else
                                {
                                    Console.WriteLine("Please end current transaction using the END command");
                                }
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
                                itemRepo = new ItemRepository();                         

                                Console.WriteLine("- Enter Product Name or SKU");
                                string purchaseInput = Console.ReadLine();
                                decimal quantity;

                                itemRepo.Find(purchaseInput);
                                if (itemRepo._item != null)
                                {
                                    Console.WriteLine("- Entered {0}", purchaseInput);
                                    //ask for weight or quantity here?
                                    quantity = RequestDecimal("Please enter a quantity");
                                    Console.WriteLine("- Entered {0}", quantity.ToString());

                                    transactionRepo = new TransactionRepository();
                                    transactionRepo.New(recieptRepo._receipt.Id, itemRepo._item.Id, quantity);
                                }
                                else
                                {
                                    //add suggestions (e.g. did you mean X?)
                                    Console.WriteLine("- {0} was not found in the inventory", purchaseInput);
                                }
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.InnerException);
                            }

                            break;
                        }

                    case "COUPON":
                        {
                            try
                            {
                                discountRepo = new DiscountRepository();

                                Console.WriteLine("- Enter Code or SKU");
                                string discountInput = Console.ReadLine();

                                discountRepo.Find(discountInput);
                                if (discountRepo._discount != null)
                                {
                                    Console.WriteLine("- Entered {0}", discountRepo._discount.Code);

                                    //check validity then apply
                                    if (discountRepo.IsValid(recieptRepo._receipt.Id))
                                    {
                                        discountTransactionRepo = new DiscountTransactionRepository();
                                        discountTransactionRepo.New(recieptRepo._receipt.Id, discountRepo._discount.Id, discountRepo._discount.ItemId);

                                        Console.WriteLine(discountTransactionRepo.WriteTotal(recieptRepo._receipt.Id));
                                    } else
                                    {
                                        Console.WriteLine("- {0} was not a valid coupon", discountInput);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("- {0} was not a valid coupon", discountInput);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.InnerException);
                            }

                            break;
                        }

                    case "TOTAL":
                        {
                            try
                            {
                                Console.WriteLine(input); 
                                if (recieptRepo == null)
                                {
                                    Console.WriteLine("Please begin a new transaction using the BEGIN command.");
                                }
                                else
                                {
                                    //print discount too
                                    Console.WriteLine(recieptRepo.Total());
                                }                                
                            }
                            catch
                            {
                                Console.WriteLine(errormsg);
                            }

                            break;
                        }

                    case "LIST":
                        {
                            try
                            {
                                Console.WriteLine(input);
                                if (recieptRepo == null)
                                {
                                    Console.WriteLine("Please begin a new transaction using the BEGIN command.");
                                }
                                else
                                {
                                    Console.WriteLine(recieptRepo.WriteList());
                                }
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
                                //print receipt here
                                recieptRepo = null;
                                Console.WriteLine("Transaction ended");
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

        static decimal RequestDecimal(string message)
        {
            decimal result;
            do
            {
                Console.WriteLine(message);
            }
            while (!decimal.TryParse(Console.ReadLine(), out result));
            return result;
        }
    }
}
