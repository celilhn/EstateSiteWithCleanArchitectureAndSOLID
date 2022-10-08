using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Application.ValidationRules.FluentValidation.MemberShipPlans
{
    public class MemberShipPlanValidator : AbstractValidator<Domain.Models.MemberShipPlan>
    {
        public MemberShipPlanValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name field is required");
            RuleFor(x => x.IconUrl)
                .NotEmpty()
                .WithMessage("Name field is required");
            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Price is required")
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0");
            RuleFor(x => x.ListCount)
                .NotEmpty()
                .WithMessage("List count is required")
                .GreaterThan(0)
                .WithMessage("List count must be greater than 0");
            RuleFor(x => x.FeaturedListCount)
                .NotEmpty()
                .WithMessage("Featured list count is required")
                .GreaterThan(0)
                .WithMessage("Featured list count must be greater than 0");
        }
    }
}
