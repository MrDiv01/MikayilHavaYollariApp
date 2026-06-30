using MikayilHavaYollari.Models;

namespace MikayilHavaYollari.Helper
{
    public interface IContactEmailService
    {
        Task SendContactNotificationAsync(GetInTouch contact, CancellationToken cancellationToken = default);
    }
}
