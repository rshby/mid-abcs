using inq_cif.Models;
using inq_cif.Repositories;

namespace inq_cif.Services
{
   public class InqCifService : InterfaceInqCifService
   {
      // global variable
      private readonly ABCS_M_CFMAST_Repository _cfmastRepo;

      // create constructor
      public InqCifService(ABCS_M_CFMAST_Repository cfmastRepo)
      {
         this._cfmastRepo = cfmastRepo;
      }

      // method to get data ABCS_M_CFMAST by cifnum
      public async Task<ABCS_M_CFMAST?> GetByCifNumAsync(string? inputCifNum)
      {
         try
         {
            return await _cfmastRepo.GetByCifNumAsync(inputCifNum);
         }
         catch(Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
