using Customers.Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Customers.Test
{
    public class CustomersDBContext : DbContext
    {
        public CustomersDBContext(DbContextOptions<CustomersDBContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public string UpdateCustomer(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.ID))
            {
                customer.ID = Guid.NewGuid().ToString();
            }

            var existingCustomer = GetCustomer(customer.ID);

            if (existingCustomer == null)
            {
                Customers.Add(customer);
            }
            else
            {
                existingCustomer.FirstName = customer.FirstName;

                existingCustomer.LastName = customer.LastName;

                existingCustomer.DateOfBirth = customer.DateOfBirth;
            }

            SaveChanges();

            return customer.ID;
        }

        public bool DeleteCustomer(string id)
        {
            var customer = GetCustomer(id);

            if (customer != null)
            {
                Customers.Remove(customer);

                SaveChanges();

                return true;
            }

            return false;
        }

        public Customer GetCustomer(string id)
        {
            return Customers.FirstOrDefault(x => x.ID == id);
        }

        public Customer FindCustomer(string partialName)
        {
            return Customers.FirstOrDefault(x => x.FirstName.Contains(partialName) ||
                                                 x.LastName.Contains(partialName) ||
                                                 string.Format("{0} {1}", x.FirstName, x.LastName).Contains(partialName));
        }
    }
}
