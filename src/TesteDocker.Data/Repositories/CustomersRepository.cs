using System;
using System.Collections.Generic;
using TesteDocker.Data.Abstractions.Interfaces;
using TesteDocker.Entities.Models;

namespace TesteDocker.Data.Repositories
{
    public sealed class CustomersRepository : ICustomersRepository
    {
        private readonly List<Customer> _customers;

        public CustomersRepository()
        {
            _customers = new List<Customer>()
            {
                new Customer() { Name = "Maria", Age = 42 },
                new Customer() { Name = "Jão", Age = 22 },
                new Customer() { Name = "Irineu", Age = 21 },
                new Customer() { Name = "Marina", Age = 34 }
            };
        }

        public IEnumerable<Customer> GetCustomers()
            => _customers;

        public void InsertCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            _customers.Add(customer);
        }
    }
}