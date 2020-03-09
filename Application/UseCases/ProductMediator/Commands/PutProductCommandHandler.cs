using System;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.ProductMediator.Queries.GetProduct;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.ProductMediator.Commands
{
    public class PutProductCommandHandler : IRequestHandler<PutProductCommand, GetProductDTO>
    {
        private readonly Task18Context _context;

        public PutProductCommandHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<GetProductDTO> Handle(PutProductCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.products.FindAsync(request.Data.Attributes.Id);

            data.name = request.Data.Attributes.name;
            data.merchant_id = request.Data.Attributes.merchant_id;
            data.price = request.Data.Attributes.price;

            _context.SaveChanges();

            BackgroundJob.Enqueue(() => Console.WriteLine("Put Product has been done."));
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
