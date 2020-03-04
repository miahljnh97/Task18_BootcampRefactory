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
    public class MerchantController : ControllerBase
    {
        private readonly Task18Context _context;

        public MerchantController(Task18Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var merchant = _context.merchants;

            return Ok(new
            {
                message = "success retrieve data",
                status = true,
                data = merchant
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var merchant = _context.merchants.First(i => i.Id == id);

            return Ok(new
            {
                message = "success retrieve data",
                status = true,
                data = merchant
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var merchant = _context.merchants.First(i => i.Id == id);

            _context.merchants.Remove(merchant);
            _context.SaveChanges();
            return Ok(merchant);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, RequestData<Merchant> merput)
        {
            var mer = _context.merchants.First(i => i.Id == id);

            mer.name = merput.data.attributes.name;
            mer.image = merput.data.attributes.image;
            mer.email = merput.data.attributes.email;
            mer.address = merput.data.attributes.address;
            mer.rating = merput.data.attributes.rating;
            mer.created_at = merput.data.attributes.created_at;
            mer.update_at = DateTime.Now;

            _context.merchants.Update(mer);
            _context.SaveChanges();
            return Ok(mer);
        }

        [HttpPost]
        public IActionResult Post(RequestData<Merchant> merchant)
        {
            _context.merchants.Add(merchant.data.attributes);
            _context.SaveChanges();
            return Ok(new
            {
                message = "success retrieve data",
                status = true,
                data = merchant
            });
        }
    }
}
