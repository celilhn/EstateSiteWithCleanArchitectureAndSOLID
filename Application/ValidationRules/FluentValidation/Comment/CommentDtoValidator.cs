using FluentValidation;

namespace Application.ValidationRules.FluentValidation.Comment
{
    public class CommentDtoValidator : AbstractValidator<Domain.Models.Comment>
    {
        public CommentDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email field is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name field is required");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone Number field is required");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject field is required");
        }
    }
}
