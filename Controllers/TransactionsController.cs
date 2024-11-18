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
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ITransactionRepository transactionRepository;

        public TransactionsController(ApplicationDBContext context, ITransactionRepository transactionRepo)
        {
            transactionRepository = transactionRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await transactionRepository.GetAllAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var transaction = await transactionRepository.GetByIdAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Transaction transaction)
        {
            await transactionRepository.CreateAsync(transaction);
            return CreatedAtAction(nameof(GetById), new { id = transaction.Id }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Transaction transaction)
        {
            var updatedTransaction = await transactionRepository.UpdateAsync(id, transaction);

            if (updatedTransaction == null)
            {
                return NotFound();
            }

            return Ok(updatedTransaction);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var transaction = await transactionRepository.DeleteAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
