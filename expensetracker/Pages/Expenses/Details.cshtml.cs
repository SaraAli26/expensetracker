﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using expensetracker.Models;

namespace expensetracker.Pages.Expenses
{
    public class DetailsModel : PageModel
    {
        private readonly expensetracker.Models.ExpensetrackerContext _context;

        public DetailsModel(expensetracker.Models.ExpensetrackerContext context)
        {
            _context = context;
        }

      public Expense Expense { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Expenses == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses.FirstOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }
            else 
            {
                Expense = expense;
            }
            return Page();
        }
    }
}
