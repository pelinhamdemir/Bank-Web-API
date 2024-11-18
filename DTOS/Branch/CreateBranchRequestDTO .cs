using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIproject.DTOS.Branch
{
    public class CreateBranchRequestDTO
    {
        public string? Name { get; set; }=string.Empty;
        public decimal Assets { get; set; }
        public string? Address { get; set; }=string.Empty;
        public decimal Loans { get; set; }
    }
}
