using Spg.SpengerDo.App.Model;

namespace Spg.SpengerDo.App.Services
{
    public interface INotificationService
    {
        void SendNotification(User user);
    }
}