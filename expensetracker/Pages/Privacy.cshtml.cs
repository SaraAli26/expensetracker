using expensetracker.Models;
using expensetracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace expensetracker.Pages
{
    [Authorize]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IDateService _dataService;
        public List<ExpenseCategory> ExpenseCategoriesList { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger, IDateService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        public void OnGet()
        {
            ExpenseCategoriesList = _dataService.GetExpenseCategoriesList();
        }
    }
}