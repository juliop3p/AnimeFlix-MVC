using AnimeFlix.Business.Entities;
using FluentValidation;

namespace AnimeFlix.Business.Validation
{
    public class AnimeValidation : AbstractValidator<Anime>
    {
        public AnimeValidation()
        {
            RuleFor(anime => anime.Name)
                .NotEmpty()
                .Length(2, 200);

            RuleFor(anime => anime.Image)
                .NotEmpty()
                .Length(2, 500);

            RuleFor(anime => anime.Image)
                .NotEmpty()
                .Length(2, 300);
        }
    }
}
