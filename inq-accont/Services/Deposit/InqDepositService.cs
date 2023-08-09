using inq_accont.Models.DTO;
using inq_accont.Repositories;

namespace inq_accont.Services.Deposit
{
   public class InqDepositService : InterfaceInqDepositService
   {
      // global variable
      private readonly ABCS_M_CDMEMO_Repository _cdmemoRepo;
      private readonly ABCS_M_CDMAST_Repository _cdmastRepo;
      private readonly ABCS_P_DDPAR2_Repository _ddpar2Repo;

      // create constructor
      public InqDepositService(ABCS_M_CDMEMO_Repository cdmemoRepo, ABCS_M_CDMAST_Repository cdmastRepo, ABCS_P_DDPAR2_Repository ddpar2Repo)
      {
         this._cdmemoRepo = cdmemoRepo;
         this._cdmastRepo = cdmastRepo;
         this._ddpar2Repo = ddpar2Repo;
      }

      // method to get data rekening deposit by accountnumber
      public async Task<List<DepositAccountResponse>?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            // get data from Repository
            var findCDMEMO = _cdmemoRepo.GetByAccountNumberAsync(inputAccountNumber);
            var findCDMAST = _cdmastRepo.GetByAccountNumberAsync(inputAccountNumber);

            // wait all
            List<DepositAccountResponse>? response = new List<DepositAccountResponse>();
            Task.WaitAll(findCDMEMO, findCDMAST);

            // cek jika ketemu di tabel cdmemo
            if (findCDMEMO.Result != null)
            {
               response.Add(new DepositAccountResponse()
               {
                  MinimumBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findCDMEMO.Result.ProductType).Result?.MinimumBalance)
               });
            }
            else
            {
               // jika ketemu di tabel cdmast
               if (findCDMAST.Result != null)
               {
                  response.Add(new DepositAccountResponse()
                  {
                     MinimumBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findCDMAST.Result.ProductType).Result?.MinimumBalance)
                  });
               }
            }

            if (response.Count > 0)
            {
               // insert ke tabel ABCS_T_TLLOG
            }

            // jika not found
            if (response.Count.Equals(0)) return null;

            return response;
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
