using System;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.ProductMediator.Request;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.ProductMediator.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductDTO>
    {
        private readonly Task18Context _context;

        public DeleteProductCommandHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<ProductDTO> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.products.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.products.Remove(data);
            await _context.SaveChangesAsync();

            BackgroundJob.Enqueue(() => Console.WriteLine("Post Product has been done."));
            return new ProductDTO { Message = "Successfull", Success = true };

        }
    }
}
