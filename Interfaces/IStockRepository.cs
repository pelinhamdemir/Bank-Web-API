using WebAPIproject.DTOS.Stock;
using WebAPIproject.Models;

namespace WebAPIproject.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int Id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int Id, UpdateStockRequestDTO updateStockRequestDTO);
        Task<Stock?> DeleteAsync(int Id);
    }
}
