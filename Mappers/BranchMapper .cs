using WebAPIproject.DTOS.Branch;
using WebAPIproject.Models;

namespace WebAPIproject.Mappers
{
    public static class BranchMapper
    {
        public static BranchDTO ToBranchDTO(this Branch branch)
        {
            if (branch == null)
                throw new ArgumentNullException(nameof(branch)); // Throw an exception for null input

            return new BranchDTO
            {
                Id = branch.Id,
                Name = branch.Name,
                Assets = branch.Assets,
                Address = branch.Address,
                
            };
        }

        public static Branch ToBranchFromCreateDTO(this CreateBranchRequestDTO createBranchRequestDTO)
        {
            return new Branch
            {
                Name = createBranchRequestDTO.Name,
                Assets = createBranchRequestDTO.Assets,
                Address = createBranchRequestDTO.Address
            };
        }
    }
}
