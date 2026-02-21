using System;

namespace Services
{
    public class InventoryService
    {
        private string[,] products;
        private string[,] initialStock;

        public InventoryService()
        {
            products = new string[2, 3] {
                { "Apples", "Milk", "Bread" },
                { "10", "5", "20" }
            };

            initialStock = new string[2, 3];
            Array.Copy(products, initialStock, products.Length);
        }

        public string[,] GetInventory()
        {
            return products;
        }

        public void UpdateStock(int index, int newStock)
        {
            products[1, index] = newStock.ToString();
        }

        public void ResetInventory()
        {
            Array.Copy(initialStock, products, products.Length);
        }
    }
}
