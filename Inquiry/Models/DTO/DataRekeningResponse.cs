using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inquiry.Models.DTO
{
   [GraphQLName("rekening")]
   public class DataRekeningResponse
   {
      [GraphQLName("account_number")]
      public string? AccountNumber { get; set; }

      [DefaultValue(null)]
      [GraphQLName("account_type")]
      public string? AccountType { get; set; }

      [DefaultValue(null)]
      [GraphQLName("cif_num")]
      public string? CifNum { get; set; }

      [DefaultValue(null)]
      [GraphQLName("cbal")]
      public string? Cbal { get; set; }

      [DefaultValue(null)]
      [GraphQLName("hold")]
      public string? Hold { get; set; }

      [DefaultValue(null)]
      [GraphQLName("short_name")]
      public string? ShortName { get; set; }

      [DefaultValue(null)]
      [GraphQLName("product_type")]
      public string? ProductType { get; set; }

      [DefaultValue(null)]
      [GraphQLName("currency")]
      public string? Currency { get; set; }

      [DefaultValue(null)]
      [GraphQLName("status")]
      public string? Status { get; set; }

      [DefaultValue(null)]
      [GraphQLName("open_dat_6")]
      public string? OpenDat6 { get; set; }

      [DefaultValue(null)]
      [GraphQLName("open_dat_7")]
      public string? OpenDat7 { get; set; }

      [DefaultValue(null)]
      [GraphQLName("ybal")]
      public string? Ybal { get; set; }
   }
}
