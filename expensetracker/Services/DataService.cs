using expensetracker.Models;
using Microsoft.EntityFrameworkCore;

namespace expensetracker.Services
{
    public class DataService : IDateService
    {
        private readonly ExpensetrackerContext _context;

        public DataService(ExpensetrackerContext context)
        {
            _context = context;
        }

        public List<ExpenseCategory> GetExpenseCategoriesList()
        {
            var catgeoris = _context.ExpenseCategories.ToList();
            return catgeoris;
        }
    }

  
}
