using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Controllers
{
    [ApiController]
    [Route("Controller")]
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
        public IActionResult Put(int id, Customers customerput)
        {
            var customer = _context.customers.First(i => i.Id == id);

            customer.full_name = customerput.full_name;
            customer.username = customerput.username;
            customer.birthdate = customerput.birthdate;
            customer.password = customerput.password;
            customer.gender = customerput.gender;
            customer.email = customerput.email;
            customer.phone_number = customerput.phone_number;
            customer.created_at = customer.created_at;
            customer.update_at = DateTime.Now;

            _context.customers.Update(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post(Customers customer)
        {
            _context.customers.Add(customer);
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
