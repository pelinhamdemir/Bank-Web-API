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
    public class LoansController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ILoanRepository loanRepository;

        public LoansController(ApplicationDBContext context, ILoanRepository loanRepo)
        {
            loanRepository = loanRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var loans = await loanRepository.GetAllAsync();
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var loan = await loanRepository.GetByIdAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Loan loan)
        {
            await loanRepository.CreateAsync(loan);
            return CreatedAtAction(nameof(GetById), new { id = loan.Id }, loan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Loan loan)
        {
            var updatedLoan = await loanRepository.UpdateAsync(id, loan);

            if (updatedLoan == null)
            {
                return NotFound();
            }

            return Ok(updatedLoan);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var loan = await loanRepository.DeleteAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
