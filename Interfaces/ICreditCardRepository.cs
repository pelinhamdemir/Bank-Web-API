using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIproject.DTOS.CreditCard;
using WebAPIproject.Models;

namespace WebAPIproject.Interfaces
{
    public interface ICreditCardRepository
    {
        Task<List<CreditCard>> GetAllAsync();
        Task<CreditCard?> GetByIdAsync(int Id);
        Task<CreditCard> CreateAsync(CreditCard creditCardModel);
        Task<CreditCard?> UpdateAsync(int Id, CreditCard creditCardModel);
        Task<CreditCard?> DeleteAsync(int Id);
    }
}
