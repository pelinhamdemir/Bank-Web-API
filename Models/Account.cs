using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIproject.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? AccountType { get; set; }=string.Empty;
        public decimal Balance { get; set; }
       // public Customer Customer { get; set; }
    }
}