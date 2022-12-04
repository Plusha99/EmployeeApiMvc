using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeeApiMvc.Models.Dtos
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }

        [DisplayName("Account Name")]
        public string AccountName { get; set; }

        [DisplayName("Beneficiary Name")]
        public string BeneficiaryName { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("SWIFT Code")]
        public string SWIFTCode { get; set; }

        [Required(ErrorMessage = "This field is reqired")]
        public int Amount { get; set; }
    }
}
