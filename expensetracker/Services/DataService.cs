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
            var expenseCatgeoris = _context.ExpenseCategories.ToList();
            return expenseCatgeoris;
        }

        public List<IncomeCategory> GetIncomeCategoriesList()
        {
            var incomeCatgeoris = _context.IncomeCategories.ToList();
            return incomeCatgeoris;
        }
    }

  
}
