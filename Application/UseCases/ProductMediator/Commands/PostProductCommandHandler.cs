using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.ProductMediator.Queries.GetProduct;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.ProductMediator.Commands
{
    public class PostProductCommandHandler : IRequestHandler<PostProductCommand, GetProductDTO>
    {
        private readonly Task18Context _context;

        public PostProductCommandHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<GetProductDTO> Handle(PostProductCommand request, CancellationToken cancellationToken)
        {
            _context.products.Add(request.Data.Attributes);
            await _context.SaveChangesAsync();
            return new GetProductDTO
            {
                Message = "Success retreiving data",
                Success = true,
                Data = new ProductData
                {
                    Id = request.Data.Attributes.Id,
                    name = request.Data.Attributes.name,
                    merchant_id = request.Data.Attributes.merchant_id,
                    price = request.Data.Attributes.price
                }
            };
        }
    }
}
