using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIproject.Models;


namespace WebAPIproject.DTOS.CreditCard
{
    public class CreditCardDTO
    {
        public int Id { get; set; }
        public decimal CardLimit { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
    }
}
