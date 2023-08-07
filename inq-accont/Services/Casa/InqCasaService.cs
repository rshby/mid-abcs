using inq_accont.Models.DTO;
using inq_accont.Models.Entity;
using inq_accont.Repositories;

namespace inq_accont.Services.Casa
{
   public class InqCasaService : InterfaceInqCasaService
   {
      // global variable
      private readonly ABCS_M_DDMEMO_Repository _ddmemoRepo;
      private readonly ABCS_M_DDMAST_Repository _ddmastRepo;

      // create constructor
      public InqCasaService(ABCS_M_DDMEMO_Repository ddmemoRepo, ABCS_M_DDMAST_Repository ddmastRepo)
      {
         this._ddmemoRepo = ddmemoRepo;
         this._ddmastRepo = ddmastRepo;
      }

      // method untuk get data rekeing casa by accountnumber
      public async Task<CaSaResponse?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            // cek ke data ddmemo
            var findDDMEMO = _ddmemoRepo.GetByAccountNumberAsync(inputAccountNumber);
            var findDDMAST = _ddmastRepo.GetByAccountNumberAsync(inputAccountNumber);

            // wait all task
            Task.WaitAll(findDDMEMO, findDDMAST);  

            // jika ketemu di tabel ddmemo
            if (findDDMEMO.Result != null)
            {
               return new CaSaResponse()
               {

               };
            }

            // jika ketemu di tabel ddmast
            if (findDDMAST.Result != null)
            {
               return new CaSaResponse()
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
