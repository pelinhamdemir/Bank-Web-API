using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIproject.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string? Type { get; set; }=string.Empty; // "debit" or "credit"
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        //public Account Account { get; set; }
    }
}