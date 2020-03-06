using System;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Queries.GetMerchant;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Commands
{
    public class PostMerchantCommand : CommandDTO<Merchant>, IRequest<GetMerchantDTO>
    {
        
    }
}
