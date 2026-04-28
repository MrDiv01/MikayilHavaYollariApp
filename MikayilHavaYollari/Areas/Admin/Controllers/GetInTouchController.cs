using Microsoft.AspNetCore.Mvc;
using MikayilHavaYollari.Data;
using MikayilHavaYollari.Models;

namespace MikayilHavaYollari.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GetInTouchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GetInTouchController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Tüm Contact Us mesajlarını listele
        public IActionResult Index()
        {
            List<GetInTouch> messages = _context.GetInTouches.OrderByDescending(x => x.Id).ToList();
            return View(messages);
        }

        // Detaylı mesaj görüntüle
        public IActionResult Details(int id)
        {
            GetInTouch message = _context.GetInTouches.FirstOrDefault(x => x.Id == id);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }

        // Mesajı sil
        public IActionResult Delete(int id)
        {
            GetInTouch message = _context.GetInTouches.FirstOrDefault(x => x.Id == id);
            if (message == null)
            {
                return NotFound();
            }
            
            _context.GetInTouches.Remove(message);
            _context.SaveChanges();
            TempData["Success"] = "Mesaj başarıyla silindi.";
            return RedirectToAction("Index");
        }

        // Tüm okunmayan mesajlar
        public IActionResult Unread()
        {
            List<GetInTouch> messages = _context.GetInTouches.OrderByDescending(x => x.Id).ToList();
            return View("Index", messages);
        }
    }
}
