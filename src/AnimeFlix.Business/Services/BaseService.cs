using AnimeFlix.Business.Entities;
using AnimeFlix.Business.Interfaces;
using AnimeFlix.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace AnimeFlix.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificator _notificator;

        protected BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool IsValid<TValidation, TEntity>(TValidation validation, TEntity entity) 
            where TValidation : AbstractValidator<TEntity> where TEntity : BaseEntity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string message)
        {
            _notificator.Handle(new Notification(message));
        }

    }
}
