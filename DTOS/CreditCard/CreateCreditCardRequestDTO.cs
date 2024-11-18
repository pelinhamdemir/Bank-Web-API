using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIproject.DTOS.CreditCard
{
    public class CreateCreditCardRequestDTO
    {
        public decimal CardLimit { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
    }
}
