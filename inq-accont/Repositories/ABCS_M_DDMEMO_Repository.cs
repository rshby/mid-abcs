using inq_accont.Data;
using inq_accont.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace inq_accont.Repositories
{
   public class ABCS_M_DDMEMO_Repository
   {
      // global variable
      private readonly InqAccountContext _db;

      // create constructor
      public ABCS_M_DDMEMO_Repository(InqAccountContext db)
      {
         this._db = db;
      }

      // method to get data ABCS_M_DDMEMO by accountnumber
      public async Task<ABCS_M_DDMEMO?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_DDMEMO.AsQueryable().FirstOrDefaultAsync<ABCS_M_DDMEMO>(x => x.AccountNumber == inputAccountNumber);
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
