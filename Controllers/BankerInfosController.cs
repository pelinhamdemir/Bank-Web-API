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
    public class BankerInfosController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IBankerInfoRepository bankerInfoRepository;

        public BankerInfosController(ApplicationDBContext context, IBankerInfoRepository bankerInfoRepo)
        {
            bankerInfoRepository = bankerInfoRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bankerInfos = await bankerInfoRepository.GetAllAsync();
            return Ok(bankerInfos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var bankerInfo = await bankerInfoRepository.GetByIdAsync(id);

            if (bankerInfo == null)
            {
                return NotFound();
            }

            return Ok(bankerInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BankerInfo bankerInfo)
        {
            await bankerInfoRepository.CreateAsync(bankerInfo);
            return CreatedAtAction(nameof(GetById), new { id = bankerInfo.Id }, bankerInfo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BankerInfo bankerInfo)
        {
            var updatedBankerInfo = await bankerInfoRepository.UpdateAsync(id, bankerInfo);

            if (updatedBankerInfo == null)
            {
                return NotFound();
            }

            return Ok(updatedBankerInfo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var bankerInfo = await bankerInfoRepository.DeleteAsync(id);

            if (bankerInfo == null)
            {
                return NotFound();
            }

            return NoContent();
        }

       [HttpGet("name/{name}")]
public async Task<IActionResult> GetByName(string name)
{
    var bankerInfos = await _context.BankerInfos
        .Where(x => x.Name != null && x.Name.ToLower().StartsWith(name.ToLower()))
        .ToListAsync();

    if (bankerInfos == null || bankerInfos.Count == 0)
    {
        return NotFound();
    }

    return Ok(bankerInfos);
}
}
}