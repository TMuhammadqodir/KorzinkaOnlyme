using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korzinka
{
    internal class GiveProduct
    {
        string Name = "";

        string Amount = "";

        public GiveProduct()
        {

        key:

            try
            {
                ShowProduct showProduct = new ShowProduct(false);            
    
                GiveProductDesign();

                GiveProductSelectFunction();

            }
            catch
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                                  "| Please enter correct information! |\n" +
                                  "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.ResetColor();

                goto key;
            }
        }


        public void GiveProductSelectFunction()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Select>>> ");

            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    {
                        Console.Write("name: ");
                         Name = Console.ReadLine();
                        Console.Clear();

                        ShowProduct showProduct = new ShowProduct(false);
                        GiveProductDesign();
                        GiveProductSelectFunction();
                        break;
                    }
                case 2:
                    {
                        Console.Write("amount: ");
                         Amount = Console.ReadLine();
                        Console.Clear();

                        ShowProduct showProduct = new ShowProduct(false);
                        GiveProductDesign();
                        GiveProductSelectFunction();
                        break;
                    }
                case 3:
                    {
                        if ( Name.Length > 0 && Amount.Length > 0 && float.Parse(Amount.Split()[0]).GetType() == typeof(float))
                        {
                            if (WorkWithFile.GetProductFromFile(Name, Amount))
                            {
                                Console.Clear();
                                GiveProduct giveProduct = new GiveProduct();
                            }
                            else
                            {
                                throw new Exception();
                            }

                        }
                        else
                        {
                            throw new Exception();
                        }


                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        Menu menu1 = new Menu();
                        break;
                    }

                default:
                    {
                        throw new Exception();
                    }

            }

            Console.ResetColor();
        }


        public void GiveProductDesign()
        {
            int nameLength = Name.Length > 20 ? 21 : Name.Length;
            int amountLength = Amount.Length > 18 ? 19 : Amount.Length;

            string name = Name[..nameLength];
            string amount = Amount[..amountLength];

            string standarter = "                     ";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                             $"| 1. Enter name {name}{standarter[..(21 - nameLength)]}|\n" +
                             $"| 2. Enter amount {amount}{standarter[..(21 - amountLength - 2)]}|\n" +
                              "| 3. Give product                    |\n" +
                              "| 4. back                            |\n" +
                              "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"); ;

            Console.ResetColor();
        }
    }
}
