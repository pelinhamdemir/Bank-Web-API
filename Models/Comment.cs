using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIproject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Titile { get; set; }=string.Empty;
        public string? Content { get; set; }=string.Empty;
        public DateTime CreatedOn { get; set; }=DateTime.Now;
        public int? StockId { get; set; }
        public Stock? stock { get; set; }
    }
}