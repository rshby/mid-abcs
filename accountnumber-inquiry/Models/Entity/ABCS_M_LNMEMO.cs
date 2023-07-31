using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accountnumber_inquiry.Models.Entity
{
   [Table("ABCS_M_LNMEMO")]
   [GraphQLName("abcs_m_lnmemo")]
   public class ABCS_M_LNMEMO
   {
      [Required]
      [Column("ACCOUNTNUMBER")]
      [MaxLength(50)]
      [GraphQLName("account_number")]
      public string? AccountNumber { get; set; }

      [Column("ACCOUNTTYPE")]
      [MaxLength(1)]
      [DefaultValue(null)]
      [GraphQLName("account_type")]
      public string? AccountType { get; set; }

      [Column("CIFNUM")]
      [MaxLength(10)]
      [DefaultValue(null)]
      [GraphQLName("cif_num")]
      public string? CifNum { get; set; }

      [Column("CBAL")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("cbal")]
      public string? Cbal { get; set; }

      [Column("HOLD")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("hold")]
      public string? Hold { get; set; }

      [Column("SHORTNAME")]
      [MaxLength(100)]
      [DefaultValue(null)]
      [GraphQLName("short_name")]
      public string? ShortName { get; set; }

      [Column("PRODUCTTYPE")]
      [MaxLength(5)]
      [DefaultValue(null)]
      [GraphQLName("product_type")]
      public string? ProductType { get; set; }

      [Column("CURRENCY")]
      [MaxLength(5)]
      [DefaultValue(null)]
      [GraphQLName("currency")]
      public string? Currency { get; set; }

      [Column("STATUS")]
      [MaxLength(1)]
      [DefaultValue(null)]
      [GraphQLName("status")]
      public string? Status { get; set; }

      [Column("OPENDAT6")]
      [MaxLength(12)]
      [DefaultValue(null)]
      [GraphQLName("open_dat_6")]
      public string? OpenDat6 { get; set; }

      [Column("OPENDAT7")]
      [MaxLength(100)]
      [DefaultValue(null)]
      [GraphQLName("open_dat_7")]
      public string? OpenDat7 { get; set; }
   }
}
