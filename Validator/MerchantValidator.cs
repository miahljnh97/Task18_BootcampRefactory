using System;
using FluentValidation;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Validator
{
    public class MerchantValidator : AbstractValidator<Merchant>
    {
        public MerchantValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.address).NotEmpty().WithMessage("address can't be empty ");
            RuleFor(x => x.rating).ExclusiveBetween(1, 5).WithMessage("rating is bettween 1-5");
        }
    }
}
