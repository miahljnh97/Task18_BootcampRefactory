using System;
using FluentValidation;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Validator
{
    public class MerchantValidator : AbstractValidator<RequestData<Merchant>>
    {
        public MerchantValidator()
        {
            RuleFor(x => x.data.attributes.name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.data.attributes.address).NotEmpty().WithMessage("address can't be empty ");
            RuleFor(x => x.data.attributes.rating).ExclusiveBetween(1, 5).WithMessage("rating is bettween 1-5");
        }
    }
}
