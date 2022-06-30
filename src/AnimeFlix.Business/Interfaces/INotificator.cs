using AnimeFlix.Business.Notifications;

namespace AnimeFlix.Business.Interfaces
{
    public interface INotificator
    {
        bool HasNotifications();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
