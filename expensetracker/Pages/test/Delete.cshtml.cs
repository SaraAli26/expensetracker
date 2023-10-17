using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using expensetracker.Models;

namespace expensetracker.Pages.test
{
    public class DeleteModel : PageModel
    {
        private readonly expensetracker.Models.ExpensetrackerContext _context;

        public DeleteModel(expensetracker.Models.ExpensetrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ExpenseCategory ExpenseCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.ExpenseCategories == null)
            {
                return NotFound();
            }

            var expensecategory = await _context.ExpenseCategories.FirstOrDefaultAsync(m => m.Id == id);

            if (expensecategory == null)
            {
                return NotFound();
            }
            else 
            {
                ExpenseCategory = expensecategory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.ExpenseCategories == null)
            {
                return NotFound();
            }
            var expensecategory = await _context.ExpenseCategories.FindAsync(id);

            if (expensecategory != null)
            {
                ExpenseCategory = expensecategory;
                _context.ExpenseCategories.Remove(ExpenseCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
