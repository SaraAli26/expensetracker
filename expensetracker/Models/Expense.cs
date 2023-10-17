using expensetracker.Models;
using System;
using System.Collections.Generic;

namespace expensetracker.Models;

public partial class Expense
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal Amount { get; set; }

    public DateTime DateOfSepnding { get; set; }

    public Guid ExpenseCategory { get; set; }

    public bool Asset { get; set; }

    public bool Recurring { get; set; }

    public string UserId { get; set; } = null!;

    public virtual ExpenseCategory ExpenseCategoryNavigation { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
