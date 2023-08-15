using dnet_models.Entity.Core;
using inq_accont.Data;
using entityLocal = inq_accont.Models.Entity.CoreEntity;

namespace inq_accont.Repositories
{
    public class ABCS_T_TLLOG_Repository
    {
        // global variable
        private readonly InqAccountContext _db;

        // create constructor
        public ABCS_T_TLLOG_Repository(InqAccountContext db, BRINJOURNALSEQ_Repository brijournalRepo)
        {
            this._db = db;
            //this._brinjournalRepo = brijournalRepo;
        }

        // method untuk insert ke table ABCS_T_TLLOG
        public async Task<entityLocal.ABCS_T_TLLOG?> InsertData(entityLocal.ABCS_T_TLLOG? newData)
        {
            try
            {
                _db.ABCS_T_TLLOG.Add(newData);
                _db.SaveChanges();
                return newData;
            }
            catch(Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }
    }
}
