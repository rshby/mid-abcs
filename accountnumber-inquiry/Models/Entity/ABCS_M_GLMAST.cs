using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accountnumber_inquiry.Models.Entity
{
   [Table("ABCS_M_GLMAST")]
   [GraphQLName("abcs_m_glmast")]
   public class ABCS_M_GLMAST
   {
      [Required]
      [Column("BRANCH")]
      [MaxLength(50)]
      [GraphQLName("branch")]
      public string? Branch { get; set; }

      [Required]
      [Column("ACCOUNTNUMBER")]
      [MaxLength(50)]
      [GraphQLName("account_number")]
      public string? AccountNumber { get; set; }

      [Required]
      [Column("ACCOUNTTYPE")]
      [MaxLength(50)]
      [GraphQLName("account_type")]
      public string? AccountType { get; set; }

      [Required]
      [Column("CURRENCY")]
      [MaxLength(50)]
      [GraphQLName("currency")]
      public string? Currency { get; set; }

      [Column("CBAL")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("cbal")]
      public string? Cbal { get; set; }

      [Column("STATUS")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("status")]
      public string? Status { get; set; }

      [Column("SHORTNAME")]
      [MaxLength(500)]
      [DefaultValue(null)]
      [GraphQLName("short_name")]
      public string? ShortName { get; set; }

      [Required]
      [Column("CENTER")]
      [MaxLength(50)]
      [GraphQLName("center")]
      public string? Center { get; set; }

      [Column("YBAL")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("ybal")]
      public string? Ybal { get; set; }

      [Column("QQNAME")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("qq_name")]
      public string? QqName { get; set; }

      [Column("RELATION")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("relation")]
      public string? Relation { get; set; }

      [Column("CIFRELATION")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("cif_relation")]
      public string? CifRelation { get; set; }

      [Column("BOOKINGRATE")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("booking_rate")]
      public string? BookingRate { get; set; }

      [Column("AMOUNTEQUIVALENCE")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("amount_equivalence")]
      public string? AmountEquivalence { get; set; }

      [Column("YBOOKINGRATE")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("y_booking_rate")]
      public string? YBookingRate { get; set; }

      [Column("YAMOUNTEQUIVALENCE")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("y_amount_equivalence")]
      public string? YAmountEquivalence { get; set; }
   }
}
