using cif_inquiry.Data;
using Inquiry.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace cif_inquiry.Repositories
{
   public class ABCS_M_CFMAST_Repository
   {
      // global variable
      private readonly CifInquiryContext _db;

      // create constructor
      public ABCS_M_CFMAST_Repository(CifInquiryContext db)
      {
         this._db = db;
      }

      // metho to get data cif by cifnum
      public async Task<ABCS_M_CFMAST?> GetByCifNum([Required] string? cifNum)
      {
         try
         {
            return await _db.ABCS_M_CFMAST.AsQueryable().FirstOrDefaultAsync<ABCS_M_CFMAST>(x => x.CifNum == cifNum);
         }
         catch(Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
