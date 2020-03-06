using System;
using MediatR;

namespace Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Queries.GetMerchant
{
    public class GetMerchantQuery : IRequest<GetMerchantDTO>
    {
        public int Id { get; set; }

        public GetMerchantQuery(int id)
        {
            Id = id;
        }
    }
}
