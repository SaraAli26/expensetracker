using expensetracker.Models;
using System;
using System.Collections.Generic;

namespace expensetracker.Models;

public partial class Income
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal Amount { get; set; }

    public DateTime DateOfReceiving { get; set; }

    public Guid IncomeCategory { get; set; }

    public bool? Recurring { get; set; }

    public string UserId { get; set; } = null!;

    public virtual IncomeCategory IncomeCategoryNavigation { get; set; } = null!;

   public virtual AspNetUser User { get; set; } = null!;
}
