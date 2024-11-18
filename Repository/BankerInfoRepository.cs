using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIproject.Data;
using WebAPIproject.DTOS.Stock;
using WebAPIproject.Interfaces;
using WebAPIproject.Models;

namespace WebAPIproject.Repository
{
    public class BankerInfoRepository : IBankerInfoRepository
    {
        private readonly ApplicationDBContext _context;

        public BankerInfoRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<BankerInfo>> GetAllAsync()
        {
            return await _context.BankerInfos.ToListAsync();
        }

        public async Task<BankerInfo?> GetByIdAsync(int id)
        {
            return await _context.BankerInfos.FindAsync(id);
        }

        public async Task CreateAsync(BankerInfo bankerInfo)
        {
            _context.BankerInfos.Add(bankerInfo);
            await _context.SaveChangesAsync();
        }

        public async Task<BankerInfo?> UpdateAsync(int id, BankerInfo bankerInfo)
        {
            var existingBankerInfo = await _context.BankerInfos.FindAsync(id);
            if (existingBankerInfo == null)
                return null;

            existingBankerInfo.Name = bankerInfo.Name;
            existingBankerInfo.BranchId = bankerInfo.BranchId;

            await _context.SaveChangesAsync();
            return existingBankerInfo;
        }

        public async Task<BankerInfo?> DeleteAsync(int id)
        {
            var bankerInfo = await _context.BankerInfos.FindAsync(id);
            if (bankerInfo == null)
                return null;

            _context.BankerInfos.Remove(bankerInfo);
            await _context.SaveChangesAsync();

            return bankerInfo;
        }
    }
}
