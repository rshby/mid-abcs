using inq_accont.Data;
using dnet_models.Entity.Core;
using Microsoft.EntityFrameworkCore;

namespace inq_accont.Repositories
{
    public class ABCS_M_CDMAST_Repository
    {
        // global variable
        private readonly InqAccountContext _db;

        // create constructor
        public ABCS_M_CDMAST_Repository(InqAccountContext db)
        {
            this._db = db;
        }

        // method to get data ABCS_M_CDMAST by cifnum
        public async Task<List<ABCS_M_CDMAST>?> GetByCifNumAsync(string? inputCifNum)
        {
            try
            {
                return await _db.ABCS_M_CDMAST.AsQueryable().Where(x => x.CifNum.Equals(inputCifNum)).ToListAsync<ABCS_M_CDMAST>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

        // method to get data ABCS_M_CDMAST by accountnumber
        public async Task<List<ABCS_M_CDMAST>?> GetByAccountNumberAsync(string? inputAccountNumber)
        {
            try
            {
                return await _db.ABCS_M_CDMAST.AsQueryable().Where(x => x.AccountNumber == inputAccountNumber).Take(1).ToListAsync<ABCS_M_CDMAST>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

        // method to get data ABCS_M_CDMAST by cifnum and accountnumber
        public async Task<List<ABCS_M_CDMAST>?> GetByCifNumAndAccountNumberAsync(string? inputCifNum, string? inputAccountNumber)
        {
            try
            {
                return await _db.ABCS_M_CDMAST.AsQueryable().Where(x => x.CifNum.Equals(inputCifNum) && x.AccountNumber.Equals(inputAccountNumber)).Take(1).ToListAsync<ABCS_M_CDMAST>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }
    }
}
