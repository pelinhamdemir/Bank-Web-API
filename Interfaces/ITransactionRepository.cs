using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIproject.DTOS.Transaction;
using WebAPIproject.Models;

namespace WebAPIproject.Interfaces
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIproject.DTOS.Transaction;
using WebAPIproject.Models;
public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(int Id);
        Task<Transaction> CreateAsync(Transaction transactionModel);
        Task<Transaction?> UpdateAsync(int Id, Transaction transactionModel);
        Task<Transaction?> DeleteAsync(int Id);
    }
}
