using System;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Queries.GetCustomerPay
{
    public class GetCustomerPayDTO : BaseDTO
    {
        public CustomerPayData Data {get; set;}
    }

    public class CustomerPayData
    {
        public int Id { get; set; }
        public int Customer_id { get; set; }
        public string Name_on_card { get; set; }
        public string Exp_month { get; set; }
        public string Exp_year { get; set; }
        public int Postal_code { get; set; }
        public string Credit_card_number { get; set; }
    }
}
