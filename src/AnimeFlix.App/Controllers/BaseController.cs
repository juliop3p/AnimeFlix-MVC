using AnimeFlix.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.App.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificator _notificator;

        protected BaseController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool IsValid()
        {
            return !_notificator.HasNotifications();
        }
    }
}
