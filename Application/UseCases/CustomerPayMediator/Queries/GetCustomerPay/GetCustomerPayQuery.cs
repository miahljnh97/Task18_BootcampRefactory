using System;
using MediatR;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Queries.GetCustomerPay
{
    public class GetCustomerPayQuery : IRequest<GetCustomerPayDTO>
    {
        public int Id { get; set; }

        public GetCustomerPayQuery(int id)
        {
            Id = id;
        }
    }
}
