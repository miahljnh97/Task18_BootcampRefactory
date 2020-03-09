using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Queries.GetCustomer;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Queries.GetCustomers
{
    public class GetCustomersQueryHandler :IRequestHandler<GetCustomersQuery, GetCustomersDTO>
    {
        private readonly Task18Context _context;

        public GetCustomersQueryHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<GetCustomersDTO> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.customers.ToListAsync();
            var result = new List<CustomerData>();

            foreach(var x in data)
            {
                result.Add(new CustomerData
                {
                    Id = x.Id,
                    Full_name = x.full_name,
                    Username = x.username,
                    Birthdate = x.birthdate,
                    Password = x.password,
                    Gender = Enum.GetName(typeof(Gender), x.sex),
                    Email = x.email,
                    Phone_number = x.phone_number
                });
            }

            BackgroundJob.Enqueue(() => Console.WriteLine("Customer data retreived."));
            return new GetCustomersDTO
            {
                Success = true,
                Message = "Success retreiving data",
                Data = result
            };
        }
    }
}
