using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using expensetracker.Models;

namespace expensetracker.Pages.IncomeCategories
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
        public IncomeCategory IncomeCategory { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.IncomeCategories == null || IncomeCategory == null)
            {
                return Page();
            }

            _context.IncomeCategories.Add(IncomeCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
