using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Queries.GetMerchant
{
    public class GetMerchantQueryHandler : IRequestHandler<GetMerchantQuery, GetMerchantDTO>
    {
        private readonly Task18Context _context;

        public GetMerchantQueryHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<GetMerchantDTO> Handle(GetMerchantQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.merchants.FindAsync(request.Id);

            if (data == null)
            {
                data = null;
            }

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
