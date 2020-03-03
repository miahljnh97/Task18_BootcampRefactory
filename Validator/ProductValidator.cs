using System;
using FluentValidation;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Validator
{
    public class ProductValidator : AbstractValidator<Products>
    {
        public ProductValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.name).MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(x => x.price).NotEmpty().WithMessage("price can't be empty ");
            RuleFor(x => x.price).GreaterThan(1000).WithMessage("email is not valid email address");
        }
    }
}
