using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task18_BootcampRefactory.Application.UseCases.ProductMediator.Commands;
using Task18_BootcampRefactory.Application.UseCases.ProductMediator.Queries.GetProduct;
using Task18_BootcampRefactory.Application.UseCases.ProductMediator.Queries.GetProducts;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Controller
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        private IMediator _mediatr;

        public ProductController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var product = new GetProductsQuery();

            return Ok(await _mediatr.Send(product));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var product = new GetProductQuery(id);

            return Ok(await _mediatr.Send(product));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var product = new DeleteProductCommand(id);
            var result = await _mediatr.Send(product);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "Customer not found" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PutProductCommand data)
        {
            data.Data.Attributes.Id = id;
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostProductCommand data)
        {
            var result = await _mediatr.Send(data);
            return Ok(result);
        }
    }
}
