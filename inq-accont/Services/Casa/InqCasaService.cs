using inq_accont.Models.DTO;
using inq_accont.Models.Entity;
using inq_accont.Repositories;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace inq_accont.Services.Casa
{
   public class InqCasaService : InterfaceInqCasaService
   {
      // global variable
      private readonly ABCS_M_DDMEMO_Repository _ddmemoRepo;
      private readonly ABCS_M_DDMAST_Repository _ddmastRepo;
      private readonly ABCS_P_DDPAR2_Repository _ddpar2Repo;

      // create constructor
      public InqCasaService(ABCS_M_DDMEMO_Repository ddmemoRepo, ABCS_M_DDMAST_Repository ddmastRepo, ABCS_P_DDPAR2_Repository ddpar2Repo)
      {
         this._ddmemoRepo = ddmemoRepo;
         this._ddmastRepo = ddmastRepo;
         this._ddpar2Repo = ddpar2Repo;
      }

      // method untuk get data rekeing casa by accountnumber
      public async Task<List<CaSaResponse>?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            // cek ke data ddmemo
            var findDDMEMO = _ddmemoRepo.GetByAccountNumberAsync(inputAccountNumber);
            var findDDMAST = _ddmastRepo.GetByAccountNumberAsync(inputAccountNumber);

            // wait all task
            List<CaSaResponse>? response = new List<CaSaResponse>();
            Task.WaitAll(findDDMEMO, findDDMAST);

            // jika ketemu di tabel ddmemo
            if (findDDMEMO.Result != null)
            {
               response.Add(new CaSaResponse()
               {
                  MinimalBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findDDMEMO.Result.ProductType).Result?.MinimumBalance)
               });
            }
            else
            {
               // jika ketemu di tabel ddmast
               if (findDDMAST.Result != null)
               {
                  response.Add(new CaSaResponse()
                  {
                     MinimalBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findDDMAST.Result.ProductType).Result?.MinimumBalance)
                  });
               }
            }

            if (response.Count > 0)
            {
               // insert ke tabel ABCS_T_TLLOG
            }

            // jika not found
            if (response.Count == 0) return null;
            
            return response;
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
