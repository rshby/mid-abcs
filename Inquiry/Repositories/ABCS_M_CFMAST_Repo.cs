using Inquiry.Data;
using Inquiry.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Inquiry.Repositories
{
   public class ABCS_M_CFMAST_Repo
   {
      // global variable
      private readonly InquiryContext _db;

      // create constructor
      public ABCS_M_CFMAST_Repo(InquiryContext db)
      {
         this._db = db;
      }

      // method to get data abcs_m_cfmast by cifnum
      public async Task<ABCS_M_CFMAST?> GetByCifNumAsync([Required] TransactionScope? transaction, string? inputCifNum)
      {
         try
         {
            return await _db.ABCS_M_CFMAST.AsQueryable().FirstOrDefaultAsync(x => x.CifNum == inputCifNum);
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage($"{err.Message}. inner exception : {err.InnerException?.Message}").Build());
         }
      }
   }
}
