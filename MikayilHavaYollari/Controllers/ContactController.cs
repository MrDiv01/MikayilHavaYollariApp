using Microsoft.AspNetCore.Mvc;
using MikayilHavaYollari.Data;
using MikayilHavaYollari.Models;

namespace MikayilHavaYollari.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(GetInTouch model)
        {
            if (ModelState.IsValid)
            {
                _context.GetInTouches.Add(model);
                _context.SaveChanges();
                TempData["Success"] = "Mesajınız başarıyla gönderildi. En kısa zamanda sizinle iletişime geçeceğiz.";
                return RedirectToAction("Contact");
            }
            return View(model);
        }
    }
}
