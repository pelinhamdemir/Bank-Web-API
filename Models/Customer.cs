using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIproject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }=string.Empty;
        public string? MobileNumber { get; set; }=string.Empty;
        //public DateTime DateOfBirth { get; set; }
    }
}