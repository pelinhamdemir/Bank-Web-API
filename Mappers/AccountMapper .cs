using WebAPIproject.DTOS.Account;
using WebAPIproject.Models;

namespace WebAPIproject.Mappers
{
    public static class AccountMapper
    {
        public static AccountDTO ToAccountDTO(this Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account)); // Throw an exception for null input

            return new AccountDTO
            {
                Id = account.Id,
                CustomerId = account.CustomerId,
                AccountType = account.AccountType,
                Balance = account.Balance
            };
        }

        public static Account ToAccountFromCreateDTO(this CreateAccountRequestDTO createAccountRequestDTO)
        {
            return new Account
            {
                CustomerId = createAccountRequestDTO.CustomerId,
                AccountType = createAccountRequestDTO.AccountType,
                Balance = createAccountRequestDTO.Balance
            };
        }
    }
}
