using System;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Queries.GetCustomerPay;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Commands
{
    public class PutCustomerPayCommand : CommandDTO<Customers_Payment_Card>, IRequest<GetCustomerPayDTO>
    {
    }
}
