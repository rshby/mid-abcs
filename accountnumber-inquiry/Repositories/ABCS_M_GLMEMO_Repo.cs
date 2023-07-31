using accountnumber_inquiry.Data;
using accountnumber_inquiry.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace accountnumber_inquiry.Repositories
{
   public class ABCS_M_GLMEMO_Repo
   {
      // global variable
      private readonly AccountNumberInquiryContext _db;

      // create constructor
      public ABCS_M_GLMEMO_Repo(AccountNumberInquiryContext db)
      {
         this._db = db;
      }

      // method to get data ABCS_M_GLMEMO by ACCOUNTNUMBER
      public async Task<ABCS_M_GLMEMO?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_GLMEMO.AsQueryable().FirstOrDefaultAsync<ABCS_M_GLMEMO>(x => x.AccountNumber == inputAccountNumber);
         }
         catch(Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
