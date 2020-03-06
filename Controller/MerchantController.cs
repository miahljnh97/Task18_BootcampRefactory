using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Commands;
using Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Queries.GetMerchant;
using Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Queries.GetMerchants;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Controller
{
    [ApiController]
    //[Authorize]
    [Route("[Controller]")]
    public class MerchantController : ControllerBase
    {
        private IMediator _mediatr;

        public MerchantController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var merchant = new GetMerchantsQuery();

            return Ok(await _mediatr.Send(merchant));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var merchant = new GetMerchantQuery(id);

            return Ok(await _mediatr.Send(merchant));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var merchant = new DeleteMerchantCommand(id);
            var result = await _mediatr.Send(merchant);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "Customer not found" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PutMerchantCommand data)
        {
            data.Data.Attributes.Id = id;
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostMerchantCommand data)
        {
            var result = await _mediatr.Send(data);
            return Ok(result);
        }
    }
}
