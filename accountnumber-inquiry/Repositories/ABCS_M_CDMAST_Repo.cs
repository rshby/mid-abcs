using accountnumber_inquiry.Data;
using Inquiry.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Inquiry.Repositories
{
   public class ABCS_M_CDMAST_Repo
   {
      // variable global
      private readonly AccountNumberInquiryContext _db;

      // create constructor
      public ABCS_M_CDMAST_Repo(AccountNumberInquiryContext db)
      {
         this._db = db;
      }

      // method untuk get data ABCS_M_CDMAST by CIFNUM
      public async Task<List<ABCS_M_CDMAST>?> GetByCifNumAsync(string? inputCifNum)
      {
         try
         {
            List<ABCS_M_CDMAST>? results = await _db.ABCS_M_CDMAST.AsQueryable().Where(x => x.CifNum == inputCifNum).ToListAsync();
            
            // jika tidak ada datanya
            if (results == null)
            {
               return null;
            }

            return results;
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method untuk get data ABCS_M_CDMAST by ACCOUNTNUMBER
      public async Task<ABCS_M_CDMAST?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_CDMAST.AsQueryable().FirstOrDefaultAsync<ABCS_M_CDMAST>(data => data.AccountNumber == inputAccountNumber);
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
