using Microsoft.AspNetCore.Mvc;
using MikayilHavaYollari.Enums;
using MikayilHavaYollari.Models;

namespace MikayilHavaYollari.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}