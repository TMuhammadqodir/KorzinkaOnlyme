using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korzinka
{
    internal class ShowProduct
    {

        public ShowProduct(bool checker){
            key:

            List<List<string>> ProductData = WorkWithFile.GetInfoFromFile();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>\n|                    |                    |                    |                    |\n" +
                             $"|Name                |Amount              |Price               |Total summa         |\n|                    |                    |                    |                    |\n" +
                              "<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");

            decimal totalSumProducts = 0m;

            for (int i = 0; i < ProductData.Count; i++)
            {
                int nameLength = ProductData[i][0].Length>19?20: ProductData[i][0].Length;
                int amountLength = ProductData[i][1].Length > 19 ? 20 : ProductData[i][1].Length;
                int priceLenght = ProductData[i][2].Length > 19 ? 20 : ProductData[i][2].Length;
                int totalSumLength = ProductData[i][3].Length > 19 ? 20 : ProductData[i][3].Length;

                string name = ProductData[i][0][..nameLength];
                string amount = ProductData[i][1][..amountLength];
                string price = ProductData[i][2][..priceLenght];
                string totalSum = ProductData[i][3][..totalSumLength];

                string standarter = "                    ";

                totalSumProducts += Convert.ToDecimal(ProductData[i][3]);

                Console.WriteLine($"|{name}{standarter[..(20 - nameLength)]}|" +
                                  $"{amount}{standarter[..(20 - amountLength)]}|" +
                                  $"{price}{standarter[..(20 - priceLenght)]}|" +
                                  $"{totalSum}{standarter[..(20 - totalSumLength)]}|");

            }

            int ind = 58 - ((totalSumProducts).ToString()).Length;
            string standarterr = "                                                            "[..ind];


            Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>\n"+                                                                                 
                             $"| Total summa of products {totalSumProducts}{standarterr}|\n"+                                                                                   
                              "<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");


            Console.ResetColor();
            if (checker)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                                  "| 1. Back                    |\n" +
                                  "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                Console.Write("Select>>> ");
                Console.ResetColor();

                try
                {
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
        }
    }
}
