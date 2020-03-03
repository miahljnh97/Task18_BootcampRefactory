using System;
using FluentValidation;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Validator
{
    public class CustomerPayValidator : AbstractValidator<Customers_Payment_Card>
    {
        public CustomerPayValidator()
        {
            RuleFor(x => x.name_on_card).NotEmpty().WithMessage("name_on_card can't be empty");
            RuleFor(x => x.name_on_card).MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(x => x.exp_month).NotEmpty().WithMessage("exp_month can't be empty ");
            RuleFor(x => Convert.ToInt32(x.exp_month)).ExclusiveBetween(1, 12).WithMessage("exp_month is bettween 1-12");
            RuleFor(x => x.exp_year).NotEmpty().WithMessage("exp_year can't be empty ");
            RuleFor(x => x.credit_card_number).CreditCard().WithMessage("credit_card_number must be type of credit card number");
        }
    }
}
