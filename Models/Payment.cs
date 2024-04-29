using System;
using System.Collections.Generic;

namespace insurance.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public string? CardHolder { get; set; }

    public string? CardNumber { get; set; }

    public string? ExpDate { get; set; }

    public int? EmpId { get; set; }
}
