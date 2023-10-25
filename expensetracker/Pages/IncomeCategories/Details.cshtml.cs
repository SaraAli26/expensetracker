using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using expensetracker.Models;

namespace expensetracker.Pages.IncomeCategories
{
    public class DetailsModel : PageModel
    {
        private readonly expensetracker.Models.ExpensetrackerContext _context;

        public DetailsModel(expensetracker.Models.ExpensetrackerContext context)
        {
            _context = context;
        }

      public IncomeCategory IncomeCategory { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.IncomeCategories == null)
            {
                return NotFound();
            }

            var incomecategory = await _context.IncomeCategories.FirstOrDefaultAsync(m => m.Id == id);
            if (incomecategory == null)
            {
                return NotFound();
            }
            else 
            {
                IncomeCategory = incomecategory;
            }
            return Page();
        }
    }
}
