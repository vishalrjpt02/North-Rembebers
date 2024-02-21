using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankTransections.Models
{
    public class Transection
    {
        [Key]
        public int TransectionId { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Account Number")]
        [Required (ErrorMessage = "This Field is required")]
        [MaxLength(12,ErrorMessage = "Account numbr has to be 12 digits only.")]
        public string AccountNumber { get; set; }

        
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Benificiary Name")]
        [Required(ErrorMessage = "This Field is required")]
        public string BenificaryName { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        [DisplayName("Bank Name")]
        [Required(ErrorMessage = "This Field is required")]
        public string BankName { get; set; }

        [Column(TypeName ="nvarchar(11)")]
        [DisplayName("Swift Code")]
        [Required(ErrorMessage = "This Field is required")]
        [MaxLength(11, ErrorMessage = "Account numbr has to be 12 digits only.")]
        public string SwiftCode { get; set; }
        
        public int Amount { get; set; }

        //[DisplayFormat(DataFormatString = "00:00,MMM-dd-mm-yy")]
        public DateTime Date { get; set; }
    }
}
