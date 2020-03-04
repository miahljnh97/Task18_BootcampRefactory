using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly Task18Context _context;

        public CustomerController(Task18Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customer = _context.customers;

            return Ok(new
            {
                message = "success retrieve data",
                status = true,
                data = customer
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _context.customers.First(i => i.Id == id);

            return Ok(new
            {
                message = "success retrieve data",
                status = true,
                data = customer
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _context.customers.First(i => i.Id == id);

            _context.customers.Remove(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, RequestData<Customers> customerput)
        {
            var customer = _context.customers.First(i => i.Id == id);

            customer.full_name = customerput.data.attributes.full_name;
            customer.username = customerput.data.attributes.username;
            customer.birthdate = customerput.data.attributes.birthdate;
            customer.password = customerput.data.attributes.password;
            customer.gender = customerput.data.attributes.gender;
            customer.email = customerput.data.attributes.email;
            customer.phone_number = customerput.data.attributes.phone_number;
            customer.created_at = customerput.data.attributes.created_at;
            customer.update_at = DateTime.Now;

            _context.customers.Update(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post(RequestData<Customers> customer)
        {
            _context.customers.Add(customer.data.attributes);
            _context.SaveChanges();
            return Ok(new
            {
                message = "success retrieve data",
                status = true,
                data = customer
            });
        }
    }
}
