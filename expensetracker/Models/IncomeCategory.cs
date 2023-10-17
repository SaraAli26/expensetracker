using System;
using System.Collections.Generic;

namespace expensetracker.Models;

public partial class IncomeCategory
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Decsription { get; set; } = null!;

    public virtual ICollection<Income> Incomes { get; set; } = new List<Income>();
}
