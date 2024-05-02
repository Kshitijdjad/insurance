using System;
using System.Collections.Generic;

namespace insurance.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? Name { get; set; }

    public long? PhoneNumber { get; set; }

    public string? Company { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
