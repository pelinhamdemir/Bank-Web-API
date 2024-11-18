using WebAPIproject.DTOS.BankerInfo;
using WebAPIproject.Models;

namespace WebAPIproject.Mappers
{
    public static class BankerInfoMapper
    {
        public static BankerInfoDTO ToBankerInfoDTO(this BankerInfo bankerInfo)
        {
             if (bankerInfo == null)
                throw new ArgumentNullException(nameof(bankerInfo)); // Throw an exception for null input

            return new BankerInfoDTO
            {
                Id = bankerInfo.Id,
                Name = bankerInfo.Name,
                BranchId = bankerInfo.BranchId
            };
        }

        public static BankerInfo ToBankerInfoFromCreateDTO(this CreateBankerInfoRequestDTO createBankerInfoRequestDTO)
        {
            return new BankerInfo
            {
                Name = createBankerInfoRequestDTO.Name,
                BranchId = createBankerInfoRequestDTO.BranchId
            };
        }
    }
}
