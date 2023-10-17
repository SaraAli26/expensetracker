using System;
using System.Collections.Generic;

namespace expensetracker.Models;

public partial class Budget
{
    public Guid Id { get; set; }

    public DateTime Date { get; set; }

    public decimal Amount { get; set; }

    public Guid? ExpenseId { get; set; }
}
