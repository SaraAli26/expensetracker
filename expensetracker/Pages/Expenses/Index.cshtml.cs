using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using expensetracker.Models;

namespace expensetracker.Pages.Expenses
{
    public class IndexModel : PageModel
    {
        private readonly expensetracker.Models.ExpensetrackerContext _context;

        public IndexModel(expensetracker.Models.ExpensetrackerContext context)
        {
            _context = context;
        }

        public IList<Expense> Expense { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Expenses != null)
            {
                Expense = await _context.Expenses
                .Include(e => e.ExpenseCategoryNavigation)
                .Include(e => e.User).ToListAsync();
            }
        }
    }
}
