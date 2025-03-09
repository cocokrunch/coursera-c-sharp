using System;
using System.Collections.Generic;
using System.Linq;

namespace Farmilihan
{
    // Product class to store product information
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }

    class InventorySystem
    {
        private List<Product> products;
        private int nextId;

        // Constructor
        public InventorySystem()
        {
            products = new List<Product>();
            nextId = 1;
            
            // Add some sample products
            AddProduct("Rice Seeds", "Seeds", 150.50m, 100, new DateTime(2025, 12, 31));
            AddProduct("Fertilizer", "Supplies", 350.75m, 50, new DateTime(2026, 6, 30));
            AddProduct("Shovel", "Tools", 250.00m, 10, null);
        }

        // Method to display the main menu
        public void DisplayMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("  FARMILIHAN INVENTORY MANAGEMENT");
                Console.WriteLine("======================================");
                Console.WriteLine("1. View All Products");
                Console.WriteLine("2. Add New Product");
                Console.WriteLine("3. Update Product Stock");
                Console.WriteLine("4. Remove Product");
                Console.WriteLine("5. Search Products");
                Console.WriteLine("6. Exit");
                Console.WriteLine("======================================");
                Console.Write("Enter your choice (1-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllProducts();
                        break;
                    case "2":
                        AddNewProduct();
                        break;
                    case "3":
                        UpdateProductStock();
                        break;
                    case "4":
                        RemoveProduct();
                        break;
                    case "5":
                        SearchProducts();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Method to add a product with specific details
        private void AddProduct(string name, string category, decimal price, int quantity, DateTime? expiryDate)
        {
            products.Add(new Product
            {
                Id = nextId++,
                Name = name,
                Category = category,
                Price = price,
                Quantity = quantity,
                ExpiryDate = expiryDate
            });
        }

        // Method to view all products
        private void ViewAllProducts()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("          PRODUCT INVENTORY");
            Console.WriteLine("======================================");
            
            if (products.Count == 0)
            {
                Console.WriteLine("No products in inventory.");
            }
            else
            {
                Console.WriteLine("ID\tName\t\tCategory\tPrice\tQuantity\tExpiry Date");
                Console.WriteLine("----------------------------------------------------------------------");
                
                foreach (var product in products)
                {
                    string expiryDateStr = product.ExpiryDate.HasValue 
                        ? product.ExpiryDate.Value.ToString("yyyy-MM-dd") 
                        : "N/A";
                    
                    Console.WriteLine($"{product.Id}\t{product.Name}\t{product.Category}\t{product.Price:C2}\t{product.Quantity}\t\t{expiryDateStr}");
                }
            }
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // Method to add a new product
        private void AddNewProduct()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("           ADD NEW PRODUCT");
            Console.WriteLine("======================================");
            
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            
            Console.Write("Enter category: ");
            string category = Console.ReadLine();
            
            decimal price = 0;
            bool validPrice = false;
            while (!validPrice)
            {
                Console.Write("Enter price: ");
                validPrice = decimal.TryParse(Console.ReadLine(), out price);
                if (!validPrice || price < 0)
                {
                    Console.WriteLine("Invalid price. Please enter a positive number.");
                    validPrice = false;
                }
            }
            
            int quantity = 0;
            bool validQuantity = false;
            while (!validQuantity)
            {
                Console.Write("Enter quantity: ");
                validQuantity = int.TryParse(Console.ReadLine(), out quantity);
                if (!validQuantity || quantity < 0)
                {
                    Console.WriteLine("Invalid quantity. Please enter a positive number.");
                    validQuantity = false;
                }
            }
            
            DateTime? expiryDate = null;
            Console.Write("Does this product have an expiry date? (Y/N): ");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                bool validDate = false;
                while (!validDate)
                {
                    Console.Write("Enter expiry date (YYYY-MM-DD): ");
                    validDate = DateTime.TryParse(Console.ReadLine(), out DateTime date);
                    if (validDate)
                    {
                        expiryDate = date;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please use YYYY-MM-DD.");
                    }
                }
            }
            
            AddProduct(name, category, price, quantity, expiryDate);
            Console.WriteLine("\nProduct added successfully! Press any key to continue...");
            Console.ReadKey();
        }

        // Method to update product stock
        private void UpdateProductStock()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("         UPDATE PRODUCT STOCK");
            Console.WriteLine("======================================");
            
            Console.Write("Enter product ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var product = products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    Console.WriteLine($"Current stock for {product.Name}: {product.Quantity}");
                    Console.WriteLine("1. Add to stock (restock)");
                    Console.WriteLine("2. Remove from stock (sold/used)");
                    Console.Write("Select operation (1-2): ");
                    
                    string operation = Console.ReadLine();
                    int amount = 0;
                    bool validAmount = false;
                    
                    while (!validAmount)
                    {
                        Console.Write("Enter quantity: ");
                        validAmount = int.TryParse(Console.ReadLine(), out amount);
                        if (!validAmount || amount < 0)
                        {
                            Console.WriteLine("Invalid amount. Please enter a positive number.");
                            validAmount = false;
                        }
                    }
                    
                    if (operation == "1")
                    {
                        // Restock
                        product.Quantity += amount;
                        Console.WriteLine($"Added {amount} to stock. New quantity: {product.Quantity}");
                    }
                    else if (operation == "2")
                    {
                        // Remove from stock
                        if (amount > product.Quantity)
                        {
                            Console.WriteLine($"Error: Not enough in stock. Current stock: {product.Quantity}");
                        }
                        else
                        {
                            product.Quantity -= amount;
                            Console.WriteLine($"Removed {amount} from stock. New quantity: {product.Quantity}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid operation selected.");
                    }
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // Method to remove a product
        private void RemoveProduct()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("           REMOVE PRODUCT");
            Console.WriteLine("======================================");
            
            Console.Write("Enter product ID to remove: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var product = products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    Console.WriteLine($"Are you sure you want to remove '{product.Name}'? (Y/N): ");
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        products.Remove(product);
                        Console.WriteLine("Product removed successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Operation cancelled.");
                    }
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // Method to search products
        private void SearchProducts()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("           SEARCH PRODUCTS");
            Console.WriteLine("======================================");
            
            Console.WriteLine("1. Search by name");
            Console.WriteLine("2. Search by category");
            Console.WriteLine("3. View low stock products (< 10 items)");
            Console.Write("Enter your choice (1-3): ");
            
            string choice = Console.ReadLine();
            List<Product> results = new List<Product>();
            
            switch (choice)
            {
                case "1":
                    Console.Write("Enter product name to search: ");
                    string searchName = Console.ReadLine().ToLower();
                    results = products.Where(p => p.Name.ToLower().Contains(searchName)).ToList();
                    break;
                case "2":
                    Console.Write("Enter category to search: ");
                    string searchCategory = Console.ReadLine().ToLower();
                    results = products.Where(p => p.Category.ToLower().Contains(searchCategory)).ToList();
                    break;
                case "3":
                    results = products.Where(p => p.Quantity < 10).ToList();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
            
            if (results.Count > 0)
            {
                Console.WriteLine("\nSearch Results:");
                Console.WriteLine("ID\tName\t\tCategory\tPrice\tQuantity\tExpiry Date");
                Console.WriteLine("----------------------------------------------------------------------");
                
                foreach (var product in results)
                {
                    string expiryDateStr = product.ExpiryDate.HasValue 
                        ? product.ExpiryDate.Value.ToString("yyyy-MM-dd") 
                        : "N/A";
                    
                    Console.WriteLine($"{product.Id}\t{product.Name}\t{product.Category}\t{product.Price:C2}\t{product.Quantity}\t\t{expiryDateStr}");
                }
            }
            else
            {
                Console.WriteLine("\nNo matching products found.");
            }
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    class FarmilihanInventory
    {
        static void Main(string[] args)
        {
            Console.Title = "Farmilihan Inventory Management System";
            
            InventorySystem inventorySystem = new InventorySystem();
            inventorySystem.DisplayMenu();
            
            Console.WriteLine("Thank you for using Farmilihan Inventory Management System!");
        }
    }
}