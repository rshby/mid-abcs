using inq_accont.Data;
using inq_accont.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace inq_accont.Repositories
{
   public class ABCS_P_DDPAR2_Repository
   {
      // global variable
      private readonly InqAccountContext _db;

      // create constructor
      public ABCS_P_DDPAR2_Repository(InqAccountContext db)
      {
         this._db = db;
      }

      // method to get minimum_balance by product_type
      public async Task<ABCS_P_DDPAR2?> GetByProductTypeAsync(string? inputProductType)
      {
         try
         {
            return await _db.ABCS_P_DDPAR2.AsQueryable().FirstOrDefaultAsync<ABCS_P_DDPAR2>(x => x.ProductType.Equals(inputProductType));
         }
         catch(Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
