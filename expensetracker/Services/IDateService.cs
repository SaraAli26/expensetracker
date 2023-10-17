using expensetracker.Models;
using expensetracker.Services;

namespace expensetracker.Services
{
    public interface IDateService
    {
        List<ExpenseCategory> GetExpenseCategoriesList();

    }
}
