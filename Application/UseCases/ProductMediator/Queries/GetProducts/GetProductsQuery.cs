using System;
using MediatR;

namespace Task18_BootcampRefactory.Application.UseCases.ProductMediator.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<GetProductsDTO>
    {
        public GetProductsQuery()
        {
        }
    }
}
