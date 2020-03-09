using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Queries.GetMerchant;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Queries.GetMerchants
{
    public class GetMerchantsQueryHandler : IRequestHandler<GetMerchantsQuery, GetMerchantsDTO>
    {
        private readonly Task18Context _context;

        public GetMerchantsQueryHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<GetMerchantsDTO> Handle(GetMerchantsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.merchants.ToListAsync();
            var result = new List<MerchantData>();

            foreach (var x in data)
            {
                result.Add(new MerchantData
                {
                    Id = x.Id,
                    name = x.name,
                    image = x.image,
                    email = x.email,
                    address = x.address,
                    rating = x.rating
                });
            }

            BackgroundJob.Enqueue(() => Console.WriteLine("Merchant data retreived."));
            return new GetMerchantsDTO
            {
                Success = true,
                Message = "Success retreiving data",
                Data = result
            };
        }
    }
}
