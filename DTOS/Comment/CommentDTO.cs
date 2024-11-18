using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebAPIproject.DTOS
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string? Titile { get; set; } = string.Empty;
        public string? Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? StockId { get; set; }
    }
}
