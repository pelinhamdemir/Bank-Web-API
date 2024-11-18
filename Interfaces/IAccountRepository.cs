using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIproject.DTOS.Account;
using WebAPIproject.Models;

namespace WebAPIproject.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAsync();
        Task<Account?> GetByIdAsync(int Id);
        Task CreateAsync(Account account);
        Task<Account?> UpdateAsync(int Id, Account accountModel);
        Task<Account?> DeleteAsync(int Id);
    }
}
