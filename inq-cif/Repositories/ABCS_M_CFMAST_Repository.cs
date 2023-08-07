using inq_cif.Data;
using inq_cif.Models;
using Microsoft.EntityFrameworkCore;

namespace inq_cif.Repositories
{
   public class ABCS_M_CFMAST_Repository
   {
      // global variable
      private readonly InqCifContext _db;

      // create constructor
      public ABCS_M_CFMAST_Repository(InqCifContext db)
      {
         this._db = db;
      }

      // method to get data ABCS_M_CFMAST by cifnum
      public async Task<ABCS_M_CFMAST?> GetByCifNumAsync(string? inputCifNum)
      {
         try
         {
            return await _db.ABCS_M_CFMAST.AsQueryable().FirstOrDefaultAsync<ABCS_M_CFMAST>(x => x.CifNum == inputCifNum);
         }
         catch(Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
