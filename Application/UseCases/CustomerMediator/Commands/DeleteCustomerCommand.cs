using System;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Request;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Commands
{
    public class DeleteCustomerCommand : IRequest<CustomerDTO>
    {
        public int Id { get; set; }
        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
