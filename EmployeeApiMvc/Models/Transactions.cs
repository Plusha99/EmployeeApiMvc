using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeApiMvc.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        
        [Column(TypeName = "nvarchar(12)")]
        [Required(ErrorMessage ="This field is reqired")]
        [MaxLength(12, ErrorMessage ="Maximum 12 character only")]
        public string AccountName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This field is reqired")]
        public string BeneficiaryName { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This field is reqired")]
        public string BankName { get; set; }
        
        [Column(TypeName = "nvarchar(11)")]
        [Required(ErrorMessage = "This field is reqired")]
        [MaxLength(11,ErrorMessage ="Maximum 11 character only")]
        public string SWIFTCode { get; set; }

        [Required(ErrorMessage = "This field is reqired")]
        public int Amount { get; set; }

        [JsonIgnore]
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

    }
}