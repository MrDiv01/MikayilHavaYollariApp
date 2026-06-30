using System.ComponentModel.DataAnnotations.Schema;

namespace MikayilHavaYollari.Models
{
    public class HomeSlider:BaseEntity
    {
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
