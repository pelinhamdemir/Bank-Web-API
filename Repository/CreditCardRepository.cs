using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIproject.Data;
using WebAPIproject.Interfaces;
using WebAPIproject.Models;

namespace WebAPIproject.Repository
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly ApplicationDBContext _context;

        public CreditCardRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<CreditCard>> GetAllAsync()
        {
            return await _context.CreditCards.ToListAsync();
        }

        public async Task<CreditCard?> GetByIdAsync(int id)
        {
            return await _context.CreditCards.FindAsync(id);
        }

        public async Task<CreditCard> CreateAsync(CreditCard creditCard)
        {
            _context.CreditCards.Add(creditCard);
            await _context.SaveChangesAsync();
            return creditCard;
        }

        public async Task<CreditCard?> UpdateAsync(int id, CreditCard creditCard)
        {
            var existingCreditCard = await _context.CreditCards.FindAsync(id);
            if (existingCreditCard == null)
            {
                return null;
            }

            existingCreditCard.CardLimit = creditCard.CardLimit;
            existingCreditCard.ExpiryDate = creditCard.ExpiryDate;
            existingCreditCard.CustomerId = creditCard.CustomerId;
            existingCreditCard.AccountId = creditCard.AccountId;

            _context.CreditCards.Update(existingCreditCard);
            await _context.SaveChangesAsync();
            return existingCreditCard;
        }

        public async Task<CreditCard?> DeleteAsync(int id)
        {
            var creditCard = await _context.CreditCards.FindAsync(id);
            if (creditCard == null)
            {
                return null;
            }

            _context.CreditCards.Remove(creditCard);
            await _context.SaveChangesAsync();
            return creditCard;
        }
    }
}
