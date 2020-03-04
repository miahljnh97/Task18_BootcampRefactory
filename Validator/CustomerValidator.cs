using System;
using FluentValidation;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Validator
{
    public class CustomerValidator : AbstractValidator<RequestData<Customers>>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.data.attributes.username).NotEmpty().WithMessage("username can't be empty");
            RuleFor(x => x.data.attributes.username).MaximumLength(20).WithMessage("max username lenght is 20");
            RuleFor(x => x.data.attributes.email).NotEmpty().WithMessage("email can't be empty ");
            RuleFor(x => x.data.attributes.email).EmailAddress().WithMessage("email is not valid email address");
            RuleFor(x => x.data.attributes.sex).IsInEnum().WithMessage("gender is one of male or female");
            RuleFor(x => x.data.attributes.gender).NotEmpty().WithMessage("gender can't be empty");
            RuleFor(x => x.data.attributes.birthdate).NotEmpty().WithMessage("birthdate can't be empty");
            RuleFor(x =>  DateTime.Now.Year - x.data.attributes.birthdate.Year).GreaterThan(18).WithMessage("age must be greater than 18");
        }
    }
}
