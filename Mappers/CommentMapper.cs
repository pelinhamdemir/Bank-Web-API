using WebAPIproject.DTOS.Comment;
using WebAPIproject.Models;

namespace WebAPIproject.Mappers
{
    public static class CommentMapper
    {
        public static Comment ToComment(this Comment createCommentDTO)
        {
            if (createCommentDTO == null)
            {
                throw new ArgumentNullException(nameof(createCommentDTO));
            }

            return new Comment
            {
                Titile = createCommentDTO.Titile,
                Content = createCommentDTO.Content,
                StockId = createCommentDTO.StockId,
                CreatedOn = DateTime.Now // Set CreatedOn to the current date and time
            };
        }

        public static Comment ToCommentDTO(this Comment comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }

            return new Comment
            {
                Id = comment.Id,
                Titile = comment.Titile,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                StockId = comment.StockId
            };
        }
    }
}
