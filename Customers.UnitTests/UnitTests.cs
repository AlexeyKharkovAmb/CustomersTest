using Customers.Test;
using Customers.Test.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace Customers.UnitTests
{
    public class UnitTests
    {
        [TestCase]        
        public void AddCustomer()
        {
            var _dbContext = new CustomersDBContext(new DbContextOptionsBuilder<CustomersDBContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
                        
            var customer = new Customer { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1976, 2, 11) };

            _dbContext.UpdateCustomer(customer);

            var customerExists = _dbContext.GetCustomer(customer.ID) != null;

            Assert.AreEqual(customerExists, true);
        }

        [TestCase]
        public void UpdateCustomer()
        {
            var _dbContext = new CustomersDBContext(new DbContextOptionsBuilder<CustomersDBContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

            var customer = new Customer { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1976, 2, 11) };

            customer.ID = _dbContext.UpdateCustomer(customer);

            customer.FirstName = "Jim";

            customer.LastName = "Johnson";

            customer.DateOfBirth = new DateTime(1975, 1, 10);

            _dbContext.UpdateCustomer(customer);

            var customerinDb = _dbContext.GetCustomer(customer.ID);

            Assert.AreEqual(customerinDb.FirstName, customer.FirstName);

            Assert.AreEqual(customerinDb.LastName, customer.LastName);

            Assert.AreEqual(customerinDb.DateOfBirth, customer.DateOfBirth);
        }

        [TestCase]
        public void SearchCustomerSuccess_1()
        {
            var _dbContext = new CustomersDBContext(new DbContextOptionsBuilder<CustomersDBContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

            var customer = new Customer { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1976, 2, 11) };

            customer.ID = _dbContext.UpdateCustomer(customer);

            var customerExists = _dbContext.FindCustomer("John D") != null;

            Assert.AreEqual(customerExists, true);
        }

        [TestCase]
        public void SearchCustomerSuccess_2()
        {
            var _dbContext = new CustomersDBContext(new DbContextOptionsBuilder<CustomersDBContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

            var customer = new Customer { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1976, 2, 11) };

            customer.ID = _dbContext.UpdateCustomer(customer);

            var customerExists = _dbContext.FindCustomer("Joh") != null;

            Assert.AreEqual(customerExists, true);
        }

        [TestCase]
        public void SearchCustomerSuccess_3()
        {
            var _dbContext = new CustomersDBContext(new DbContextOptionsBuilder<CustomersDBContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
                        
            var customer = new Customer { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1976, 2, 11) };

            customer.ID = _dbContext.UpdateCustomer(customer);

            var customerExists = _dbContext.FindCustomer("Do") != null;

            Assert.AreEqual(customerExists, true);
        }

        [TestCase]
        public void SearchCustomerFailure()
        {
            var _dbContext = new CustomersDBContext(new DbContextOptionsBuilder<CustomersDBContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

            var customer = new Customer { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1976, 2, 11) };

            customer.ID = _dbContext.UpdateCustomer(customer);

            var customerExists = _dbContext.FindCustomer("Jim") != null;

            Assert.AreEqual(customerExists, false);
        }

        [TestCase]
        public void DeleteCsutomer()
        {
            var _dbContext = new CustomersDBContext(new DbContextOptionsBuilder<CustomersDBContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

            var customer = new Customer { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1976, 2, 11) };

            customer.ID = _dbContext.UpdateCustomer(customer);

            _dbContext.DeleteCustomer(customer.ID);

            var customerExists = _dbContext.GetCustomer(customer.ID) != null;

            Assert.AreEqual(customerExists, false);
        }
    }
}