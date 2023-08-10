using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inq_accont.Models.Entity
{
    public class ABCS_M_DDMEMO
    {
        [Required]
        [Key]
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

        [Column("PRODUCTTYPE")]
        [MaxLength(5)]
        [DefaultValue(null)]
        [GraphQLName("product_type")]
        public string? ProductType { get; set; }

        [Column("SHORTNAME")]
        [MaxLength(50)]
        [DefaultValue(null)]
        [GraphQLName("short_name")]
        public string? ShortName { get; set; }
    }
}
