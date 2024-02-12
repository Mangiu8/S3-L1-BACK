using System;
using System.Collections.Generic;

namespace RestaurantMenu
{
    class Program
    {
        class MenuItem
        {
            public string Name { get; }
            public double Price { get; }

            public MenuItem(string name, double price)
            {
                Name = name;
                Price = price;
            }
        }
        static void Main(string[] args)
        {
            List<MenuItem> menu = new List<MenuItem>()
            {
                new MenuItem("Coca Cola 150 ml", 2.50),
                new MenuItem("Insalata di pollo", 5.20),
                new MenuItem("Pizza Margherita", 10.00),
                new MenuItem("Pizza 4 Formaggi", 12.50),
                new MenuItem("Porzione di patatine fritte", 3.50),
                new MenuItem("Insalata di riso", 8.00),
                new MenuItem("Frutta di stagione", 5.00),
                new MenuItem("Pizza fritta", 5.00),
                new MenuItem("Piadina vegetariana", 6.00),
                new MenuItem("Panino Hamburger", 7.90)
            };

            List<MenuItem> selectedItems = new List<MenuItem>();

            while (true)
            {
                Console.WriteLine("==============MENU==============");
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {menu[i].Name} (Euro {menu[i].Price.ToString("0.00")})");
                }
                Console.WriteLine($"{menu.Count + 1}: Stampa conto finale e conferma");
                Console.WriteLine("==============MENU==============");

                Console.Write("Scelta: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice >= 1 && choice <= menu.Count)
                    {
                        selectedItems.Add(menu[choice - 1]);
                        Console.WriteLine("Piatto aggiunto al conto.");
                    }
                    else if (choice == menu.Count + 1)
                    {
                        Console.WriteLine("Conto finale:");
                        foreach (var item in selectedItems)
                        {
                            Console.WriteLine($"{item.Name} (Euro {item.Price.ToString("0.00")})");
                        }
                        double totalCost = CalculateTotalCost(selectedItems);
                        Console.WriteLine($"Costo totale: Euro {totalCost + 3.00} (compreso di servizio al tavolo di 3.00 euro)");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Scelta non valida. Riprova.");
                    }
                }
                else
                {
                    Console.WriteLine("Scelta non valida. Riprova.");
                }
            }
        }

        static double CalculateTotalCost(List<MenuItem> selectedItems)
        {
            double totalCost = 0;
            foreach (var item in selectedItems)
            {
                totalCost += item.Price;
            }
            return totalCost;
        }
    }

}
