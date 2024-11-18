using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIproject.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public decimal CardLimit { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }

        //public Customer Customer { get; set; }
        //public Account Account { get; set; }
    }
}