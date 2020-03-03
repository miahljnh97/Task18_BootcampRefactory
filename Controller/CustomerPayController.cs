using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Controller
{
    [ApiController]
    [Authorize]
    [Route("Controller")]
    public class CustomerPaymentController : ControllerBase
    {
        private readonly Task18Context _context;

        public CustomerPaymentController(Task18Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var custPay = _context.customerPayCard;

            return Ok(new
            {
                message = "success retrieve data",
                status = true,
                data = custPay
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var custPay = _context.customerPayCard.First(i => i.Id == id);

            return Ok(new
            {
                message = "success retrieve data",
                status = true,
                data = custPay
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var custPay = _context.customerPayCard.First(i => i.Id == id);

            _context.customerPayCard.Remove(custPay);
            _context.SaveChanges();
            return Ok(custPay);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customers_Payment_Card cust)
        {
            var custPay = _context.customerPayCard.First(i => i.Id == id);

            custPay.customer_id = cust.customer_id;
            custPay.name_on_card = cust.name_on_card;
            custPay.exp_month = cust.exp_month;
            custPay.exp_year = cust.exp_year;
            custPay.postal_code = cust.postal_code;
            custPay.credit_card_number = cust.credit_card_number;
            custPay.created_at = cust.created_at;
            custPay.update_at = DateTime.Now;

            _context.customerPayCard.Update(custPay);
            _context.SaveChanges();
            return Ok(custPay);
        }

        [HttpPost]
        public IActionResult Post(Customers_Payment_Card custPay)
        {
            _context.customerPayCard.Add(custPay);
            _context.SaveChanges();
            return Ok(new
            {
                message = "success retrieve data",
                status = true,
                data = custPay
            });
        }
    }
}
