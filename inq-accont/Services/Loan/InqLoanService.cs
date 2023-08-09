using inq_accont.Models.DTO;
using inq_accont.Repositories;

namespace inq_accont.Services.Loan
{
   public class InqLoanService : InterfaceInqLoanService
   {
      // global variable
      private readonly ABCS_M_LNMEMO_Repository _lnmemoRepo;
      private readonly ABCS_M_LNMAST_Repository _lnmastRepo;
      private readonly ABCS_P_DDPAR2_Repository _ddpar2Repo;

      // create constructor
      public InqLoanService(ABCS_M_LNMEMO_Repository lnmemoRepo, ABCS_M_LNMAST_Repository lnmastRepo, ABCS_P_DDPAR2_Repository ddpar2Repo)
      {
         this._lnmemoRepo = lnmemoRepo;
         this._lnmastRepo = lnmastRepo;
         this._ddpar2Repo = ddpar2Repo;
      }

      // method to get data rekening loan by accountnumber
      public async Task<List<LoanAccountResponse>?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            var findLNMEMO = _lnmemoRepo.GetByAccountNumberAsync(inputAccountNumber);
            var findLNMAST = _lnmastRepo.GetByAccountNumberAsync(inputAccountNumber);

            // wait all
            List<LoanAccountResponse>? response = new List<LoanAccountResponse>();
            Task.WaitAll(findLNMEMO, findLNMAST);

            // jika ketemu di tabel ABCS_M_LNMEMO
            if (findLNMEMO.Result != null)
            {
               response.Add(new LoanAccountResponse()
               {
                  MinimumBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findLNMEMO.Result.ProductType).Result?.MinimumBalance)
               });
            }
            else
            {
               // jika ketemu di tabel ABCS_M_LNMAST
               if (findLNMAST.Result != null)
               {
                  response.Add(new LoanAccountResponse()
                  {
                     MinimumBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findLNMAST.Result.ProductType).Result?.MinimumBalance)
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
