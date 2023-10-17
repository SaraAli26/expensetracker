using System;
using System.Collections.Generic;

namespace expensetracker.Models;

public partial class ExpenseCategory
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Decsription { get; set; } = null!;

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
