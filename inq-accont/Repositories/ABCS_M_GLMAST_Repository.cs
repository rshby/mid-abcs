using inq_accont.Data;
using dnet_models.Entity.Core;
using Microsoft.EntityFrameworkCore;

namespace inq_accont.Repositories
{
   public class ABCS_M_GLMAST_Repository
   {
      // global variable
      private readonly InqAccountContext _db;

      // create constructor
      public ABCS_M_GLMAST_Repository(InqAccountContext db)
      {
         this._db = db;
      }

      // method get data ABCS_M_GLMAST by accountnumber
      public async Task<List<ABCS_M_GLMAST>?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_GLMAST.AsQueryable().Where(x => x.AccountNumber == inputAccountNumber).ToListAsync<ABCS_M_GLMAST>();
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
