
using FluentValidation;

namespace Application.ValidationRules.FluentValidation.Tag
{
    public class TagValidator : AbstractValidator<Domain.Models.Tag>
    {
        public TagValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .WithMessage("Name field is required")
                .Length(1, 200)
                .WithMessage("Character length cannot exceed 200");
        }
    }
}
