using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Queries.GetCustomerPay
{
    public class GetCustomerPayQueryHandler : IRequestHandler<GetCustomerPayQuery,GetCustomerPayDTO>
    {
        private readonly Task18Context _context;
        public GetCustomerPayQueryHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<GetCustomerPayDTO> Handle(GetCustomerPayQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.customerPayCard.FindAsync(request.Id);

            if (data == null)
            {
                data = null;
            }

            return new GetCustomerPayDTO
            {
                Success = true,
                Message = "Success retreiving data",
                Data = new CustomerPayData
                {
                    Id = data.Id,
                    Customer_id = data.customer_id,
                    Name_on_card = data.name_on_card,
                    Exp_month = data.exp_month,
                    Exp_year = data.exp_year,
                    Postal_code = data.postal_code,
                    Credit_card_number = data.credit_card_number
                }
            };
        }
    }
}
