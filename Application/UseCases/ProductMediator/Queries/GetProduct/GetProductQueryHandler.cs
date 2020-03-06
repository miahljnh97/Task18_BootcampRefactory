using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.ProductMediator.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductDTO>
    {
        private readonly Task18Context _context;

        public GetProductQueryHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<GetProductDTO> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.products.FindAsync(request.Id);

            if (data == null)
            {
                data = null;
            }

            return new GetProductDTO
            {
                Success = true,
                Message = "Success retreiving data",
                Data = new ProductData
                {
                    Id = data.Id,
                    name = data.name,
                    merchant_id = data.merchant_id,
                    price = data.price
                }
            };
        }
    }
}
