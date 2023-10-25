using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using expensetracker.Models;

namespace expensetracker.Pages.test
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
            return Page();
        }

        [BindProperty]
        public ExpenseCategory ExpenseCategory { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ExpenseCategories == null || ExpenseCategory == null)
            {
                return Page();
            }

            _context.ExpenseCategories.Add(ExpenseCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
