using inq_accont.Models.DTO;
using inq_accont.Repositories;

namespace inq_accont.Services.Loan
{
   public class InqLoanService : InterfaceInqLoanService
   {
      // global variable
      private readonly ABCS_M_LNMEMO_Repository _lnmemoRepo;
      private readonly ABCS_M_LNMAST_Repository _lnmastRepo;

      // create constructor
      public InqLoanService(ABCS_M_LNMEMO_Repository lnmemoRepo, ABCS_M_LNMAST_Repository lnmastRepo)
      {
         this._lnmemoRepo = lnmemoRepo;
         this._lnmastRepo = lnmastRepo;
      }

      // method to get data rekening loan by accountnumber
      public async Task<LoanAccountResponse?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            var findLNMEMO = _lnmemoRepo.GetByAccountNumberAsync(inputAccountNumber);
            var findLNMAST = _lnmastRepo.GetByAccountNumberAsync(inputAccountNumber);

            // wait all
            Task.WaitAll(findLNMEMO, findLNMAST);

            // jika ketemu di tabel ABCS_M_LNMEMO
            if (findLNMEMO.Result != null)
            {
               return new LoanAccountResponse(){

               };
            }

            // jika ketemu di tabel ABCS_M_LNMAST
            if (findLNMAST.Result != null)
            {
               return new LoanAccountResponse()
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
