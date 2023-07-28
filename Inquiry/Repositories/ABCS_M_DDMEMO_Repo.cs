using Inquiry.Data;
using Inquiry.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Inquiry.Repositories
{
   public class ABCS_M_DDMEMO_Repo
   {
      // global variable
      private readonly InquiryContext _db;

      // constructor
      public ABCS_M_DDMEMO_Repo(InquiryContext db)
      {
         this._db = db;
      }

      // method get data ABCS_M_DDMEMO by CIFNUM
      public async Task<List<ABCS_M_DDMEMO>?> GetByCifNumAsync([Required] TransactionScope? transaction, string? inputCifNum)
      {
         try
         {
            List<ABCS_M_DDMEMO>? results = await _db.ABCS_M_DDMEMO.AsQueryable().Where(x => x.CifNum == inputCifNum).ToListAsync();
            if (results == null) return null;

            return results;
         }
         catch (Exception err)
         {
            //transaction.Dispose();
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
