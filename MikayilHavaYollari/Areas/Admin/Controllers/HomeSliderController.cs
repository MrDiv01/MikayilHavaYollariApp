using Microsoft.AspNetCore.Mvc;
using MikayilHavaYollari.Data;
using MikayilHavaYollari.Models;

namespace MikayilHavaYollari.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeSliderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeSliderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<HomeSlider> homeSlider = _context.HomeSliders.ToList();
            return View(homeSlider);

        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(HomeSlider data)
        {
            _context.HomeSliders.Add(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = _context.HomeSliders.FirstOrDefault(x => x.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return View(data);
            }
        }

        [HttpPost]
        public IActionResult Update(HomeSlider slider)
        {
            var data = _context.HomeSliders.FirstOrDefault(x => x.Id == slider.Id);
            if (data == null)
            {
                return NotFound();
            }
            data.ImageUrl = slider.ImageUrl;
            data.Title = slider.Title;
            data.Description = slider.Description;
            data.ButtonText = slider.ButtonText;
            data.ButtonUrl = slider.ButtonUrl;
            data.IsActive = slider.IsActive;
            data.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _context.HomeSliders.FirstOrDefault(x => x.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            _context.HomeSliders.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
