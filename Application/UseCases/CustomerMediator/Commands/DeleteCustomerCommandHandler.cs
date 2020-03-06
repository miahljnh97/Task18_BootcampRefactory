using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Request;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, CustomerDTO>
    {
        private readonly Task18Context _context;
        public DeleteCustomerCommandHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<CustomerDTO> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.customers.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.customers.Remove(data);
            await _context.SaveChangesAsync();

            return new CustomerDTO { Message = "Successfull", Success = true };
        }
    }
}
