using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using expensetracker.Models;

namespace expensetracker.Pages.Expenses
{
    public class CreateModel : PageModel
    {
        private readonly expensetracker.Models.ExpensetrackerContext _context;

        public CreateModel(expensetracker.Models.ExpensetrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ExpenseCategory"] = new SelectList(_context.ExpenseCategories, "Id", "Id");
        ViewData["UserId"] = new SelectList(_context.Set<AspNetUser>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Expense Expense { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Expenses == null || Expense == null)
            {
                return Page();
            }

            _context.Expenses.Add(Expense);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
