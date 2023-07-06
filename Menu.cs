using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korzinka
{
    internal class Menu
    {

        
        public Menu() {

            SelectProduct();
        }





        public void DesignMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><>\n|                                          |\n" +
                              "| 1. Show Product                          |\n|                                          |\n" +
                              "<><><><><><><><><><><><><><><><><><><><><><>\n|                                          |\n" +
                              "| 2. Add Product                           |\n|                                          |\n" +
                              "<><><><><><><><><><><><><><><><><><><><><><>\n|                                          |\n" +
                              "| 3. Give Product                          |\n|                                          |\n" +
                              "<><><><><><><><><><><><><><><><><><><><><><>\n|                                          |\n" +
                              "| 4. History of Market                     |\n|                                          |\n" +
                              "<><><><><><><><><><><><><><><><><><><><><><>\n|                                          |\n" +
                              "| 5. Exit                                  |\n|                                          |\n" +
                              "<><><><><><><><><><><><><><><><><><><><><><>");

            Console.ResetColor();

        }

        public void SelectProduct()
        {
        key:

            try
            {
                DesignMenu();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nSelect>>> ");

                int n = int.Parse(Console.ReadLine());

                Console.ResetColor();

                switch (n)
                {
                    case 1:
                        {
                            Console.Clear();

                            ShowProduct showProduct = new ShowProduct(true);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();

                            AddProduct addProduct = new AddProduct();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();

                            GiveProduct giveProduct = new GiveProduct();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();

                            HistoryMarket historyMarket = new HistoryMarket();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();

                            break;
                        }
                    default:
                        {
                            throw new Exception();
                        }

                }

            }
            catch
            {
                Console.Clear();

                goto key;

            }
        }
    }
}
