using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inq_accont.Models.Entity
{
   [Table("ABCS_M_CDMAST")]
   public class ABCS_M_CDMAST
   {
      [Required]
      [Column("ACCOUNTNUMBER")]
      [GraphQLName("account_number")]
      public string? AccountNumber { get; set; }
   }
}
