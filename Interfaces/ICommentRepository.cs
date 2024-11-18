using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIproject.Models;

namespace WebAPIproject.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int Id);
        Task CreateAsync(Comment comment);
        Task<Comment?> UpdateAsync(int Id, Comment comment);
        Task<Comment?> DeleteAsync(int Id);
    }
}
