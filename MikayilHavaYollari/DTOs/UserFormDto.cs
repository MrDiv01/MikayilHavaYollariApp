using MikayilHavaYollari.Models;

namespace MikayilHavaYollari.DTOs
{
    public class UserFormDto : BaseEntity
    {
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime ReciveTime { get; set; } = DateTime.Now;
    }
}
