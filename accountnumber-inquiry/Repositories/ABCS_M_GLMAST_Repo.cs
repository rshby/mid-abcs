using accountnumber_inquiry.Data;
using accountnumber_inquiry.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace accountnumber_inquiry.Repositories
{
   public class ABCS_M_GLMAST_Repo
   {
      // global variable
      private readonly AccountNumberInquiryContext _db;

      // create constructor
      public ABCS_M_GLMAST_Repo(AccountNumberInquiryContext db)
      {
         this._db = db;
      }

      // method to get data ABCS_M_GLMAST by
      public async Task<ABCS_M_GLMAST?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_GLMAST.AsQueryable().FirstOrDefaultAsync<ABCS_M_GLMAST>(x => x.AccountNumber == inputAccountNumber);
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
