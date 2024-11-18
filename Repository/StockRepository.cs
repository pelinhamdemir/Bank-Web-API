using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIproject.Data;
using WebAPIproject.DTOS.Stock;
using WebAPIproject.Interfaces;
using WebAPIproject.Models;

namespace WebAPIproject.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext applicationDBContext)
        {
            _context = applicationDBContext;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int Id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == Id);
            if (stockModel == null)
            {
                return null;
            }

            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int Id)
        {
            return await _context.Stocks.FindAsync(Id);
        }

        public async Task<Stock?> UpdateAsync(int Id, UpdateStockRequestDTO updateStockRequestDTO)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == Id);
            if (existingStock == null)
            {
                return null;
            }

            existingStock.Symbol = updateStockRequestDTO.Symbol;
            existingStock.CompanyName = updateStockRequestDTO.CompanyName;
            existingStock.Purchase = updateStockRequestDTO.Purchase;
            existingStock.LastDiv = updateStockRequestDTO.LastDiv;
            existingStock.Industry = updateStockRequestDTO.Industry;
            existingStock.MarketCap = updateStockRequestDTO.MarketCap;

            await _context.SaveChangesAsync();
            return existingStock;
        }
    }
}
