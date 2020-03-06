using System;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Queries.GetCustomer;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Commands
{
    public class PostCustomerCommand : CommandDTO<Customers>, IRequest<GetCustomerDTO>
    {
    }
}
