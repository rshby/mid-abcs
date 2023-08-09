using inq_accont.Data;
using inq_accont.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace inq_accont.Repositories
{
   public class ABCS_M_DDMEMO_Repository
   {
      // global variable
      private readonly InqAccountContext _db;

      // create constructor
      public ABCS_M_DDMEMO_Repository(InqAccountContext db)
      {
         this._db = db;
      }

      // method to get data ABCS_M_DDMEMO by accountnumber
      public async Task<ABCS_M_DDMEMO?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_DDMEMO.AsQueryable().FirstOrDefaultAsync<ABCS_M_DDMEMO>(x => x.AccountNumber == inputAccountNumber);
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method to get data abcs_m_ddmemo by cifnum
      public async Task<List<ABCS_M_DDMEMO>?> GetByCifNumAsync(string? inputCifNum)
      {
         try
         {
            return await _db.ABCS_M_DDMEMO.AsQueryable().Where(x => x.CifNum.Equals(inputCifNum)).ToListAsync<ABCS_M_DDMEMO>();
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method get data ABCS_M_DDMEMO by cifnum and accountnumber
      public async Task<ABCS_M_DDMEMO?> GetByCifNumAndAccountNumberAsync(string? inputCifNum, string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_DDMEMO.AsQueryable().FirstOrDefaultAsync<ABCS_M_DDMEMO>(x => x.CifNum.Equals(inputCifNum) && x.AccountNumber.Equals(inputAccountNumber));
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // methood get data rekening saving by cifnum
      public async Task<List<ABCS_M_DDMEMO>?> GetSavingByCifNumAsync(string? inputCifNum)
      {
         try
         {
            return await _db.ABCS_M_DDMEMO.AsQueryable().Where(x => x.ProductType.Equals("S") && x.CifNum.Equals(inputCifNum)).ToListAsync<ABCS_M_DDMEMO>();
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method get data rekening saving by cifnum and accountnumber
      public async Task<ABCS_M_DDMEMO?> GetSavingByCifNumAndAccountNumberAsync(string? inputCifNum, string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_DDMEMO.AsQueryable().FirstOrDefaultAsync<ABCS_M_DDMEMO>(x => x.ProductType.Equals("S") && x.CifNum.Equals(inputCifNum) && x.AccountNumber.Equals(inputAccountNumber));
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method get data rekening saving by accountnumber
      public async Task<ABCS_M_DDMEMO?> GetSavingByAccountNumber(string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_DDMEMO.AsQueryable().FirstOrDefaultAsync<ABCS_M_DDMEMO>(x => x.AccountType.Equals("S") && x.AccountNumber.Equals(inputAccountNumber));
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method get data rekening giro by accountnumber
      public async Task<ABCS_M_DDMEMO?> GetGiroByAccountNumber(string? inputAccountNumber)
      {
         try
         {
            return await _db.ABCS_M_DDMEMO.AsQueryable().FirstOrDefaultAsync<ABCS_M_DDMEMO>(x => x.ProductType.Equals("D") && x.AccountNumber.Equals(inputAccountNumber));
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
