using System;
using FluentValidation;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Validator
{
    public class ProductValidator : AbstractValidator<RequestData<Products>>
    {
        public ProductValidator()
        {
            RuleFor(x => x.data.attributes.name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.data.attributes.name).MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(x => x.data.attributes.price).NotEmpty().WithMessage("price can't be empty ");
            RuleFor(x => x.data.attributes.price).GreaterThan(1000).WithMessage("email is not valid email address");
        }
    }
}
