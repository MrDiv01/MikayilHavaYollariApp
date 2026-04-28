namespace MikayilHavaYollari.Models
{
    public class GetInTouch:BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
