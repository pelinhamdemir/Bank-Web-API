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
    public class CreditCardsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICreditCardRepository creditCardRepository;

        public CreditCardsController(ApplicationDBContext context, ICreditCardRepository creditCardRepo)
        {
            creditCardRepository = creditCardRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var creditCards = await creditCardRepository.GetAllAsync();
            return Ok(creditCards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var creditCard = await creditCardRepository.GetByIdAsync(id);

            if (creditCard == null)
            {
                return NotFound();
            }

            return Ok(creditCard);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreditCard creditCard)
        {
            await creditCardRepository.CreateAsync(creditCard);
            return CreatedAtAction(nameof(GetById), new { id = creditCard.Id }, creditCard);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreditCard creditCard)
        {
            var updatedCreditCard = await creditCardRepository.UpdateAsync(id, creditCard);

            if (updatedCreditCard == null)
            {
                return NotFound();
            }

            return Ok(updatedCreditCard);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var creditCard = await creditCardRepository.DeleteAsync(id);

            if (creditCard == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
