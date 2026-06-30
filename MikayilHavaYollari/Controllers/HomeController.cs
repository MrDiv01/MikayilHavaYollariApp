using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MikayilHavaYollari.Data;
using MikayilHavaYollari.Models;
using MikayilHavaYollari.ViewModels;
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
        public async Task<IActionResult> Index()
        {

            HomeViewModel homeViewModel = new HomeViewModel()
            {
                homeSlider =await _context.HomeSliders.FirstOrDefaultAsync(x => x.IsActive == true),
                ourServices =await _context.OurServices.ToListAsync()
            };
            return View(homeViewModel);
            
        }
    }
}
