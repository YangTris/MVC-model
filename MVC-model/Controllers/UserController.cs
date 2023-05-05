using Microsoft.AspNetCore.Mvc;

namespace MVC_model.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }
    }
}
