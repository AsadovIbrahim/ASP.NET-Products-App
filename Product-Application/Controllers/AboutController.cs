using Microsoft.AspNetCore.Mvc;

namespace Product_Application.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
