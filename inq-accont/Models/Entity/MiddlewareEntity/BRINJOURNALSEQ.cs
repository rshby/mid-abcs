using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inq_accont.Models.Entity.MiddlewareEntity
{
    [Table("BRINJOURNALSEQ")]
    [GraphQLName("BRINJOURNALSEQ")]
    public class BRINJOURNALSEQ
    {
        [Required]
        [Column("TELLERID", Order = 1)]
        [MaxLength(50)]
        [GraphQLName("teller_id")]
        public string? TellerId { get; set; }

        [Column("JOURNALSEQ", Order = 2)]
        [MaxLength(50)]
        [DefaultValue(null)]
        [GraphQLName("journal_seq")]
        public string? JournalSeq { get; set; }
    }
}
