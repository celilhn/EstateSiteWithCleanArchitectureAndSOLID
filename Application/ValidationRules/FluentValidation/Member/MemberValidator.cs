using FluentValidation;

namespace Application.ValidationRules.FluentValidation.Member
{
    public class MemberValidator : AbstractValidator<Domain.Models.Member>
    {
        public MemberValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name field is required");
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title field is required")
                .Length(1, 200)
                .WithMessage("Character length cannot exceed 200");
            RuleFor(x => x.Text)
                .NotEmpty()
                .WithMessage("Text field is required")
                .Length(1, 500)
                .WithMessage("Character length cannot exceed 200");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number field is required");
            RuleFor(x => x.FaxNumber)
                .NotEmpty()
                .WithMessage("Fax number field is required");
            RuleFor(x => x.SellingPercent)
                .NotEmpty()
                .WithMessage("Selling percent count is required")
                .GreaterThan(0)
                .WithMessage("Selling percent count must be greater than 0");
            RuleFor(x => x.BuyingPercent)
                .NotEmpty()
                .WithMessage("Buying percent count is required")
                .GreaterThan(0)
                .WithMessage("Buying percent count must be greater than 0");
        }
    }
}
