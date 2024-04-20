using Microsoft.AspNetCore.Mvc;
using Product_Application.Models;
using System.Text.Json;

namespace Product_Application.Controllers
{
    public class ProductController : Controller
    {
        private string dataFilePath = "products.json";
        public List<Product> Products { get; set; } = new List<Product>();

        public ProductController()
        {
            LoadProductsFromFile();
        }


        public IActionResult GetAllProducts()
        {
            return View(Products);
        }
        public IActionResult GetProductById(int id)
        {
            foreach (var item in Products) {
            
                if(item.Id == id) return View(item);
            }
            return RedirectToAction("GetAllProducts");
        }

        public IActionResult RemoveProduct(int id)
        {
            var selectedProduct = Products.FirstOrDefault(p => p.Id==id);
            if (selectedProduct != null)
            {
                Products.Remove(selectedProduct);
                SaveProductsToFile();
                
            }
            return RedirectToAction("GetAllProducts");
        }
        private void LoadProductsFromFile()
        {
            if(System.IO.File.Exists(dataFilePath))
            {
                string jsonData=System.IO.File.ReadAllText(dataFilePath);
                Products = JsonSerializer.Deserialize<List<Product>>(jsonData)!;
            }
            else
            {
                Products.Add(new Product("Snickers", 2.99, "Candy"));
                Products.Add(new Product("Cola", 0.85, "Drink"));
                Products.Add(new Product("Sprite", 0.82, "Drink"));
                Products.Add(new Product("Chocolate", 2, "Candy"));
                SaveProductsToFile();   
            }
        }
        private void SaveProductsToFile()
        {
            string jsonData = JsonSerializer.Serialize(Products);
            System.IO.File.WriteAllText(dataFilePath, jsonData);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
