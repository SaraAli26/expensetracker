using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using expensetracker.Models;

namespace expensetracker.Pages.test
{
    public class EditModel : PageModel
    {
        private readonly expensetracker.Models.ExpensetrackerContext _context;

        public EditModel(expensetracker.Models.ExpensetrackerContext context)
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

            var expensecategory =  await _context.ExpenseCategories.FirstOrDefaultAsync(m => m.Id == id);
            if (expensecategory == null)
            {
                return NotFound();
            }
            ExpenseCategory = expensecategory;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ExpenseCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseCategoryExists(ExpenseCategory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExpenseCategoryExists(Guid id)
        {
          return (_context.ExpenseCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
