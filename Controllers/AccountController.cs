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
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IAccountRepository accountRepository;

        public AccountsController(ApplicationDBContext context, IAccountRepository accountRepo)
        {
            accountRepository = accountRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await accountRepository.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var account = await accountRepository.GetByIdAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Account account)
        {
            await accountRepository.CreateAsync(account);
            return CreatedAtAction(nameof(GetById), new { id = account.Id }, account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Account account)
        {
            var updatedAccount = await accountRepository.UpdateAsync(id, account);

            if (updatedAccount == null)
            {
                return NotFound();
            }

            return Ok(updatedAccount);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var account = await accountRepository.DeleteAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
