using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIproject.DTOS.BankerInfo;
using WebAPIproject.Models;

namespace WebAPIproject.Interfaces
{
    public interface IBankerInfoRepository
    {
        Task<List<BankerInfo>> GetAllAsync();
        Task<BankerInfo?> GetByIdAsync(int Id);
        Task CreateAsync(BankerInfo bankerInfo);
        Task<BankerInfo?> UpdateAsync(int Id, BankerInfo bankerInfoModel);
        Task<BankerInfo?> DeleteAsync(int Id);
    }
}
