using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIproject.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string? Name { get; set; }=string.Empty;
        public decimal Assets { get; set; }
        public string? Address { get; set; }=string.Empty;

        //public ICollection<Loan> Loans { get; set; }
        //public ICollection<BankerInfo> BankerInfos { get; set; }
    }
}