using Inquiry.Data;
using Inquiry.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Inquiry.Repositories
{
   public class ABCS_M_CDMAST_Repo
   {
      // variable global
      private readonly InquiryContext _db;

      // create constructor
      public ABCS_M_CDMAST_Repo(InquiryContext db)
      {
         this._db = db;
      }

      // method untuk get data ABCS_M_CDMAST by CIFNUM
      public async Task<List<ABCS_M_CDMAST>?> GetByCifNumAsync([Required] TransactionScope transaction, string? inputCifNum)
      {
         try
         {
            List<ABCS_M_CDMAST>? results = await _db.ABCS_M_CDMAST.AsQueryable().Where(x => x.CifNum == inputCifNum).ToListAsync();
            if (results == null)
            {
               return null;
            }

            return results;
         }
         catch (Exception err)
         {
            transaction.Dispose();
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
