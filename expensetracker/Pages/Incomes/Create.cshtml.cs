using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using expensetracker.Models;

namespace expensetracker.Pages.Incomes
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
        ViewData["IncomeCategory"] = new SelectList(_context.IncomeCategories, "Id", "Id");
        ViewData["UserId"] = new SelectList(_context.Set<AspNetUser>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Income Income { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Incomes == null || Income == null)
            {
                return Page();
            }

            _context.Incomes.Add(Income);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
