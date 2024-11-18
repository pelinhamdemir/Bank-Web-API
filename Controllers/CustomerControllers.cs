using Microsoft.AspNetCore.Mvc;
using WebAPIproject.Data;
using WebAPIproject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIproject.Interfaces;

namespace WebAPIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ApplicationDBContext context, ICustomerRepository customerRepo)
        {
            customerRepository = customerRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await customerRepository.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var customer = await customerRepository.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer customer)
        {
            await customerRepository.CreateAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Customer customer)
        {
            var updatedCustomer = await customerRepository.UpdateAsync(id, customer);

            if (updatedCustomer == null)
            {
                return NotFound();
            }

            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var customer = await customerRepository.DeleteAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpGet("customers/{name}")]
public async Task<IActionResult> GetCustomersByName(string name)
{
    var customers = await _context.Customers
        .Where(x => x.Name != null && x.Name.ToLower().StartsWith(name.ToLower()))
        .ToListAsync();

    if (customers == null || customers.Count == 0)
    {
        return NotFound();
    }

    return Ok(customers);
}

    }
}
