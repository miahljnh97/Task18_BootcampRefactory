using System;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Queries.GetCustomer;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Commands
{
    public class PutCustomerCommand : CommandDTO<Customers>, IRequest<GetCustomerDTO>
    {
    }
}
