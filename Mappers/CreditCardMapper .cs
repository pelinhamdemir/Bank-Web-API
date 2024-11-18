using WebAPIproject.DTOS.CreditCard;
using WebAPIproject.Models;

namespace WebAPIproject.Mappers
{
    public static class CreditCardMapper
    {
        public static CreditCardDTO ToCreditCardDTO(this CreditCard creditCard)
        {
            if (creditCard == null)
                throw new ArgumentNullException(nameof(creditCard)); // Throw an exception for null input
            return new CreditCardDTO
            {
                Id = creditCard.Id,
                CardLimit = creditCard.CardLimit,
                ExpiryDate = creditCard.ExpiryDate,
                CustomerId = creditCard.CustomerId,
                AccountId = creditCard.AccountId
            };
        }

        public static CreditCard ToCreditCardFromCreateDTO(this CreateCreditCardRequestDTO createCreditCardRequestDTO)
        {
            return new CreditCard
            {
                CardLimit = createCreditCardRequestDTO.CardLimit,
                ExpiryDate = createCreditCardRequestDTO.ExpiryDate,
                CustomerId = createCreditCardRequestDTO.CustomerId,
                AccountId = createCreditCardRequestDTO.AccountId
            };
        }
    }
}
