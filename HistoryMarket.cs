using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korzinka
{
    internal class HistoryMarket
    {

        public HistoryMarket() 
        {   
            key:
            
             List<List<string>> InComingProduct = new List<List<string>>();
             List<List<string>> OutGoingProduct = new List<List<string>>();

             List<List<string>> HistoryOfWarehause = WorkWithFile.GetHistoryOfWarehause();

             for (int i = HistoryOfWarehause.Count - 1; i > -1; i--)
             {
                 if (Convert.ToChar(HistoryOfWarehause[i][1][0]) == '+')
                 {
                     InComingProduct.Add(HistoryOfWarehause[i]);
                 }
                 else
                 {
                     OutGoingProduct.Add(HistoryOfWarehause[i]);
                 }

             }

             HistoryOfMarketDesign(OutGoingProduct, false);

             Console.ForegroundColor = ConsoleColor.Blue;
             Console.WriteLine("\n\n");
             Console.ResetColor();

             HistoryOfMarketDesign(InComingProduct, true);

           

            try
            {
              

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                                  "| 1. Back                    |\n" +
                                  "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                Console.Write("Select>>> ");
                Console.ResetColor();



                int n = int.Parse(Console.ReadLine());
                if (n == 1)
                {
                    Console.Clear();
                    Menu menu1 = new Menu();
                }
                else
                {
                    throw new Exception();
                }

            }
            catch
            {

                Console.Clear();
                goto key;
            }


        }

        public void HistoryOfMarketDesign(List<List<string>> ProductData, bool checker)
        {

            if (checker)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>\n" +
                                $"|                                             InComing Product                                           |\n" +
                                  "<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");


            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>\n" +
                                $"|                                             OutGoing Product                                           |\n" +
                                  "<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");

            }

            Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>\n|                    |                    |                    |                    |                    |\n" +
                             $"| Name               | Amount             | Price              | Total summa        | Time               |\n|                    |                    |                    |                    |                    |\n" +
                              "<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");

            decimal totalSumProducts = 0m;

            for (int i = 0; i < ProductData.Count; i++)
            {

                int nameLength = ProductData[i][0].Length > 19 ? 20 : ProductData[i][0].Length;
                int amountLength = ProductData[i][1].Length > 19 ? 20 : ProductData[i][1].Length;
                int priceLenght = ProductData[i][2].Length > 19 ? 20 : ProductData[i][2].Length;
                int totalSumLength = ProductData[i][3].Length > 19 ? 20 : ProductData[i][3].Length;
                int timeLength = ProductData[i][4].Length > 19 ? 20 : ProductData[i][4].Length;

                string name = ProductData[i][0][..nameLength];
                string amount = ProductData[i][1][..amountLength];
                string price = ProductData[i][2][..priceLenght];
                string totalSum = ProductData[i][3][..totalSumLength];
                string time = ProductData[i][4][..timeLength];

                string standarter = "                    ";

                totalSumProducts += Convert.ToDecimal(ProductData[i][3]);

                Console.WriteLine($"|{name}{standarter[..(20 - nameLength)]}|" +
                                  $"{amount}{standarter[..(20 - amountLength)]}|" +
                                  $"{price}{standarter[..(20 - priceLenght)]}|" +
                                  $"{totalSum}{standarter[..(20 - totalSumLength)]}|" +
                                  $"{time}{standarter[..(20 - timeLength)]}|");

            }

            int ind = 79 - ((totalSumProducts).ToString()).Length;
            string standarterr = "                                                                                "[..ind];

            Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>\n" +
                             $"| Total summa of products {totalSumProducts}{standarterr}|\n" +
                              "<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");


            Console.ResetColor();

            
        }
    }
}
