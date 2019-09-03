using Customers.Test.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Customers.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private CustomersDBContext _context;

        public CustomersController(CustomersDBContext context)
        {
            _context = context;
        }
                
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "OK";
        }

        [HttpGet("get")]
        public ActionResult<Customer> Get(string id)
        {
            return _context.GetCustomer(id);
        }

        [HttpGet("find")]
        public ActionResult<Customer> Find(string partial)
        {
            return _context.FindCustomer(partial);
        }

        [HttpGet("update")]
        public ActionResult<string> Get(string id, string firstName, string lastName, string dob)
        {
            return _context.UpdateCustomer(new Customer
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = Convert.ToDateTime(dob)
            });
        }

        [HttpGet("delete")]
        public ActionResult<bool> Delete(string id)
        {
            return _context.DeleteCustomer(id);
        }
    }
}
