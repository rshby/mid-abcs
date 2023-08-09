﻿using inq_accont.Data;
using inq_accont.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace inq_accont.Repositories
{
   public class ABCS_M_DDMAST_Repository
   {
      // global variable
      private readonly InqAccountContext _db;

      // create constructor
      public ABCS_M_DDMAST_Repository(InqAccountContext db)
      {
         this._db = db;
      }

      // method to get data ABCS_M_DDMAST by accountnumber
      public async Task<ABCS_M_DDMAST?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_DDMAST.AsQueryable().FirstOrDefaultAsync<ABCS_M_DDMAST>(x => x.AccountNumber == inputAccountNumber);
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method to get data ABCS_M_DDMAST by cifnum
      public async Task<List<ABCS_M_DDMAST>?> GetByCifNumAsync(string? inputCifNum)
      {
         try
         {
            return await _db.ABCS_M_DDMAST.AsQueryable().Where(x => x.CifNum.Equals(inputCifNum)).ToListAsync<ABCS_M_DDMAST>();
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method to get data ABCS_M_DDMAST by cifnum and accountnumber
      public async Task<ABCS_M_DDMAST?> GetByCifNumAndAccountNumber(string? inputCifNum, string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_DDMAST.AsQueryable().FirstOrDefaultAsync<ABCS_M_DDMAST>(x => x.CifNum.Equals(inputCifNum) && x.AccountNumber.Equals(inputAccountNumber));
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}