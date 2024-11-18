using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIproject.Data;
using WebAPIproject.Interfaces;
using WebAPIproject.Models;

namespace WebAPIproject.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDBContext _context;

        public TransactionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task<Transaction> CreateAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction?> UpdateAsync(int id, Transaction transaction)
        {
            var existingTransaction = await _context.Transactions.FindAsync(id);
            if (existingTransaction == null)
            {
                return null;
            }

            existingTransaction.AccountId = transaction.AccountId;
            existingTransaction.Type = transaction.Type;
            existingTransaction.Amount = transaction.Amount;
            existingTransaction.Date = transaction.Date;

            _context.Transactions.Update(existingTransaction);
            await _context.SaveChangesAsync();
            return existingTransaction;
        }

        public async Task<Transaction?> DeleteAsync(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return null;
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}
