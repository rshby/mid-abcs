namespace inq_accont.Models.DTO
{
   public class GlAccountResponse
   {
      [GraphQLName("minimum_balance")]
      [DefaultValue(null)]
      public double? MinimumBalance { get; set; }
   }
}
