using System;
using FluentValidation;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Validator
{
    public class CustomerValidator : AbstractValidator<Customers>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.username).NotEmpty().WithMessage("username can't be empty");
            RuleFor(x => x.username).MaximumLength(20).WithMessage("max username lenght is 20");
            RuleFor(x => x.email).NotEmpty().WithMessage("email can't be empty ");
            RuleFor(x => x.email).EmailAddress().WithMessage("email is not valid email address");
            RuleFor(x => x.gender).IsInEnum().WithMessage("gender is one of male or female");
            RuleFor(x => x.gender).NotEmpty().WithMessage("gender can't be empty");
            RuleFor(x => x.birthdate).NotEmpty().WithMessage("birthdate can't be empty");
            RuleFor(x =>  DateTime.Now.Year - x.birthdate.Year).GreaterThan(18).WithMessage("age must be greater than 18");
        }
    }
}
