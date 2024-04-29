using System;
using System.Collections.Generic;

namespace insurance.Models;

public partial class Policy
{
    public int PolicyId { get; set; }

    public string? Insurer { get; set; }

    public string? Type { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? EmpId { get; set; }
}
