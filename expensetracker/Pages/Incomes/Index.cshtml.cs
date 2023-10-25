using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using expensetracker.Models;

namespace expensetracker.Pages.Incomes
{
    public class IndexModel : PageModel
    {
        private readonly expensetracker.Models.ExpensetrackerContext _context;

        public IndexModel(expensetracker.Models.ExpensetrackerContext context)
        {
            _context = context;
        }

        public IList<Income> Income { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Incomes != null)
            {
                Income = await _context.Incomes
                .Include(i => i.IncomeCategoryNavigation)
                .Include(i => i.User).ToListAsync();
            }
        }
    }
}
