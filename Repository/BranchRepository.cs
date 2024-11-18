using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIproject.Data;
using WebAPIproject.Interfaces;
using WebAPIproject.Models;

namespace WebAPIproject.Repository
{
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDBContext _context;

        public BranchRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Branch>> GetAllAsync()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<Branch?> GetByIdAsync(int id)
        {
            return await _context.Branches.FindAsync(id);
        }

        public async Task<Branch> CreateAsync(Branch branch)
        {
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();
            return branch;
        }

        public async Task<Branch?> UpdateAsync(int id, Branch branch)
        {
            var existingBranch = await _context.Branches.FindAsync(id);
            if (existingBranch == null)
            {
                return null;
            }

            existingBranch.Name = branch.Name;
            existingBranch.Assets = branch.Assets;
            existingBranch.Address = branch.Address;

            _context.Branches.Update(existingBranch);
            await _context.SaveChangesAsync();
            return existingBranch;
        }

        public async Task<Branch?> DeleteAsync(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
            {
                return null;
            }

            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();
            return branch;
        }
    }
}
