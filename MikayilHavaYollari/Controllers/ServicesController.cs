using Microsoft.AspNetCore.Mvc;

namespace MikayilHavaYollari.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Services()
        {
            return View();
        }
    }
}
