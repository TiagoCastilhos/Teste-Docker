using System.Collections.Generic;
using TesteDocker.Entities.Models;

namespace TesteDocker.Data.Abstractions.Interfaces
{
    public interface ICustomersRepository
    {
        void InsertCustomer (Customer customer);

        IEnumerable<Customer> GetCustomers();       
    }
}