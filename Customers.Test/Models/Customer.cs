using System;
using System.ComponentModel.DataAnnotations;

namespace Customers.Test.Models
{
    public class Customer
    {
        [Key]
        public string ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}