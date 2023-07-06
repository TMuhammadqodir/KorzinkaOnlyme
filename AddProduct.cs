using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korzinka
{
    internal class AddProduct
    {
        ProductModel product = new ProductModel();
        public AddProduct() 
        {   

            key:

                try
                {
                    ShowProduct showProduct = new ShowProduct(false);

                    AddProductDesign();

                    AddProductSelectFunction();

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


        public void AddProductSelectFunction()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Select>>> ");

            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    {
                        Console.Write("name: ");
                        product.Name = Console.ReadLine();
                        Console.Clear();

                        ShowProduct showProduct = new ShowProduct(false);
                        AddProductDesign();
                        AddProductSelectFunction();
                        break;
                    }
                case 2:
                    {
                        Console.Write("amount: ");
                        product.Amount = Console.ReadLine();
                        Console.Clear();

                        ShowProduct showProduct = new ShowProduct(false);
                        AddProductDesign();
                        AddProductSelectFunction();
                        break;
                    }
                case 3:
                    {
                        Console.Write("price: ");
                        product.Price = Convert.ToDecimal(Console.ReadLine());
                        Console.Clear();

                        ShowProduct showProduct = new ShowProduct(false);
                        AddProductDesign();
                        AddProductSelectFunction();
                        break;
                    }
                case 4:
                    {
                        if(product.Name.Length>0 &&  product.Amount.Length>0 && product.Price !=0 && float.Parse(product.Amount.Split()[0]).GetType() == typeof(float)) 
                        {
                            WorkWithFile.AddToFile(product.Name, product.Amount, product.Price);
                            Console.Clear();
                            AddProduct query = new AddProduct();

                        }
                        else
                        {
                            throw new Exception();
                        }


                        break;
                    }
                case 5:
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


        public void AddProductDesign()
        {
            int nameLength = product.Name.Length>20?21:product.Name.Length;
            int amountLength = product.Amount.Length>18?19:product.Amount.Length;
            int priceLength = product.Price.ToString().Length>19?20:product.Price.ToString().Length;

            string name = product.Name[..nameLength];
            string amount = product.Amount[..amountLength];
            string price = product.Price.ToString()[..priceLength];

            string standarter = "                     "; 

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n"+
                             $"| 1. Enter name {name}{standarter[..(21 - nameLength)]}|\n"+
                             $"| 2. Enter amount {amount}{standarter[..(21 - amountLength - 2)]}|\n"+
                             $"| 3. Enter price {price}{standarter[..(21 - priceLength - 1)]}|\n" +
                              "| 4. Add product                     |\n" +
                              "| 5. back                            |\n" +
                              "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"); ;

            Console.ResetColor();
        }
    }
}
