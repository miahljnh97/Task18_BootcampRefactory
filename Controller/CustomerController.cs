using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Commands;
using Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Queries.GetCustomer;
using Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Queries.GetCustomers;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediatr;
        public CustomerController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var customer = new GetCustomersQuery();

            return Ok(await _mediatr.Send(customer));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var customer = new GetCustomerQuery(id);

            return Ok(await _mediatr.Send(customer));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var customer = new DeleteCustomerCommand(id);
            var result = await _mediatr.Send(customer);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "Customer not found" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PutCustomerCommand data)
        {
            data.Data.Attributes.Id = id;
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostCustomerCommand data)
        {
            var result = await _mediatr.Send(data);
            return Ok(result);
        }
    }
}
