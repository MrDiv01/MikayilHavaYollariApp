using Microsoft.AspNetCore.Mvc;

namespace MikayilHavaYollari.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Blog()
        {
            return View();
        }
    }
}
