using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIproject.Models
{
    public class BankerInfo
    {
        public int Id { get; set; }
        public string? Name { get; set; }=string.Empty;
        public int BranchId { get; set; }

        //public Branch Branch { get; set; }
    }
}