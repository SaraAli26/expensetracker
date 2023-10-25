using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using expensetracker.Models;

namespace expensetracker.Pages.Budgets
{
    public class DeleteModel : PageModel
    {
        private readonly expensetracker.Models.ExpensetrackerContext _context;

        public DeleteModel(expensetracker.Models.ExpensetrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Budget Budget { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Budgets == null)
            {
                return NotFound();
            }

            var budget = await _context.Budgets.FirstOrDefaultAsync(m => m.Id == id);

            if (budget == null)
            {
                return NotFound();
            }
            else 
            {
                Budget = budget;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Budgets == null)
            {
                return NotFound();
            }
            var budget = await _context.Budgets.FindAsync(id);

            if (budget != null)
            {
                Budget = budget;
                _context.Budgets.Remove(Budget);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
