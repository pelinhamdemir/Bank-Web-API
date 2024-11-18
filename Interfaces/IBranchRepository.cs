using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIproject.DTOS.Branch;
using WebAPIproject.Models;

namespace WebAPIproject.Interfaces
{
    public interface IBranchRepository
    {
        Task<List<Branch>> GetAllAsync();
        Task<Branch?> GetByIdAsync(int Id);
        Task<Branch> CreateAsync(Branch branchModel);
        Task<Branch?> UpdateAsync(int Id, Branch branchModel);
        Task<Branch?> DeleteAsync(int Id);
    }
}
