using Microsoft.AspNetCore.Mvc;
using TesteDocker.Data.Abstractions.Interfaces;
using TesteDocker.Entities.Models;

namespace TesteDocker.Controllers
{
    [Route("Customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersController(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository ?? throw new System.ArgumentNullException(nameof(customersRepository));
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(_customersRepository.GetCustomers());
        }

        [HttpPost]
        public IActionResult InsertCustomer([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest();

            _customersRepository.InsertCustomer(customer);

            return Ok();
        }
    }
}