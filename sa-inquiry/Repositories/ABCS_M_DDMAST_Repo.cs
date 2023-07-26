using Microsoft.EntityFrameworkCore;
using sa_inquiry.Data;
using sa_inquiry.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace sa_inquiry.Repositories
{
   public class ABCS_M_DDMAST_Repo
   {
      // global variable
      private readonly SaInquiryContext _db;

      // create constructor
      public ABCS_M_DDMAST_Repo(SaInquiryContext db)
      {
         this._db = db;
      }

      // method to get data by account_number
      public async Task<ABCS_M_DDMAST?> GetABCS_M_DDMASTByAccountNumberAsync([Required] TransactionScope tr, string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_DDMAST.AsQueryable().FirstOrDefaultAsync(x => x.AccountNumber == inputAccountNumber);
         }
         catch(Exception err)
         {
            tr.Dispose();
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
