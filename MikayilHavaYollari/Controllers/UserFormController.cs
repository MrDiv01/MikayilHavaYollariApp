using Microsoft.AspNetCore.Mvc;
using MikayilHavaYollari.Data;
using MikayilHavaYollari.Models;

namespace MikayilHavaYollari.Controllers
{
    public class UserFormController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserFormController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<GetInTouch> getInTouches = _context.GetInTouches.ToList();
            return View(getInTouches);
        }
    }
}
