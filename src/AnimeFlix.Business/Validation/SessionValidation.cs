using AnimeFlix.Business.Entities;
using FluentValidation;

namespace AnimeFlix.Business.Validation
{
    public class SessionValidation : AbstractValidator<Session>
    {
        public SessionValidation()
        {
            RuleFor(session => session.CurrentEp)
                .GreaterThan(0)
                .LessThan(2000);

            RuleFor(session => session.CurrentTime)
                .GreaterThan(-1);
        }
    }
}
