namespace inq_accont.Models.DTO
{
   public class DepositAccountResponse
   {
      [GraphQLName("minimum_balance")]
      [DefaultValue(null)]
      public double? MinimumBalance { get; set; }
   }
}
