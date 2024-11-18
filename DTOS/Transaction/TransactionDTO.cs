using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIproject.DTOS.Transaction
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string? Type { get; set; }=string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
