using System;

namespace ShoppingCartApp
{
    class Program
    {
        static void Main(string[] args)
        {
            char readyToCheckout;
            FruitItem[] cart = new FruitItem[100];
            int cartSize = 0;

            Random rand = new Random();

            FruitPrice[] fruitPrices = {
                new FruitPrice { Name = "Apple", Price = getRandomPrice(rand) },
                new FruitPrice { Name = "Banana", Price = getRandomPrice(rand) },
                new FruitPrice { Name = "Orange", Price = getRandomPrice(rand) }
                // You can add more fruits and prices here
            };

            while (true)
            {
                Console.WriteLine("Open Catalog");

                Console.WriteLine("Available Fruits:");
                for (int i = 0; i < fruitPrices.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {fruitPrices[i].Name}");
                }
                Console.WriteLine($"{fruitPrices.Length + 1}. Other");

                Console.Write("Select the Product: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice >= 1 && choice <= fruitPrices.Length)
                {
                    cart[cartSize].Name = fruitPrices[choice - 1].Name;
                }
                else if (choice == fruitPrices.Length + 1)
                {
                    Console.Write("Enter the name of the fruit: ");
                    cart[cartSize].Name = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                Console.Write("Edit Quantity: ");
                cart[cartSize].Quantity = int.Parse(Console.ReadLine());

                if (cart[cartSize].Quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity. Setting to default (1).");
                    cart[cartSize].Quantity = 1;
                }

                cartSize++;

                Console.WriteLine("Add to Shopping Cart");

                Console.Write("Ready to Checkout? (y/n): ");
                readyToCheckout = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (readyToCheckout == 'y' || readyToCheckout == 'Y')
                {
                    Console.WriteLine("Shopping Cart Contents:");
                    double total = 0;
                    for (int i = 0; i < cartSize; i++)
                    {
                        double price = 0;
                        for (int j = 0; j < fruitPrices.Length; j++)
                        {
                            if (cart[i].Name == fruitPrices[j].Name)
                            {
                                price = fruitPrices[j].Price;
                                break;
                            }
                        }
                        double itemTotal = price * cart[i].Quantity;
                        total += itemTotal;
                        Console.WriteLine($"{cart[i].Quantity} {cart[i].Name} - Price: {price:C2} - Total: {itemTotal:C2}");
                    }
                    Console.WriteLine($"Total: {total:C2}");

                    Console.WriteLine("Press Checkout");
                    Console.WriteLine("Add Payment Info");
                    Console.WriteLine("Add Shipping Info");
                    Console.WriteLine("Get Tracking Print");
                }
            }
        }

        static double getRandomPrice(Random rand)
        {
            return (rand.Next(1, 11)) + rand.NextDouble();
        }
    }

    struct FruitItem
    {
        public string Name;
        public int Quantity;
    }

    struct FruitPrice
    {
        public string Name;
        public double Price;
    }
}
