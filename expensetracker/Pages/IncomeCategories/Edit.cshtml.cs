﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using expensetracker.Models;

namespace expensetracker.Pages.IncomeCategories
{
    public class EditModel : PageModel
    {
        private readonly expensetracker.Models.ExpensetrackerContext _context;

        public EditModel(expensetracker.Models.ExpensetrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IncomeCategory IncomeCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.IncomeCategories == null)
            {
                return NotFound();
            }

            var incomecategory =  await _context.IncomeCategories.FirstOrDefaultAsync(m => m.Id == id);
            if (incomecategory == null)
            {
                return NotFound();
            }
            IncomeCategory = incomecategory;
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

            _context.Attach(IncomeCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeCategoryExists(IncomeCategory.Id))
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

        private bool IncomeCategoryExists(Guid id)
        {
          return (_context.IncomeCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
