using WebAPIproject.DTOS.LoanPayment;
using WebAPIproject.Models;

namespace WebAPIproject.Mappers
{
    public static class LoanPaymentMapper
    {
        public static LoanPaymentDTO ToLoanPaymentDTO(this LoanPayment loanPayment)
        {
           if (loanPayment == null)
                throw new ArgumentNullException(nameof(loanPayment)); // Throw an exception for null input

            return new LoanPaymentDTO
            {
                Id = loanPayment.Id,
                LoanId = loanPayment.LoanId,
                Amount = loanPayment.Amount,
                Date = loanPayment.Date
            };
        }

        public static LoanPayment ToLoanPaymentFromCreateDTO(this CreateLoanPaymentRequestDTO createLoanPaymentRequestDTO)
        {
            return new LoanPayment
            {
                LoanId = createLoanPaymentRequestDTO.LoanId,
                Amount = createLoanPaymentRequestDTO.Amount,
                Date = createLoanPaymentRequestDTO.Date
            };
        }
    }
}
