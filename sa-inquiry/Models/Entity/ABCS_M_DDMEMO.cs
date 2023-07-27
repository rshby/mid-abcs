using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sa_inquiry.Models.Entity
{
   [GraphQLName("abcs_m_ddmemo")]
   [Table("ABCS_M_DDMEMO")]
   public class ABCS_M_DDMEMO
   {
      [Required]
      [Column("ACCOUNTNUMBER", Order = 1)]
      [StringLength(50)]
      [GraphQLName("accountnumber")]
      public string? AccountNumber { get; set; }

      [Column("ACCOUNTTYPE", Order = 2)]
      [StringLength(1)]
      [DefaultValue(null)]
      [GraphQLName("accounttype")]
      public string? AccountType { get; set; }

      [Column("CIFNUM", Order = 3)]
      [StringLength(10)]
      [DefaultValue(null)]
      [GraphQLName("cifnum")]
      public string? CifNum { get; set; }

      [Column("CBAL", Order = 4)]
      [StringLength(50)]
      [DefaultValue(null)]
      [GraphQLName("cbal")]
      public string? Cbal { get; set; }

      [Column("HOLD", Order = 5)]
      [StringLength(50)]
      [DefaultValue(null)]
      [GraphQLName("hold")]
      public string? Hold { get; set; }

      [Column("SHORTNAME", Order = 6)]
      [StringLength(100)]
      [DefaultValue(null)]
      [GraphQLName("shortname")]
      public string? ShortName { get; set; }

      [Column("PRODUCTTYPE", Order = 7)]
      [StringLength(5)]
      [DefaultValue(null)]
      [GraphQLName("producttype")]
      public string? ProductType { get; set; }

      [Column("CURRENCY", Order = 8)]
      [StringLength(5)]
      [DefaultValue(null)]
      [GraphQLName("currency")]
      public string? Currency { get; set; }

      [Column("STATUS", Order = 9)]
      [StringLength(1)]
      [DefaultValue(null)]
      [GraphQLName("status")]
      public string? Statu { get; set; }

      [Column("ACCOUNTINUSE", Order = 10)]
      [StringLength(50)]
      [DefaultValue(null)]
      [GraphQLName("accountinuse")]
      public string? AccountInUse { get; set; }

      [Column("RATE", Order = 11)]
      [StringLength(10)]
      [DefaultValue(null)]
      [GraphQLName("rate")]
      public string? Rate { get; set; }

      [Column("INTCYCLE", Order = 12)]
      [StringLength(50)]
      [DefaultValue(null)]
      [GraphQLName("intcycle")]
      public string? IntCycle { get; set; }

      [Column("SVCCYCLE", Order = 13)]
      [StringLength(50)]
      [DefaultValue(null)]
      [GraphQLName("svccycle")]
      public string? SvcCycle { get; set; }

      [Column("OPENDAT6", Order = 14)]
      [StringLength(12)]
      [DefaultValue(null)]
      [GraphQLName("opendat6")]
      public string? OpenDat6 { get; set; }

      [Column("OPENDAT7", Order = 15)]
      [StringLength(100)]
      [DefaultValue(null)]
      [GraphQLName("opendat7")]
      public string? OpenDat7 { get; set; }

      [Column("UID", Order = 16)]
      [StringLength(20)]
      [DefaultValue(null)]
      [GraphQLName("uid")]
      public string? Uid { get; set; }

      [Column("YBAL", Order = 17)]
      [StringLength(50)]
      [DefaultValue(null)]
      [GraphQLName("ybal")]
      public int MyProperty { get; set; }
   }
}
