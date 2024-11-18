using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIproject.DTOS.Customer;
using WebAPIproject.Models;

namespace WebAPIproject.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int Id);
        Task<Customer> CreateAsync(Customer customerModel);
        Task<Customer?> UpdateAsync(int Id, Customer customerModel);
        Task<Customer?> DeleteAsync(int Id);
    }
}
