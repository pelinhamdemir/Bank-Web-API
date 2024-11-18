using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIproject.DTOS.Comment
{
    public class CreateCommentRequestDTO
    {
        public string? Title { get; set; }=string.Empty;
        public string? Content { get; set; }=string.Empty;
        public int? StockId { get; set; }
    }
}
