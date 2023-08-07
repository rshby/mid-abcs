using inq_accont.Models.DTO;
using inq_accont.Repositories;

namespace inq_accont.Services.GL
{
   public class InqGlService : InterfaceInqGlService
   {
      // global variable
      private readonly ABCS_M_GLMEMO_Repository _glmemoRepo;
      private readonly ABCS_M_GLMAST_Repository _glmastRepo;

      // create constructor
      public InqGlService(ABCS_M_GLMEMO_Repository glmemoRepo, ABCS_M_GLMAST_Repository glmastRepo)
      {
         this._glmemoRepo = glmemoRepo;
         this._glmastRepo = glmastRepo;
      }

      // method to get data rekening gl by accountnumber
      public async Task<GlAccountResponse?> GetByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            // get data
            var findGLMEMO = _glmemoRepo.GetByAccountNumberAsync(inputAccountNumber);
            var findGLMAST = _glmastRepo.GetByAccountNumberAsync(inputAccountNumber);

            // wait all
            Task.WaitAll(findGLMEMO, findGLMAST);

            // jika ketemu di tabel ABCS_M_GLMEMO
            if (findGLMEMO.Result != null)
            {
               return new GlAccountResponse()
               {

               };
            }

            // jika ketemu di tabel ABCS_M_GLMAST
            if (findGLMAST.Result != null)
            {
               return new GlAccountResponse()
               {

               };
            }

            // not found
            return null;
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
