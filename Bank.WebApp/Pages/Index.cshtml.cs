using Bank.WebApp.Models;
using Bank.WebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Bank.WebApp.Pages
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBankRepository _repos;

        public IndexModel(ILogger<IndexModel> logger, IBankRepository repos)
        {
            _logger = logger;
            _repos = repos;
        }

        public List<Transaction> TransactionList { get; set; }

        [BindProperty]
        public Transaction Transaction { get; set; }

        public void OnGet()
        {
            TransactionList = _repos.GetTransactions();
        }
        
        public IActionResult OnPost()
        {
            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                _repos.Withdraw(Transaction);
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
