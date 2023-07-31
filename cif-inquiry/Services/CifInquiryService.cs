using cif_inquiry.Repositories;
using Inquiry.Models.Entity;

namespace cif_inquiry.Services
{
   public class CifInquiryService : ICifInquiryService
   {
      // global variable
      private readonly ABCS_M_CFMAST_Repository _cfmastRepo;

      // create constructor
      public CifInquiryService(ABCS_M_CFMAST_Repository cfmastRepo)
      {
         this._cfmastRepo = cfmastRepo;
      }

      public async Task<ABCS_M_CFMAST?> GetByCifNumAsync(string? cifnum)
      {
         try
         {
            return await _cfmastRepo.GetByCifNum(cifnum);
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
