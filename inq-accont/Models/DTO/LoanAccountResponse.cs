namespace inq_accont.Models.DTO
{
   public class LoanAccountResponse
   {
      [GraphQLName("minimum_balance")]
      [DefaultValue(null)]
      public double? MinimumBalance { get; set; }
   }
}
