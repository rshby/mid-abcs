namespace inq_accont.Models.DTO
{
   public class CaSaResponse
   {
      [GraphQLName("account_number")]
      [DefaultValue(null)]
      public string? AccountNumber { get; set; }

      [GraphQLName("minimal_balance")]
      [DefaultValue(null)]
      public double? MinimalBalance { get; set; }
   }
}
