using WebAPIproject.DTOS.Stock;
using WebAPIproject.Models;

namespace WebAPIproject.Mappers
{
    public static class StockMapper
    {
        public static StockDTO ToStockDTO(this Stock stock)
        {
            if (stock == null)
                throw new ArgumentNullException(nameof(stock)); // Throw an exception for null input
            
            return new StockDTO
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Purchase = stock.Purchase,
                LastDiv = stock.LastDiv,
                Industry = stock.Industry,
                MarketCap = stock.MarketCap
            };
        }

        public static Stock ToStockFromCreateDTO(this CreateStockRequestDTO createStockRequestDTO)
        {
            if (createStockRequestDTO == null)
                throw new ArgumentNullException(nameof(createStockRequestDTO));
            
            return new Stock
            {
                Symbol = createStockRequestDTO.Symbol,
                CompanyName = createStockRequestDTO.CompanyName,
                Purchase = createStockRequestDTO.Purchase,
                LastDiv = createStockRequestDTO.LastDiv,
                Industry = createStockRequestDTO.Industry,
                MarketCap = createStockRequestDTO.MarketCap,
            };
        }
    }
}
 