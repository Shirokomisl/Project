using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
