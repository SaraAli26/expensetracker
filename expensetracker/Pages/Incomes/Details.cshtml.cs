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
    public class DetailsModel : PageModel
    {
        private readonly expensetracker.Models.ExpensetrackerContext _context;

        public DetailsModel(expensetracker.Models.ExpensetrackerContext context)
        {
            _context = context;
        }

      public Income Income { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Incomes == null)
            {
                return NotFound();
            }

            var income = await _context.Incomes.FirstOrDefaultAsync(m => m.Id == id);
            if (income == null)
            {
                return NotFound();
            }
            else 
            {
                Income = income;
            }
            return Page();
        }
    }
}
