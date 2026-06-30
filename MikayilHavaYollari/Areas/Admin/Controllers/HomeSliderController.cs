using Microsoft.AspNetCore.Mvc;
using MikayilHavaYollari.Data;
using MikayilHavaYollari.Helper;
using MikayilHavaYollari.Models;

namespace MikayilHavaYollari.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeSliderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeSliderController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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
            data.ImageUrl = ImageUploadServices.SaveFile(_env.WebRootPath, "uploads", data.ImageFile);
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
            ImageUploadServices.DeleteFile(_env.WebRootPath, "uploads", data.ImageUrl);
            if (data == null)
            {
                return NotFound();
            }
            data.ImageUrl = ImageUploadServices.SaveFile(_env.WebRootPath, "uploads", slider.ImageFile);
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
