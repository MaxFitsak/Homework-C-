using System;
using System.Collections.Generic;
using System.Text;

namespace Homework24
{
    public class Position
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public List<Employee> Employees { get; set; } = new();
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public int PositionId { get; set; }
        public Position Position { get; set; } = null!;

        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
    }
}
