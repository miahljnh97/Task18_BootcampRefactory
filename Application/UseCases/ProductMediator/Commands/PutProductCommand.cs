using System;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.ProductMediator.Queries.GetProduct;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.ProductMediator.Commands
{
    public class PutProductCommand : CommandDTO<Products>, IRequest<GetProductDTO>
    {
    }
}
