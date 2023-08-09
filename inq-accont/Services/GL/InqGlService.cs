using inq_accont.Models.DTO;
using inq_accont.Repositories;

namespace inq_accont.Services.GL
{
   public class InqGlService : InterfaceInqGlService
   {
      // global variable
      private readonly ABCS_M_GLMEMO_Repository _glmemoRepo;
      private readonly ABCS_M_GLMAST_Repository _glmastRepo;
      private readonly ABCS_P_DDPAR2_Repository _ddpar2Repo;

      // create constructor
      public InqGlService(ABCS_M_GLMEMO_Repository glmemoRepo, ABCS_M_GLMAST_Repository glmastRepo, ABCS_P_DDPAR2_Repository ddpar2Repo)
      {
         this._glmemoRepo = glmemoRepo;
         this._glmastRepo = glmastRepo;
         this._ddpar2Repo = ddpar2Repo;
      }

      // method to get data rekening gl by accountnumber
      public async Task<List<GlAccountResponse>?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            // get data
            var findGLMEMO = _glmemoRepo.GetByAccountNumberAsync(inputAccountNumber);
            var findGLMAST = _glmastRepo.GetByAccountNumberAsync(inputAccountNumber);

            // wait all
            List<GlAccountResponse>? response = new List<GlAccountResponse>();
            Task.WaitAll(findGLMEMO, findGLMAST);

            // jika ketemu di tabel ABCS_M_GLMEMO
            if (findGLMEMO.Result != null)
            {
               response.Add(new GlAccountResponse()
               {
                  MinimumBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findGLMEMO.Result.ProductType).Result?.MinimumBalance)
               });
            }
            else
            {
               // jika ketemu di tabel ABCS_M_GLMAST
               if (findGLMAST.Result != null)
               {
                  response.Add(new GlAccountResponse()
                  {
                     MinimumBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findGLMAST.Result.ProductType).Result?.MinimumBalance)
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
