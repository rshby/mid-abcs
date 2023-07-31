using accountnumber_inquiry.Data;
using Inquiry.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Inquiry.Repositories
{
   public class ABCS_M_DDMEMO_Repo
   {
      // global variable
      private readonly AccountNumberInquiryContext _db;

      // constructor
      public ABCS_M_DDMEMO_Repo(AccountNumberInquiryContext db)
      {
         this._db = db;
      }

      // method get data ABCS_M_DDMEMO by CIFNUM
      public async Task<List<ABCS_M_DDMEMO>?> GetByCifNumAsync(string? inputCifNum)
      {
         try
         {
            List<ABCS_M_DDMEMO>? results = await _db.ABCS_M_DDMEMO.AsQueryable().Where(x => x.CifNum == inputCifNum).ToListAsync();
            
            // jika data tidak ditemukan
            if (results == null) return null;

            return results;
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method get data ABCS_M_DDMEMO by ACCOUNTNUMBER
      public async Task<ABCS_M_DDMEMO?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_DDMEMO.AsQueryable().FirstOrDefaultAsync<ABCS_M_DDMEMO>(data => data.AccountNumber == inputAccountNumber);
         }
         catch(Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
