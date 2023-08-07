using inq_accont.Data;
using inq_accont.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace inq_accont.Repositories
{
   public class ABCS_M_CDMAST_Repository
   {
      // global variable
      private readonly InqAccountContext _db;

      // create constructor
      public ABCS_M_CDMAST_Repository(InqAccountContext db)
      {
         this._db = db;
      }

      // method to get data ABCS_M_CDMAST by accountnumber
      public async Task<ABCS_M_CDMAST?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_CDMAST.AsQueryable().FirstOrDefaultAsync<ABCS_M_CDMAST>(x => x.AccountNumber == inputAccountNumber);
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
