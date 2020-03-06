using System;
using System.Threading;
using System.Threading.Tasks;
using Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Request;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Commands
{
    public class DeleteMerchantCommandHandler
    {
        private readonly Task18Context _context;
        public DeleteMerchantCommandHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<MerchantDTO> Handle(DeleteMerchantCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.merchants.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.merchants.Remove(data);
            await _context.SaveChangesAsync();

            return new MerchantDTO { Message = "Successfull", Success = true };

        }
    }
}
