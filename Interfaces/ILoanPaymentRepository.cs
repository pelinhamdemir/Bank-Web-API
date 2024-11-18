using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIproject.Models;

namespace WebAPIproject.Interfaces
{
    public interface ILoanPaymentRepository
    {
        Task<List<LoanPayment>> GetAllAsync();
        Task<LoanPayment?> GetByIdAsync(int id);
        Task<LoanPayment> CreateAsync(LoanPayment loanPayment);
        Task<LoanPayment?> UpdateAsync(int id, LoanPayment loanPayment);
        Task<LoanPayment?> DeleteAsync(int id);
    }
}
