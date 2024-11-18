using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIproject.DTOS.Loan
{
    public class LoanDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal IssuedAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public int BranchId { get; set; }
        public int AccountId { get; set; }
    }
}
