using WebAPIproject.DTOS.Loan;
using WebAPIproject.Models;

namespace WebAPIproject.Mappers
{
    public static class LoanMapper
    {
        public static LoanDTO ToLoanDTO(this Loan loan)
        {
             if (loan == null)
                throw new ArgumentNullException(nameof(loan)); // Throw an exception for null input
            return new LoanDTO
            {
                Id = loan.Id,
                CustomerId = loan.CustomerId,
                IssuedAmount = loan.IssuedAmount,
                RemainingAmount = loan.RemainingAmount,
                BranchId = loan.BranchId,
                AccountId = loan.AccountId
            };
        }

        public static Loan ToLoanFromCreateDTO(this CreateLoanRequestDTO createLoanRequestDTO)
        {
            return new Loan
            {
                CustomerId = createLoanRequestDTO.CustomerId,
                IssuedAmount = createLoanRequestDTO.IssuedAmount,
                RemainingAmount = createLoanRequestDTO.IssuedAmount, // Assuming remaining amount starts with issued amount
                BranchId = createLoanRequestDTO.BranchId,
                AccountId = createLoanRequestDTO.AccountId
            };
        }
    }
}
