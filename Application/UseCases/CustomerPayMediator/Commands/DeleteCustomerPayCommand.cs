using System;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Request;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Commands
{
    public class DeleteCustomerPayCommand : IRequest<CustomerPayDTO>
    {
        public int Id { get; set; }
        public DeleteCustomerPayCommand(int id)
        {
            Id = id;
        }
    }
}
