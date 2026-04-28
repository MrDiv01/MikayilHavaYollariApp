using Microsoft.AspNetCore.Mvc;
using MikayilHavaYollari.Data;
using MikayilHavaYollari.Models;
using System.Diagnostics;

namespace MikayilHavaYollari.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeSlider homeSlider = _context.HomeSliders.FirstOrDefault(x=>x.IsActive == true);
            return View(homeSlider);
            
        }
    }
}
