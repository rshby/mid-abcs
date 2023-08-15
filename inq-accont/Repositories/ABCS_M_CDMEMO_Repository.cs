using inq_accont.Data;
using dnet_models.Entity.Core;
using Microsoft.EntityFrameworkCore;

namespace inq_accont.Repositories
{
    public class ABCS_M_CDMEMO_Repository
    {
        // global variable
        private readonly InqAccountContext _db;

        // create constructor
        public ABCS_M_CDMEMO_Repository(InqAccountContext db)
        {
            this._db = db;
        }

        // method get data by cifnum
        public async Task<List<ABCS_M_CDMEMO>?> GetByCifNum(string? inputCifNum)
        {
            try
            {
                return await _db.ABCS_M_CDMEMO.AsQueryable().Where(x => x.CifNum.Equals(inputCifNum)).ToListAsync<ABCS_M_CDMEMO>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

        // method to get data by accountnumber
        public async Task<List<ABCS_M_CDMEMO>?> GetByAccountNumberAsync(string? inputAccountNumber)
        {
            try
            {
                return await _db.ABCS_M_CDMEMO.AsQueryable().Where(x => x.AccountNumber == inputAccountNumber).Take(1).ToListAsync<ABCS_M_CDMEMO>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

        // method to get data by cifnum and accountnumber
        public async Task<List<ABCS_M_CDMEMO>?> GetByCifNumAndAccountNumberAsync(string? inputCifNum, string? inputAccountNumber)
        {
            try
            {
                return await _db.ABCS_M_CDMEMO.AsQueryable().Where(x => x.CifNum.Equals(inputCifNum) && x.AccountNumber.Equals(inputAccountNumber)).Take(1).ToListAsync<ABCS_M_CDMEMO>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }
    }
}
