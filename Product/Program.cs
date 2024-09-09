using System;
using System.Collections;
using System.Threading.Channels;

namespace Product
{
    class Program
    {
        static void Main()
        {
            Product product = new Product();

            product.Add("Notebook", "Apple", "Macbook Air", 2300, 5);
            product.Add("Notebook", "Asus", "Rog", 3000, 7);
            product.Add("Phone", "Samsung", "S23", 1600, 4);

            ArrayList products = product.GetAllProducts();

            Reaccess:
            Console.WriteLine("Welcome! \n" +
                              "1. Show all products \n" +
                              "2. Show products by categorical \n" +
                              "3. Add product \n" +
                              "4. Remove product \n" +
                              "5. Update product \n" +
                              "6. Calculate total price of all products \n" +
                              "7. Calculate total price of notebooks \n" +
                              "8. Calculate total price of phones \n" +
                              "9. Total quantity of all product \n" +
                              "10. Total quantity of notebooks \n" +
                              "11. Total quantity of phones \n" +
                              "12. Sell products \n" +
                              "Enter your choice"
            );
            string stringchoice = Console.ReadLine();
            int a;
            bool choice = int.TryParse(stringchoice, out a);
            


            if (choice)
            {
                int userchoice = Convert.ToInt32(stringchoice);
                if (userchoice == 1)
                {
                    product.ShowAllProducts();
                }
                else if (userchoice == 2)
                {
                    ReCategory:
                    Console.WriteLine("Which category you want? \n" +
                                      "1. Notebooks \n" +
                                      "2. Phones \n" +
                                      "Enter your choice");
                    string catchoice = Console.ReadLine();
                    int b;
                    bool checkcat = int.TryParse(catchoice, out b);

                    if (checkcat)
                    {
                        int categoryChoice = Convert.ToInt32(catchoice);
                        if (categoryChoice == 1)
                        {
                            int counter = 1;
                            foreach (ArrayList key in products)
                            {
                                if (key[0] == "Notebook")
                                {
                                    Console.WriteLine($"PRODUCT: {counter}");
                                    foreach (var item in (ArrayList)key)
                                    {
                                        Console.WriteLine(item);
                                    }
                                }
            
                                counter++;
                            }
                        }
                        else if (categoryChoice == 2)
                        {
                            int counter = 1;
                            foreach (ArrayList key in products)
                            {
                                if (key[0] == "Phone")
                                {
                                    Console.WriteLine($"PRODUCT: {counter}");
                                    foreach (var item in (ArrayList)key)
                                    {
                                        Console.WriteLine(item);
                                    }
                                }
            
                                counter++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is not this category!");
                            goto ReCategory;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter number!");
                        goto Reaccess;
                    }
                    
                }
                else if (userchoice == 3)
                {
                    Console.Write("Category: ");
                    string category = Console.ReadLine();
            
                    Console.Write("Brand: ");
                    string brand = Console.ReadLine();
            
                    Console.WriteLine("Model: ");
                    string model = Console.ReadLine();
            
                    Console.WriteLine("Price: ");
                    decimal price = Convert.ToDecimal(Console.ReadLine());
            
                    Console.WriteLine("Quantity: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());
            
                    product.Add(category, brand, model, price, quantity);
                }
                else if (userchoice == 4)
                {
                    product.ShowAllProducts();
            
                    Console.WriteLine("Enter number of deleting product: ");
                    int userChoice = Convert.ToInt32(Console.ReadLine());
            
                    if (userChoice <= product.GetAllProducts().Count)
                    {
                        product.RemoveProduct(userChoice);
                    }
                    else
                    {
                        Console.WriteLine("Wrong product!");
                    }
                }
                else if (userchoice == 5)
                {
            
                    Console.Write("Update product's number: ");
                    int index = Convert.ToInt32(Console.ReadLine());
            
                    Console.Write("Category: ");
                    string category = Console.ReadLine();
            
                    Console.Write("Brand: ");
                    string brand = Console.ReadLine();
            
                    Console.WriteLine("Model: ");
                    string model = Console.ReadLine();
            
                    ReEnterNumber:
                    Console.WriteLine("Price: ");
                    decimal price = Convert.ToDecimal(Console.ReadLine());
                    if (price < 0)
                    {
                        Console.WriteLine("Wrong number!");
                        goto ReEnterNumber;
                    }

                    ReEntreQuantity:
                    Console.WriteLine("Quantity: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    if (quantity < 0)
                    {
                        Console.WriteLine("Wrong number!");
                        goto ReEntreQuantity;
                    }
                    product.UpdateProduct(index, category, brand, model, price, quantity);
            
                    product.ShowAllProducts();
                }
                else if (userchoice == 6)
                {
                    decimal totalPrice = 0;
                    foreach (ArrayList inside in products)
                    {
                        decimal price = (decimal)inside[3];
                        totalPrice += price;
                    }
            
                    Console.WriteLine($"Total price of products: {totalPrice}");
                }
                else if (userchoice == 7)
                {
                    decimal totalNotebooks = 0;
                    foreach (ArrayList key in products)
                    {
                        if (key[0] == "Notebook")
                        {
                            decimal price = (decimal)key[3];
                            totalNotebooks += price;
                        }
                    }
            
                    Console.WriteLine($"Notebook's price: {totalNotebooks}");
                }
                else if (userchoice == 8)
                {
                    decimal totalPhones = 0;
                    foreach (ArrayList key in products)
                    {
                        if (key[0] == "Phone")
                        {
                            decimal price = (decimal)key[3];
                            totalPhones += price;
                        }
                    }
            
                    Console.WriteLine($"Notebook's price: {totalPhones}");
                }
                else if (userchoice == 9)
                {
                    int totalQuantityAll = 0;
                    foreach (ArrayList key in products)
                    {
                        int quantity = (int)key[4];
                        totalQuantityAll += quantity;
                    }
            
                    Console.WriteLine($"All quantity: {totalQuantityAll}");
                }
                else if (userchoice == 10)
                {
                    int totalQuantityNotebooks = 0;
                    foreach (ArrayList key in products)
                    {
                        if (key[0] == "Notebook")
                        {
                            int quantity = (int)key[4];
                            totalQuantityNotebooks += quantity;
                        }
                    }
            
                    Console.WriteLine($"Notebooks quantity: {totalQuantityNotebooks}");
                }
                else if (userchoice == 11)
                {
                    int totalQuantityPhones = 0;
                    foreach (ArrayList key in products)
                    {
                        if (key[0] == "Phone")
                        {
                            int quantity = (int)key[4];
                            totalQuantityPhones += quantity;
                        }
                    }
            
                    Console.WriteLine($"Phones quantity: {totalQuantityPhones}");
                }
                else if (userchoice == 12)
                {
                    Console.WriteLine("Which category do you want to sell? \n" +
                                      "1. Notebook \n" +
                                      "2. Phone \n");
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    
                    Resell:
                    Console.Write("How many do you want to sell? ");
                    int userQuantity = Convert.ToInt32(Console.ReadLine());
            
            
                    if (userChoice == 1)
                    {
                        ReModel:
                        Console.WriteLine("Which model do you want to sell? \n" +
                                          "1. Macbook Air \n" +
                                          "2. Asus Rog");
                        int notebookModel = Convert.ToInt32(Console.ReadLine());
                        foreach (ArrayList key in products)
                        {
                            if (key[0] == "Notebook")
                            {
                                if (notebookModel == 1)
                                {
                                    if (key[2] == "Macbook Air")
                                    {
                                        if ((int)key[4] >= userQuantity)
                                        {
                                            key[4] = (int)key[4] - userQuantity;
                                            Console.WriteLine($"{key[2]} quantity: {key[4]}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Quantity is not enough!");
                                        }
                                    }
                                }
                                else if (notebookModel == 2)
                                {
                                    if (key[2] == "Rog")
                                    {
                                        if ((int)key[4] >= userQuantity)
                                        {
                                            key[4] = (int)key[4] - userQuantity;
                                            Console.WriteLine($"{key[2]} quantity: {key[4]}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Quantity is not enough!");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There is not this type model!");
                                    goto ReModel;
                                }
                            }
                        }
                    }
                    else if (userChoice == 2)
                    {
                        foreach (ArrayList key in products)
                        {
                            if (key[0] == "Phone")
                            {
                                if ((int)key[4] >= userQuantity)
                                {
                                    key[4] = (int)key[4] - userQuantity;
                                    Console.WriteLine($"{key[1]} quantity: {key[4]}");   
                                }
                                else
                                {
                                    Console.WriteLine("Quantity is not enough!");
                                    goto Resell;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wrong choice");
                    goto Reaccess;
                }
            }
            else
            {
                Console.WriteLine("Input is not a number!");
                goto Reaccess;
            }

            goto Reaccess;
        }
    }
}