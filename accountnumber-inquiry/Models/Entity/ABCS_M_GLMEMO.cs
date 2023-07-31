using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accountnumber_inquiry.Models.Entity
{
   [Table("ABCS_M_GLMEMO")]
   [GraphQLName("abcs_m_glmemo")]
   public class ABCS_M_GLMEMO
   {
      [Required]
      [Column("BRANCH", Order = 1)]
      [MaxLength(50)]
      [GraphQLName("branch")]
      public string? Branch { get; set; }

      [Required]
      [Column("ACCOUNTNUMBER", Order = 2)]
      [MaxLength(50)]
      [GraphQLName("account_number")]
      public string? AccountNumber { get; set; }

      [Required]
      [Column("ACCOUNTTYPE", Order = 3)]
      [MaxLength(50)]
      [GraphQLName("account_type")]
      public string? AccountType { get; set; }

      [Required]
      [Column("CURRENCY", Order = 4)]
      [MaxLength(50)]
      [GraphQLName("currency")]
      public string? Currency { get; set; }

      [Column("CBAL", Order = 5)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("cbal")]
      public string? Cbal { get; set; }

      [Column("STATUS", Order = 6)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("status")]
      public string? Status { get; set; }

      [Column("SHORTNAME", Order = 7)]
      [MaxLength(500)]
      [DefaultValue(null)]
      [GraphQLName("short_name")]
      public string? ShortName { get; set; }

      [Required]
      [Column("CENTER", Order = 8)]
      [MaxLength(50)]
      [GraphQLName("center")]
      public string? Center { get; set; }

      [Column("GROUPCODE", Order = 9)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("group_code")]
      public string? GroupCode { get; set; }

      [Column("YBAL", Order = 10)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("ybal")]
      public string? Ybal { get; set; }

      [Column("QQNAME", Order = 11)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("qq_name")]
      public string? QqName { get; set; }

      [Column("RELATION", Order = 12)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("relation")]
      public string? Relation { get; set; }

      [Column("CIFRELATION", Order = 13)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("cif_relation")]
      public string? CifRelation { get; set; }
   }
}
