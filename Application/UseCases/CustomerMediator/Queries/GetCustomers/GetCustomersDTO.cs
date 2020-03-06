using System;
using System.Collections.Generic;
using Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Queries.GetCustomer;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Queries.GetCustomers
{
    public class GetCustomersDTO : BaseDTO
    {
        public List<CustomerData> Data { get; set; }
    }
}
