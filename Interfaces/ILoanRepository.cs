using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIproject.DTOS.Loan;
using WebAPIproject.Models;

namespace WebAPIproject.Interfaces
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAllAsync();
        Task<Loan?> GetByIdAsync(int Id);
        Task<Loan> CreateAsync(Loan loanModel);
        Task<Loan?> UpdateAsync(int Id, Loan loanModel);
        Task<Loan?> DeleteAsync(int Id);
    }
}
