using System;
using System.Collections.Generic;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Queries.GetCustomerPays
{
    public class GetCustomerPaysDTO : BaseDTO
    {
        public List<Customers_Payment_Card> Data { get; set; }
    }
}
