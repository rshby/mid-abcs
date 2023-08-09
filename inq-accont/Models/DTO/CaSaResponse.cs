namespace inq_accont.Models.DTO
{
   public class CaSaResponse
   {
      [GraphQLName("minimal_balance")]
      [DefaultValue(null)]
      public double? MinimalBalance { get; set; }
   }
}
