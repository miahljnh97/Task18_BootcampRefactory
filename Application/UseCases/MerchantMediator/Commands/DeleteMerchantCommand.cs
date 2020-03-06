using System;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Request;

namespace Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Commands
{
    public class DeleteMerchantCommand : IRequest<MerchantDTO>
    {
        public int Id { get; set; }

        public DeleteMerchantCommand(int id)
        {
            Id = id;
        }
    }
}
