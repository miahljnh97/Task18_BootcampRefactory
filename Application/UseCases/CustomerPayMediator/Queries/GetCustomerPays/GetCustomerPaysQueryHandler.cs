using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Queries.GetCustomerPay;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Queries.GetCustomerPays
{
    public class GetCustomerPaysQueryHandler : IRequestHandler<GetCustomerPaysQuery, GetCustomerPaysDTO>
    {
        private readonly Task18Context _context;

        public GetCustomerPaysQueryHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<GetCustomerPaysDTO> Handle(GetCustomerPaysQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.customerPayCard.ToListAsync();
            var result = new List<CustomerPayData>();

            foreach (var x in data)
            {
                result.Add(new CustomerPayData
                {
                    Id = x.Id,
                    Customer_id = x.customer_id,
                    Name_on_card = x.name_on_card,
                    Exp_month = x.exp_month,
                    Exp_year = x.exp_year,
                    Postal_code = x.postal_code,
                    Credit_card_number = x.credit_card_number
                });
            }

            BackgroundJob.Enqueue(() => Console.WriteLine("Customer Payment Card data retreived."));
            return new GetCustomerPaysDTO
            {
                Success = true,
                Message = "Success retreiving data",
                Data = result
            };
        }
    }
}
