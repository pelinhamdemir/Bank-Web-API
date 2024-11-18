using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIproject.Data;
using WebAPIproject.Interfaces;
using WebAPIproject.Models;

namespace WebAPIproject.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDBContext _context;

        public LoanRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetAllAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<Loan?> GetByIdAsync(int id)
        {
            return await _context.Loans.FindAsync(id);
        }

        public async Task<Loan> CreateAsync(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task<Loan?> UpdateAsync(int id, Loan loan)
        {
            var existingLoan = await _context.Loans.FindAsync(id);
            if (existingLoan == null)
            {
                return null;
            }

            existingLoan.CustomerId = loan.CustomerId;
            existingLoan.IssuedAmount = loan.IssuedAmount;
            existingLoan.RemainingAmount = loan.RemainingAmount;
            existingLoan.BranchId = loan.BranchId;
            existingLoan.AccountId = loan.AccountId;

            _context.Loans.Update(existingLoan);
            await _context.SaveChangesAsync();
            return existingLoan;
        }

        public async Task<Loan?> DeleteAsync(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                return null;
            }

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
            return loan;
        }
    }
}
