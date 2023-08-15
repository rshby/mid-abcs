using inq_accont.Data;
using inq_accont.Models.Entity.MiddlewareEntity;
using Microsoft.EntityFrameworkCore;

namespace inq_accont.Repositories
{
    public class BRINJOURNALSEQ_Repository
    {
        // global variable
        private readonly MiddlewareDBContext _db;

        // create constructor
        public BRINJOURNALSEQ_Repository(MiddlewareDBContext db)
        {
            this._db = db;
        }

        // get data journalseq for mobile client
        public async Task<BRINJOURNALSEQ?> GetJournalSeqMobile()
        {
            try
            {
                return _db.BRINJOURNALSEQ.AsQueryable().FirstOrDefault<BRINJOURNALSEQ>(x => x.TellerId.Equals("0999999"));
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

        // update journalseq tambah 1
        public async Task<bool?> UpdateJournalSeqMobile()
        {
            try
            {
                _db.BRINJOURNALSEQ.Where(x => x.TellerId.Equals("0999999")).ExecuteUpdate(s => s.SetProperty(x => x.JournalSeq, x => (Convert.ToInt64(x.JournalSeq) + 1).ToString()));
                var result = _db.SaveChanges();

                // jika gagal update
                if (result.Equals(0))
                {
                    return false;
                }

                return true;
            }
            catch(Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

    }
}
