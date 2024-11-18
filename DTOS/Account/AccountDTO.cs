using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIproject.DTOS.Account
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? AccountType { get; set; }=string.Empty;
        public decimal Balance { get; set; }
    }
}
