using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Queries.GetMerchant;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Commands
{
    public class PostMerchantCommandHandler : IRequestHandler<PostMerchantCommand, GetMerchantDTO>
    {
        private readonly Task18Context _context;
        public PostMerchantCommandHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<GetMerchantDTO> Handle(PostMerchantCommand request, CancellationToken cancellationToken)
        {
            _context.merchants.Add(request.Data.Attributes);
            await _context.SaveChangesAsync();
            return new GetMerchantDTO
            {
                Message = "Success retreiving data",
                Success = true,
                Data = new MerchantData
                {
                    Id = request.Data.Attributes.Id,
                    name = request.Data.Attributes.name,
                    image = request.Data.Attributes.image,
                    email = request.Data.Attributes.email,
                    address = request.Data.Attributes.address,
                    rating = request.Data.Attributes.rating
                }
            };
        }
    }
}
