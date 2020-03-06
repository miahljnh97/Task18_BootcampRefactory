using System;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.ProductMediator.Request;

namespace Task18_BootcampRefactory.Application.UseCases.ProductMediator.Commands
{
    public class DeleteProductCommand : IRequest<ProductDTO>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
