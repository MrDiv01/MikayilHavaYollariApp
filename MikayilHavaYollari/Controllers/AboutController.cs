using Microsoft.AspNetCore.Mvc;
using MikayilHavaYollari.Enums;
using MikayilHavaYollari.Models;

namespace MikayilHavaYollari.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            // 1. ViewBag - Dinamikdir, nöqtə ilə yazılır
            //ViewBag.SahiheBasligi = "ViewBag Testing";

            //// 2. ViewData - Key-value (string indeks) ilə yazılır
            ViewData["Metn"] = "Zəhmət olmasa formunu doldurun.";
            return View();
        }
    }
}