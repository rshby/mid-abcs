using Inquiry.Data;
using Inquiry.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Inquiry.Repositories
{
   public class ABCS_M_DDMAST_Repo
   {
      // global variable
      private readonly InquiryContext _db;

      // create constructor
      public ABCS_M_DDMAST_Repo(InquiryContext db)
      {
         this._db = db;
      }

      // method to get data ABCS_M_DDMAST by CIFNUM
      public async Task<List<ABCS_M_DDMAST>?> GetByCifNumAsync([Required] TransactionScope? transaction, string? inputCifNum)
      {
         try
         {
            List<ABCS_M_DDMAST>? results = await _db.ABCS_M_DDMAST.AsQueryable().Where(x => x.CifNum == inputCifNum).ToListAsync();
            if (results == null)
            {
               return null;
            }

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
