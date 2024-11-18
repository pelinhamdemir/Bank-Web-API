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
    public class BranchesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IBranchRepository branchRepository;

        public BranchesController(ApplicationDBContext context, IBranchRepository branchRepo)
        {
            branchRepository = branchRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var branches = await branchRepository.GetAllAsync();
            return Ok(branches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var branch = await branchRepository.GetByIdAsync(id);

            if (branch == null)
            {
                return NotFound();
            }

            return Ok(branch);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Branch branch)
        {
            await branchRepository.CreateAsync(branch);
            return CreatedAtAction(nameof(GetById), new { id = branch.Id }, branch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Branch branch)
        {
            var updatedBranch = await branchRepository.UpdateAsync(id, branch);

            if (updatedBranch == null)
            {
                return NotFound();
            }

            return Ok(updatedBranch);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var branch = await branchRepository.DeleteAsync(id);

            if (branch == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpGet("branches/{name}")]
public async Task<IActionResult> GetBranchesByName(string name)
{
    var branches = await _context.Branches
        .Where(x => x.Name != null && x.Name.ToLower().StartsWith(name.ToLower()))
        .ToListAsync();

    if (branches == null || branches.Count == 0)
    {
        return NotFound();
    }

    return Ok(branches);
}
    }
}
