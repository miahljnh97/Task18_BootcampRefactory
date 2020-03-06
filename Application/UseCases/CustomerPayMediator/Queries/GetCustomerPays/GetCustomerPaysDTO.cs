using System;
using System.Collections.Generic;
using Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Queries.GetCustomerPay;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Queries.GetCustomerPays
{
    public class GetCustomerPaysDTO : BaseDTO
    {
        public List<CustomerPayData> Data { get; set; }
    }
}
