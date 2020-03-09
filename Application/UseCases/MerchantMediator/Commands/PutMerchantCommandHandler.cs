using System;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Queries.GetMerchant;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Commands
{
    public class PutMerchantCommandHandler : IRequestHandler<PutMerchantCommand, GetMerchantDTO>
    {

        private readonly Task18Context _context;

        public PutMerchantCommandHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<GetMerchantDTO> Handle(PutMerchantCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.merchants.FindAsync(request.Data.Attributes.Id);

            data.name = request.Data.Attributes.name;
            data.image = request.Data.Attributes.image;
            data.email = request.Data.Attributes.email;
            data.address = request.Data.Attributes.address;
            data.rating = request.Data.Attributes.rating;

            _context.SaveChanges();

            BackgroundJob.Enqueue(() => Console.WriteLine("Put Merchant has been done."));
            return new GetMerchantDTO
            {
                Success = true,
                Message = "Success retreiving data",
                Data = new MerchantData
                {
                    Id = data.Id,
                    name = data.name,
                    image = data.image,
                    email = data.email,
                    address = data.address,
                    rating = data.rating

                }
            };
        }
    }
}
