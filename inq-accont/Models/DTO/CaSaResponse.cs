using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace inq_accont.Models.DTO
{
    public class CaSaResponse
    {
        [GraphQLName("account_number")]
        [DefaultValue(null)]
        public string? AccountNumber { get; set; }

        [GraphQLName("short_name")]
        [DefaultValue(null)]
        public string? ShortName { get; set; }

        [GraphQLName("minimum_balance")]
        [DefaultValue(null)]
        public double? MinimalBalance { get; set; }
    }
}
