using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inq_accont.Models.Entity
{
   public class ABCS_M_DDMEMO
   {
      [Required]
      [Column("ACCOUNTNUMBER")]
      [GraphQLName("account_number")]
      public string? AccountNumber { get; set; }
   }
}
