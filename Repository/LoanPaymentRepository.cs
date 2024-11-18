using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIproject.Data;
using WebAPIproject.Interfaces;
using WebAPIproject.Models;

namespace WebAPIproject.Repository
{
    public class LoanPaymentRepository : ILoanPaymentRepository
    {
        private readonly ApplicationDBContext _context;

        public LoanPaymentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<LoanPayment>> GetAllAsync()
        {
            return await _context.LoanPayments.ToListAsync();
        }

        public async Task<LoanPayment?> GetByIdAsync(int id)
        {
            return await _context.LoanPayments.FindAsync(id);
        }

        public async Task<LoanPayment> CreateAsync(LoanPayment loanPayment)
        {
            _context.LoanPayments.Add(loanPayment);
            await _context.SaveChangesAsync();
            return loanPayment; // Return the created entity
        }

        public async Task<LoanPayment?> UpdateAsync(int id, LoanPayment loanPayment)
        {
            var existingLoanPayment = await _context.LoanPayments.FindAsync(id);
            if (existingLoanPayment == null)
                return null;

            existingLoanPayment.LoanId = loanPayment.LoanId;
            existingLoanPayment.Amount = loanPayment.Amount;
            existingLoanPayment.Date = loanPayment.Date;

            await _context.SaveChangesAsync();
            return existingLoanPayment;
        }

        public async Task<LoanPayment?> DeleteAsync(int id)
        {
            var loanPayment = await _context.LoanPayments.FindAsync(id);
            if (loanPayment == null)
                return null;

            _context.LoanPayments.Remove(loanPayment);
            await _context.SaveChangesAsync();
            return loanPayment;
        }
    }
}
