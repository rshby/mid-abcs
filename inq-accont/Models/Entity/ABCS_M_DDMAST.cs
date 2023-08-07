using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inq_accont.Models.Entity
{
   [Table("ABCS_M_DDMAST")]
   [GraphQLName("abcs_m_ddmast")]
   public class ABCS_M_DDMAST
   {
      [Required]
      [Column("ACCOUNTNUMBER")]
      [GraphQLName("account_number")]
      public string? AccountNumber { get; set; }
   }
}
