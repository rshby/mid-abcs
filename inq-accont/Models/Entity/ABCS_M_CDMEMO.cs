using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inq_accont.Models.Entity
{
   [Table("ABCS_M_CDMEMO")]
   public class ABCS_M_CDMEMO
   {
      [Required]
      [Column("ACCOUNTNUMBER")]
      [GraphQLName("account_number")]
      public string? AccountNumber { get; set; }
   }
}
