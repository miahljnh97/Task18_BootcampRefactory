using System;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Queries.GetCustomer
{
    public class GetCustomerDTO : BaseDTO
    {
        public CustomerData Data { get; set; }
    }

    public class CustomerData
    {
        public int Id { get; set; }
        public string Full_name { get; set; }
        public string Username { get; set; }
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }
    }
}
