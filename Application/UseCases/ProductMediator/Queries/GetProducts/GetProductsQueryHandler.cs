using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task18_BootcampRefactory.Application.UseCases.ProductMediator.Queries.GetProduct;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.ProductMediator.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsDTO>
    {

        private readonly Task18Context _context;

        public GetProductsQueryHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<GetProductsDTO> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.products.ToListAsync();
            var result = new List<ProductData>();

            foreach (var x in data)
            {
                result.Add(new ProductData
                {
                    Id = x.Id,
                    name = x.name,
                    merchant_id = x.merchant_id,
                    price = x.price
                });
            }

            return new GetProductsDTO
            {
                Success = true,
                Message = "Success retreiving data",
                Data = result
            };
        }
    }
}
