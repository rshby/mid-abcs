using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inq_accont.Models.Entity
{
   [Table("ABCS_M_GLMEMO")]
   [GraphQLName("abcs_m_glmemo")]
   public class ABCS_M_GLMEMO
   {
      [Required]
      [Column("ACCOUNTNUMBER")]
      [MaxLength(50)]
      [GraphQLName("account_number")]
      public string? AccountNumber { get; set; }

      [Column("PRODUCTTYPE")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("product_type")]
      public string? ProductType { get; set; }
   }
}
