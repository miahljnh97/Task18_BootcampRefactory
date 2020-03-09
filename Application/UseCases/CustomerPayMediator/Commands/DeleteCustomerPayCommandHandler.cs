using System;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Request;
using Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Request;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Commands
{
    public class DeleteCustomerPayCommandHandler : IRequestHandler<DeleteCustomerPayCommand, CustomerPayDTO>
    {
        private readonly Task18Context _context;
        public DeleteCustomerPayCommandHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<CustomerPayDTO> Handle(DeleteCustomerPayCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.customerPayCard.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.customerPayCard.Remove(data);
            await _context.SaveChangesAsync();

            BackgroundJob.Enqueue(() => Console.WriteLine("Post Customer Payment Card has been done."));
            return new CustomerPayDTO { Message = "Successfull", Success = true };

        }
    }
}
