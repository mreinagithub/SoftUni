﻿namespace _3.Projection.Models
{
    using System;

    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? Birthdate { get; set; }

        public string Address { get; set; }

        public Employee Manager { get; set; }
    }
}