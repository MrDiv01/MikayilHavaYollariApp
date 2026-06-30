using Microsoft.AspNetCore.Mvc;
using MikayilHavaYollari.Data;
using MikayilHavaYollari.Helper;
using MikayilHavaYollari.Models;

namespace MikayilHavaYollari.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IContactEmailService _contactEmailService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(
            ApplicationDbContext context,
            IContactEmailService contactEmailService,
            ILogger<ContactController> logger)
        {
            _context = context;
            _contactEmailService = contactEmailService;
            _logger = logger;
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(GetInTouch model)
        {
            if (ModelState.IsValid)
            {
                await _context.GetInTouches.AddAsync(model);
                await _context.SaveChangesAsync();

                try
                {
                    await _contactEmailService.SendContactNotificationAsync(model);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Contact mesaji saxlanildi, amma email gonderile bilmedi.");
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Inputlar bos qala bilmez");
                return View(model);
            }
        }
    }
}
