using WebAPIproject.DTOS.Transaction;
using WebAPIproject.Models;

namespace WebAPIproject.Mappers
{
    public static class TransactionMapper
    {
        public static TransactionDTO ToTransactionDTO(this Transaction transaction)
        {
             if (transaction == null)
                throw new ArgumentNullException(nameof(transaction)); // Throw an exception for null input

            return new TransactionDTO
            {
                Id = transaction.Id,
                AccountId = transaction.AccountId,
                Type = transaction.Type,
                Amount = transaction.Amount,
                Date = transaction.Date
            };
        }

        public static Transaction ToTransactionFromCreateDTO(this CreateTransactionRequestDTO createTransactionRequestDTO)
        {
            return new Transaction
            {
                AccountId = createTransactionRequestDTO.AccountId,
                Type = createTransactionRequestDTO.Type,
                Amount = createTransactionRequestDTO.Amount,
                Date = createTransactionRequestDTO.Date
            };
        }
    }
}
