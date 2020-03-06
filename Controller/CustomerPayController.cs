using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Commands;
using Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Queries.GetCustomerPay;
using Task18_BootcampRefactory.Application.UseCases.CustomerPayMediator.Queries.GetCustomerPays;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Controller
{
    [ApiController]
    [Authorize]
    [Route("[Controller]")]
    public class CustomerPaymentController : ControllerBase
    {
        private IMediator _mediatr;

        public CustomerPaymentController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var custPay = new GetCustomerPaysQuery();

            return Ok(await _mediatr.Send(custPay));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var custPay = new GetCustomerPayQuery(id);

            return Ok(await _mediatr.Send(custPay));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var custPay = new DeleteCustomerPayCommand(id);
            var result = await _mediatr.Send(custPay);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "Customer not found" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PutCustomerPayCommand data)
        {
            data.Data.Attributes.Id = id;
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostCustomerPayCommand data)
        {
            var result = await _mediatr.Send(data);
            return Ok(result);
        }
    }
}
