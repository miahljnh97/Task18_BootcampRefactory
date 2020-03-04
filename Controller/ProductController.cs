using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Controller
{
    [ApiController]
    [Authorize]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly Task18Context _context;

        public ProductController(Task18Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var product = _context.products;

            return Ok(new
            {
                message = "success retrieve data",
                status = true,
                data = product
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.products.First(i => i.Id == id);

            return Ok(new
            {
                message = "success retrieve data",
                status = true,
                data = product
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.products.First(i => i.Id == id);

            _context.products.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, RequestData<Products> proput)
        {
            var pro = _context.products.First(i => i.Id == id);

            pro.name = proput.data.attributes.name;
            pro.price = proput.data.attributes.price;
            pro.created_at = proput.data.attributes.created_at;
            pro.update_at = DateTime.Now;

            _context.products.Update(pro);
            _context.SaveChanges();
            return Ok(pro);
        }

        [HttpPost]
        public IActionResult Post(RequestData<Products> product)
        {
            _context.products.Add(product.data.attributes);
            _context.SaveChanges();
            return Ok(new
            {
                message = "success retrieve data",
                status = true,
                data = product
            });
        }
    }
}
