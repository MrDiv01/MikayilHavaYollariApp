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
            _context.GetInTouches.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
