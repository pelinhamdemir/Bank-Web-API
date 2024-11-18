using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIproject.Data;
using WebAPIproject.Interfaces;
using WebAPIproject.Models;

namespace WebAPIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanPaymentsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ILoanPaymentRepository _loanPaymentRepository;

        public LoanPaymentsController(ApplicationDBContext context, ILoanPaymentRepository loanPaymentRepo)
        {
            _loanPaymentRepository = loanPaymentRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var loanPayments = await _loanPaymentRepository.GetAllAsync();
            return Ok(loanPayments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var loanPayment = await _loanPaymentRepository.GetByIdAsync(id);

            if (loanPayment == null)
            {
                return NotFound();
            }

            return Ok(loanPayment);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LoanPayment loanPayment)
        {
            await _loanPaymentRepository.CreateAsync(loanPayment);
            return CreatedAtAction(nameof(GetById), new { id = loanPayment.Id }, loanPayment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] LoanPayment loanPayment)
        {
            var updatedLoanPayment = await _loanPaymentRepository.UpdateAsync(id, loanPayment);

            if (updatedLoanPayment == null)
            {
                return NotFound();
            }

            return Ok(updatedLoanPayment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var loanPayment = await _loanPaymentRepository.DeleteAsync(id);

            if (loanPayment == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
