using System;
using Services;  

namespace Views
{
    public class InventoryView
    {
        private InventoryService service;

        public InventoryView()
        {
            service = new InventoryService();
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Inventory Management ---");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowInventory();
                        break;
                    case "2":
                        UpdateStock();
                        break;
                    case "3":
                        service.ResetInventory();
                        Console.WriteLine("Inventory reset to initial values.");
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void ShowInventory()
        {
            var inventory = service.GetInventory();
            Console.WriteLine("\nCurrent Inventory:");
            for (int i = 0; i < inventory.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}. {inventory[0, i]} - Stock: {inventory[1, i]}");
            }
        }

        private void UpdateStock()
        {
            ShowInventory();

            Console.Write("Enter product number to update: ");
            if (int.TryParse(Console.ReadLine(), out int productNumber) &&
                productNumber >= 1 && productNumber <= 3)
            {
                Console.Write("Enter new stock quantity: ");
                if (int.TryParse(Console.ReadLine(), out int newStock) && newStock >= 0)
                {
                    service.UpdateStock(productNumber - 1, newStock);
                    Console.WriteLine("Stock updated!");
                }
                else
                {
                    Console.WriteLine("Invalid stock quantity.");
                }
            }
            else
            {
                Console.WriteLine("Invalid product number.");
            }
        }
    }
}
