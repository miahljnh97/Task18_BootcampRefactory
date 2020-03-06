using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Queries.GetCustomerPay;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Commands
{
    public class PutCustomerPayCommandHandler : IRequestHandler<PutCustomerPayCommand, GetCustomerPayDTO>
    {
        private readonly Task18Context _context;

        public PutCustomerPayCommandHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<GetCustomerPayDTO> Handle(PutCustomerPayCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.customerPayCard.FindAsync(request.Data.Attributes.Id);

            data.customer_id = request.Data.Attributes.customer_id;
            data.name_on_card = request.Data.Attributes.name_on_card;
            data.exp_month = request.Data.Attributes.exp_month;
            data.exp_year = request.Data.Attributes.exp_year;
            data.postal_code = request.Data.Attributes.postal_code;
            data.credit_card_number = request.Data.Attributes.credit_card_number;

            _context.SaveChanges();
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