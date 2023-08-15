using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace inq_accont.Models.Entity.CoreEntity
{
    [Table("ABCS_T_TLLOG")]
    [GraphQLName("ABCS_T_TLLOG")]
    public class ABCS_T_TLLOG
    {
        [Column("WORKSTATIONID")]
        [MaxLength(50)]
        [DefaultValue(null)]
        [GraphQLName("workstationid")]
        public string? WorkStationId { get; set; }

        [Required]
        [Column("TELLERID")]
        [MaxLength(50)]
        [GraphQLName("teller_id")]
        public string? TellerId { get; set; }

        [Column("TRANSACTIONCODE")]
        [MaxLength(50)]
        [DefaultValue(null)]
        [GraphQLName("transaction_code")]
        public string? TransactionCode { get; set; }

        [Column("TRANSACTIONDATE")]
        [MaxLength(50)]
        [DefaultValue(null)]
        [GraphQLName("transaction_date")]
        public string? TransactionDate { get; set; }

        [Required]
        [Column("JOURNALSEQ")]
        [MaxLength(50)]
        [GraphQLName("journal_seq")]
        public string? JournalSeq { get; set; }

        [Column("DEFAULTCURRENCY")]
        [MaxLength(50)]
        [DefaultValue(null)]
        [GraphQLName("default_currency")]
        public string? DefaultCurrency { get; set; }

        [Column("CURRENCY1")]
        [MaxLength(50)]
        [DefaultValue(null)]
        [GraphQLName("currency1")]
        public string? Currency1 { get; set; }

        [Column("BRANCH1")]
        [MaxLength(50)]
        [DefaultValue(null)]
        [GraphQLName("branch1")]
        public string? Branch1 { get; set; }

        [Column("ERRORCODE")]
        [MaxLength(50)]
        [DefaultValue(null)]
        [GraphQLName("error_code")]
        public string? ErrorCode { get; set; }

        [Required]
        [Column("EFFECTIVEDATE")]
        [MaxLength(50)]
        [GraphQLName("effective_date")]
        public string? EffectiveDate { get; set; }

        [Column("EFFDATE7")]
        [MaxLength(50)]
        [DefaultValue(null)]
        [GraphQLName("effdate7")]
        public string? EffDate7 { get; set; }

        [Column("TXTIME")]
        [MaxLength(50)]
        [DefaultValue(null)]
        [GraphQLName("txtime")]
        public string? TxTime { get; set; }

        [Key]
        [Required]
        [Column("TRREFN")]
        [MaxLength(50)]
        [GraphQLName("trrefn")]
        public string? Trrefn { get; set; }
    }
}
