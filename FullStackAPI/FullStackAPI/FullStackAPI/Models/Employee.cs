using System;
using System.Collections.Generic;

namespace FullStackAPI.Models;

public partial class Employee
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public long? Phone { get; set; }

    public int? Age { get; set; }

    public int? Salary { get; set; }

    public string? Department { get; set; }
}
