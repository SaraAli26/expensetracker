using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using expensetracker.Models;

namespace expensetracker.Pages.Incomes
{
    public class EditModel : PageModel
    {
        private readonly expensetracker.Models.ExpensetrackerContext _context;

        public EditModel(expensetracker.Models.ExpensetrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Income Income { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Incomes == null)
            {
                return NotFound();
            }

            var income =  await _context.Incomes.FirstOrDefaultAsync(m => m.Id == id);
            if (income == null)
            {
                return NotFound();
            }
            Income = income;
           ViewData["IncomeCategory"] = new SelectList(_context.IncomeCategories, "Id", "Id");
           ViewData["UserId"] = new SelectList(_context.Set<AspNetUser>(), "Id", "Id");
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

            _context.Attach(Income).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeExists(Income.Id))
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

        private bool IncomeExists(Guid id)
        {
          return (_context.Incomes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
