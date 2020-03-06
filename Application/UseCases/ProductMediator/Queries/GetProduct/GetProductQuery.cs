using System;
using MediatR;

namespace Task18_BootcampRefactory.Application.UseCases.ProductMediator.Queries.GetProduct
{
    public class GetProductQuery : IRequest<GetProductDTO>
    {
        public int Id { get; set; }

        public GetProductQuery(int id)
        {
            Id = id;
        }
    }
}
