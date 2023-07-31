using accountnumber_inquiry.Data;
using accountnumber_inquiry.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace accountnumber_inquiry.Repositories
{
   public class ABCS_M_LNMEMO_Repo
   {
      // global variable
      private readonly AccountNumberInquiryContext _db;

      // constructor
      public ABCS_M_LNMEMO_Repo(AccountNumberInquiryContext db)
      {
         this._db = db;
      }

      // method to get data ABCS_M_LNMEMO by cifnum
      public async Task<List<ABCS_M_LNMEMO>?> GetByCifNumAsync(string? inputCifNum)
      {
         try
         {
            List<ABCS_M_LNMEMO>? results = await _db.ABCS_M_LNMEMO.AsQueryable().Where(x => x.CifNum == inputCifNum).ToListAsync<ABCS_M_LNMEMO>();

            // jika data tidak ditemukan
            if (results == null) return null;

            // success get data by cifnum
            return results;
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method to get data ABCS_M_LNMEMO by ACCOUNTNUMBER
      public async Task<ABCS_M_LNMEMO?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_LNMEMO.AsQueryable().FirstOrDefaultAsync<ABCS_M_LNMEMO>(x => x.AccountNumber == inputAccountNumber);
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

   }
}
