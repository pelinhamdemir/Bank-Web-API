using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIproject.Data;
using WebAPIproject.DTOS.Stock;
using WebAPIproject.Interfaces;
using WebAPIproject.Models;
namespace WebAPIproject.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDBContext _context;

        public AccountRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task CreateAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task<Account?> UpdateAsync(int id, Account account)
        {
            var existingAccount = await _context.Accounts.FindAsync(id);
            if (existingAccount == null)
                return null;

            existingAccount.CustomerId = account.CustomerId;
            existingAccount.AccountType = account.AccountType;
            existingAccount.Balance = account.Balance;

            await _context.SaveChangesAsync();
            return existingAccount;
        }

        public async Task<Account?> DeleteAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
                return null;

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return account;
        }
    }
}
