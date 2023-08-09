using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inq_accont.Models.Entity
{
   [Table("ABCS_P_DDPAR2")]
   [GraphQLName("abcs_p_ddpar2")]
   public class ABCS_P_DDPAR2
   {
      [Column("PRODUCTTYPE")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("product_type")]
      public string? ProductType { get; set; }

      [Column("MINIMUMBALANCE")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("minimum_balance")]
      public string? MinimumBalance { get; set; }
   }
}
