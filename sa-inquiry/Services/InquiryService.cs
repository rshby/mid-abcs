using sa_inquiry.Models.Entity;
using sa_inquiry.Repositories;
using System.Transactions;

namespace sa_inquiry.Services
{
   public class InquiryService : ISaInquiryService
   {
      // global variable
      private readonly ABCS_M_DDMAST_Repo _ddmastRepo;

      // create constructor
      public InquiryService(ABCS_M_DDMAST_Repo ddmastRepo)
      {
         this._ddmastRepo = ddmastRepo;
      }

      // method to inquiry Sa Account
      public async Task<ABCS_M_DDMAST?> InquirySaAsync(string? inputAccountNumber)
      {
         using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
         {
            try
            {
               return await _ddmastRepo.GetABCS_M_DDMASTByAccountNumberAsync(transaction, inputAccountNumber);
            }
            catch (Exception err)
            {
               transaction.Dispose();
               throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
         }
      }
   }
}
