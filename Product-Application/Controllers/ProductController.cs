using Microsoft.AspNetCore.Mvc;
using Product_Application.Models;

namespace Product_Application.Controllers
{
    public class ProductController : Controller
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public ProductController()
        {
            Products.Add(new Product(1,"Snickers", 2.99, "Candy"));
            Products.Add(new Product(2,"Cola", 0.85, "Drink"));
            Products.Add(new Product(3,"Sprite", 0.82, "Drink"));
            Products.Add(new Product(4,"Chocolate", 2, "Candy"));
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
            return View("GetAllProducts", Products);
        }

        public IActionResult RemoveProduct(int id)
        {
            var selectedProduct = Products.FirstOrDefault(p => p.Id==id);
            if (selectedProduct != null)
            {
                Products.Remove(selectedProduct);
            }
            return View("GetAllProducts", Products);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
