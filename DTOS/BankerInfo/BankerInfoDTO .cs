using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIproject.DTOS.BankerInfo
{
    public class BankerInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }=string.Empty;
        public int BranchId { get; set; }
    }
}
