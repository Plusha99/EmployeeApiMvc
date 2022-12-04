using EmployeeApiMvc.Data;
using EmployeeApiMvc.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApiMvc.Controllers
{
    public class TransactionController : Controller
    {
        private readonly DataContext _context;
        public TransactionController(DataContext context)
        {
            _context = context;
        }
        // GET: TransactionController
        public ActionResult Index()
        {
            var transactions = _context.Transactions.ToList();
            List<TransactionDto> result = new List<TransactionDto>();
            if (transactions != null)
            {
                foreach (var transaction in transactions)
                {
                    var Transaction = new TransactionDto()
                    {
                        AccountName = transaction.AccountName,
                        BeneficiaryName = transaction.BeneficiaryName,
                        BankName = transaction.BankName,
                        SWIFTCode = transaction.SWIFTCode,
                        Amount = transaction.Amount
                    };
                    result.Add(Transaction);
                }
                return View(result);
            }
            return View(result);
        }

    }
}
