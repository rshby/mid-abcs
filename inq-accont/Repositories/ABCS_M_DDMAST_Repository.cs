using inq_accont.Data;
using Microsoft.EntityFrameworkCore;
using dnet_models.Entity.Core;

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

        // method to get data rekening saving by cifnum
        public async Task<List<ABCS_M_DDMAST>?> GetSavingByCifNumAsync(string? inputCifNum)
        {
            try
            {
                return await _db.ABCS_M_DDMAST.AsQueryable().Where(x => x.AccountType.Equals("S") && x.CifNum.Equals(inputCifNum)).ToListAsync<ABCS_M_DDMAST>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

        // method get data rekening saving by accountnumber
        public async Task<List<ABCS_M_DDMAST>?> GetSavingByAccountNumber(string? inputAccountNumber)
        {
            try
            {
                return await _db.ABCS_M_DDMAST.AsQueryable().Where(x => x.AccountType.Equals("S") && x.AccountNumber.Equals(inputAccountNumber)).Take(1).ToListAsync<ABCS_M_DDMAST>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

        // method get data rekening saving by cifnum and accountnumber
        public async Task<List<ABCS_M_DDMAST>?> GetSavingByCifNumAndAccountNumberAsync(string? inputCifNum, string? inputAccountNumber)
        {
            try
            {
                return await _db.ABCS_M_DDMAST.AsQueryable().Where(x => x.AccountType.Equals("S") && x.CifNum.Equals(inputCifNum) && x.AccountNumber.Equals(inputAccountNumber)).Take(1).ToListAsync<ABCS_M_DDMAST>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

        // method get rekening giro by cifnum
        public async Task<List<ABCS_M_DDMAST>?> GetGiroByCifNumAsync(string? inputCifNum)
        {
            try
            {
                return await _db.ABCS_M_DDMAST.AsQueryable().Where(x => x.AccountType.Equals("D") && x.CifNum.Equals(inputCifNum)).ToListAsync<ABCS_M_DDMAST>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

        // method get data rekening giro by accountnumber
        public async Task<List<ABCS_M_DDMAST>?> GetGiroByAccountNumber(string? inputAccountNumber)
        {
            try
            {
                return await _db.ABCS_M_DDMAST.AsQueryable().Where(x => x.AccountType.Equals("D") && x.AccountNumber.Equals(inputAccountNumber)).Take(1).ToListAsync<ABCS_M_DDMAST>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

        // method get data rekening giro by cifnum and accountnumber
        public async Task<List<ABCS_M_DDMAST>?> GetGiroByCifNumAndAccountNumberAsync(string? inputCifNum, string? inputAccountNumber)
        {
            try
            {
                return await _db.ABCS_M_DDMAST.AsQueryable().Where(x => x.AccountType.Equals("D") && x.CifNum.Equals(inputCifNum) && x.AccountNumber.Equals(inputAccountNumber)).Take(1).ToListAsync<ABCS_M_DDMAST>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }
    }
}
