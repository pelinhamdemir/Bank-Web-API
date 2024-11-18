using WebAPIproject.DTOS.Customer;
using WebAPIproject.Models;

namespace WebAPIproject.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerDTO ToCustomerDTO(this Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer)); // Throw an exception for null input

            return new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                MobileNumber = customer.MobileNumber
            };
        }

        public static Customer ToCustomerFromCreateDTO(this CreateCustomerRequestDTO createCustomerRequestDTO)
        {
            return new Customer
            {
                Name = createCustomerRequestDTO.Name,
                MobileNumber = createCustomerRequestDTO.MobileNumber
            };
        }
    }
}
