using inq_accont.Models.DTO;
using inq_accont.Models.Entity;
using inq_accont.Repositories;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Transactions;

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

               // get data journalseq from middleware

               // joirnalseq += 1

               // entity tllog

               // update set journalseq=journalseq+=1

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

      // method untuk get rekening saving by cif
      public async Task<List<CaSaResponse>?> GetByCifNumAsync(string? inputCifNum)
      {
         using (var tr = new TransactionScope(TransactionScopeAsyncFlowOption.Suppress))
         {
            try
            {
               var findDDMEMO = _ddmemoRepo.GetByCifNumAsync(inputCifNum);
               var findDDMAST = _ddmastRepo.GetByCifNumAsync(inputCifNum);

               List<CaSaResponse>? response = new List<CaSaResponse>();
               Task.WaitAll(findDDMEMO, findDDMAST);

               // jika ketemu di ddmemo
               if (findDDMEMO.Result?.Count > 0)
               {
                  foreach (var dataDDMEMO in findDDMEMO.Result)
                  {
                     response.Add(new CaSaResponse()
                     {
                        MinimalBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(dataDDMEMO.ProductType).Result?.MinimumBalance)
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
               tr.Dispose();
               throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
         }
      }

      // method to get data rekening saving by cif and account_number
      public async Task<List<CaSaResponse>?> GetByCifNumAndAccountNumberAsync(string? inputCifNum, string? inputAccountNumber)
      {
         using (var tr = new TransactionScope(TransactionScopeAsyncFlowOption.Suppress))
         {
            try
            {
               var findDDMEMO = _ddmemoRepo.GetByCifNumAndAccountNumberAsync(inputCifNum, inputAccountNumber);
               var findDDMAST = _ddmastRepo.GetByCifNumAndAccountNumber(inputCifNum, inputAccountNumber);

               List<CaSaResponse>? response = new List<CaSaResponse>();
               Task.WaitAll(findDDMEMO, findDDMAST);

               // jika ketemu di tabel ddmemo
               if (findDDMEMO.Result != null)
               {
                  response.Add(new CaSaResponse()
                  {
                     MinimalBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findDDMEMO.Result.ProductType).Result.MinimumBalance)
                  });
               }
               else
               {
                  // jika ada di tabel ddmast
                  if (findDDMAST.Result != null)
                  {
                     response.Add(new CaSaResponse()
                     {
                        MinimalBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findDDMAST.Result.ProductType).Result.MinimumBalance)
                     });
                  }
               }

               if (response.Count > 0)
               {
                  // insert ke tabel ABCS_T_TLLOG
               }

               if (response.Count == 0) return null;

               return response;
            }
            catch (Exception err)
            {
               tr.Dispose();
               throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
         }
      }

      public Task<List<CaSaResponse>?> GetSavingByCifNumAsync(string? inputCifNum)
      {
         throw new NotImplementedException();
      }

      // method get data rekening saving by accountnumber
      public async Task<List<CaSaResponse>?> GetSavingByAccountNumber(string? inputAccountNumber)
      {
         using (var tr = new TransactionScope(TransactionScopeAsyncFlowOption.Suppress))
         {
            try
            {
               var findDDMEMO = _ddmemoRepo.GetSavingByAccountNumber(inputAccountNumber);
               var findDDMAST = _ddmastRepo.GetSavingByAccountNumber(inputAccountNumber);

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
                  // jika ada di tabel ABCS_M_DDMAST
                  if (findDDMAST.Result != null)
                  {
                     response.Add(new CaSaResponse()
                     {
                        MinimalBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findDDMAST.Result.ProductType).Result?.MinimumBalance)
                     });
                  };
               }

               if (response.Count > 0)
               {
                  // insert ke tabel ABCS_T_TLLOG
               }

               if (response.Count == 0) return null;

               return response;
            }
            catch (Exception err)
            {
               tr.Dispose();
               throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
         }
      }

      public Task<List<CaSaResponse>?> GetSavingByCifNumAndAccountNumber(string? inputCifNum, string? inputAccountNumber)
      {
         throw new NotImplementedException();
      }

      public Task<List<CaSaResponse>?> GetGiroByCifNum(string? inputCifNum)
      {
         throw new NotImplementedException();
      }

      public Task<List<CaSaResponse>?> GetGiroByAccountNumber(string? inputAccountNumber)
      {
         throw new NotImplementedException();
      }

      public Task<List<CaSaResponse>?> GetGiroByCifNumAndAccountNumber(string? inputCifNum, string? inputAccountNumber)
      {
         throw new NotImplementedException();
      }
   }
}
