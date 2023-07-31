﻿using accountnumber_inquiry.Data;
using Inquiry.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Inquiry.Repositories
{
   public class ABCS_M_DDMAST_Repo
   {
      // global variable
      private readonly AccountNumberInquiryContext _db;

      // create constructor
      public ABCS_M_DDMAST_Repo(AccountNumberInquiryContext db)
      {
         this._db = db;
      }

      // method to get data ABCS_M_DDMAST by CIFNUM
      public async Task<List<ABCS_M_DDMAST>?> GetByCifNumAsync(string? inputCifNum)
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
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method to get data ABCS_M_CDMAST by ACCOUNTNUMBER
      public async Task<ABCS_M_DDMAST?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_DDMAST.AsQueryable().FirstOrDefaultAsync(data => data.AccountNumber == inputAccountNumber);
         }
         catch(Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
