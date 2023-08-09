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

      [Column("CIFNUM")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("cif_num")]
      public string? CifNum { get; set; }

      [Column("PRODUCTTYPE")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("product_type")]
      public string? ProductType { get; set; }
   }
}
