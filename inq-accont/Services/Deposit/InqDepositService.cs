using inq_accont.Models.DTO;
using inq_accont.Repositories;

namespace inq_accont.Services.Deposit
{
   public class InqDepositService : InterfaceInqDepositService
   {
      // global variable
      private readonly ABCS_M_CDMEMO_Repository _cdmemoRepo;
      private readonly ABCS_M_CDMAST_Repository _cdmastRepo;

      // create constructor
      public InqDepositService(ABCS_M_CDMEMO_Repository cdmemoRepo, ABCS_M_CDMAST_Repository cdmastRepo)
      {
         this._cdmemoRepo = cdmemoRepo;
         this._cdmastRepo = cdmastRepo;
      }

      // method to get data rekening deposit by accountnumber
      public async Task<DepositAccountResponse?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            // get data from Repository
            var findCDMEMO = _cdmemoRepo.GetByAccountNumberAsync(inputAccountNumber);
            var findCDMAST = _cdmastRepo.GetByAccountNumberAsync(inputAccountNumber);

            // wait all
            Task.WaitAll(findCDMEMO, findCDMAST);

            // cek jika ketemu di tabel cdmemo
            if (findCDMEMO.Result != null)
            {
               return new DepositAccountResponse()
               {

               };
            }

            // jika ketemu di tabel cdmast
            if (findCDMAST.Result != null)
            {
               return new DepositAccountResponse()
               {

               };
            }

            // jika not found
            return null;
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
