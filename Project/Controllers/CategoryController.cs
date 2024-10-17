using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
