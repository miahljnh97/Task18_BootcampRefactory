using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerDTO>
    {
        private readonly Task18Context _context;

        public GetCustomerQueryHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<GetCustomerDTO> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.customers.FindAsync(request.Id);

            if (data == null)
            {
                data = null;
            }

            return new GetCustomerDTO
            {
                Success = true,
                Message = "Success retreiving data",
                Data = new CustomerData
                {
                    Id = data.Id,
                    Full_name = data.full_name,
                    Username = data.username,
                    Birthdate = data.birthdate,
                    Password = data.password,
                    Gender = Enum.GetName(typeof(Gender), data.sex),
                    Email = data.email,
                    Phone_number = data.phone_number
                }
            };

        }
    }
}
