using accountnumber_inquiry.Models.DTO;
using accountnumber_inquiry.Repositories;
using Inquiry.Repositories;
using System.Diagnostics;

namespace accountnumber_inquiry.Services
{
   public class AccountNumberInquiryService : IAccountNumberInquiryService
   {
      // global variable
      private readonly ABCS_M_CDMAST_Repo _cdmastRepo;
      private readonly ABCS_M_CDMEMO_Repo _cdmemoRepo;
      private readonly ABCS_M_DDMAST_Repo _ddmastRepo;
      private readonly ABCS_M_DDMEMO_Repo _ddmemoRepo;
      private readonly ABCS_M_GLMAST_Repo _glmastRepo;
      private readonly ABCS_M_GLMEMO_Repo _glmemoRepo;
      private readonly ABCS_M_LNMAST_Repo _lnmastRepo;
      private readonly ABCS_M_LNMEMO_Repo _lnmemoRepo;

      // create constructor
      public AccountNumberInquiryService(ABCS_M_CDMAST_Repo cdmastRepo, ABCS_M_CDMEMO_Repo cdmemoRepo, ABCS_M_DDMAST_Repo ddmastRepo, ABCS_M_DDMEMO_Repo ddmemoRepo, ABCS_M_GLMAST_Repo glmastRepo, ABCS_M_GLMEMO_Repo glmemoRepo, ABCS_M_LNMAST_Repo lnmastRepo, ABCS_M_LNMEMO_Repo lnmemoRepo)
      {
         this._cdmastRepo = cdmastRepo;
         this._cdmemoRepo = cdmemoRepo;
         this._ddmastRepo = ddmastRepo;
         this._ddmemoRepo = ddmemoRepo;
         this._glmastRepo = glmastRepo;
         this._glmemoRepo = glmemoRepo;
         this._lnmastRepo = lnmastRepo;
         this._lnmemoRepo = lnmemoRepo;
      }

      // method to inquiry rekening by ACCOUNTNUMBER
      public async Task<InquiryAccountNumberResponse?> InquiryByAccountNumberAsync(string? inputAccountNumber)
      {
         try
         {
            var findCDMAST = _cdmastRepo.GetByAccountNumberAsync(inputAccountNumber);
            var findCDMEMO = _cdmemoRepo.GetByAccountNumberAsync(inputAccountNumber);
            var findDDMAST = _ddmastRepo.GetByAccountNumberAsync(inputAccountNumber);
            var findDDMEMO = _ddmemoRepo.GetByAccountNumberAsync(inputAccountNumber);
            var findGLMAST = _glmastRepo.GetByAccountNumberAsync(inputAccountNumber);
            var findGLMEMO = _glmemoRepo.GetByAccountNumberAsync(inputAccountNumber);
            var findLNMAST = _lnmastRepo.GetByAccountNumberAsync(inputAccountNumber);
            var findLNMEMO = _lnmemoRepo.GetByAccountNumberAsync(inputAccountNumber);

            // wait all task done
            Task.WaitAll(findCDMAST, findCDMEMO, findDDMAST, findDDMEMO, findGLMAST, findGLMEMO, findLNMAST, findLNMEMO);

            // ketemu di tabel ABCS_M_CDMAST
            if (findCDMAST.Result != null)
            {
               return new InquiryAccountNumberResponse()
               {
                  AccountNumber = findCDMAST.Result.AccountNumber,
                  AccountType = findCDMAST.Result.AccountType,
                  CifNum = findCDMAST.Result.CifNum,
                  Cbal = findCDMAST.Result.Cbal,
                  Hold = findCDMAST.Result.Hold,
                  ShortName = findCDMAST.Result.ShortName,
                  ProductType = findCDMAST.Result.ProductType,
                  Currency = findCDMAST.Result.Currency,
                  Status = findCDMAST.Result.Status,
                  OpenDat6 = findCDMAST.Result.OpenDat6,
                  OpenDat7 = findCDMAST.Result.OpenDat7,
                  Ybal = findCDMAST.Result.Ybal
               };
            }

            // ketemu di tabel ABCS_M_CDMEMO
            if (findCDMEMO.Result != null)
            {
               return new InquiryAccountNumberResponse()
               {
                  AccountNumber = findCDMEMO.Result.AccountNumber,
                  AccountType = findCDMEMO.Result.AccountType,
                  CifNum = findCDMEMO.Result.CifNum,
                  Cbal = findCDMEMO.Result.Cbal,
                  Hold = findCDMEMO.Result.Hold,
                  ShortName = findCDMEMO.Result.ShortName,
                  ProductType = findCDMEMO.Result.ProductType,
                  Currency = findCDMEMO.Result.Currency,
                  Status = findCDMEMO.Result.Status,
                  OpenDat6 = findCDMEMO.Result.OpenDat6,
                  OpenDat7 = findCDMEMO.Result.OpenDat7,
                  Ybal = findCDMEMO.Result.Ybal
               };
            }

            // jika ketemu di tabel ABCS_M_DDMAST
            if (findDDMAST.Result != null)
            {
               return new InquiryAccountNumberResponse()
               {
                  AccountNumber = findDDMAST.Result.AccountNumber,
                  AccountType = findDDMAST.Result.AccountType,
                  CifNum = findDDMAST.Result.CifNum,
                  Cbal = findDDMAST.Result.Cbal,
                  Hold = findDDMAST.Result.Hold,
                  ShortName = findDDMAST.Result.ShortName,
                  ProductType = findDDMAST.Result.ProductType,
                  Currency = findDDMAST.Result.Currency,
                  Status = findDDMAST.Result.Status,
                  OpenDat6 = findDDMAST.Result.OpenDat6,
                  OpenDat7 = findDDMAST.Result.OpenDat7,
                  Ybal = findDDMAST.Result.Ybal
               };
            }

            // jika ketemu di tabel ABCS_M_DDMEMO
            if (findDDMEMO.Result != null)
            {
               return new InquiryAccountNumberResponse()
               {
                  AccountNumber = findDDMEMO.Result.AccountNumber,
                  AccountType = findDDMEMO.Result.AccountType,
                  CifNum = findDDMEMO.Result.CifNum,
                  Cbal = findDDMEMO.Result.Cbal,
                  Hold = findDDMEMO.Result.Hold,
                  ShortName = findDDMEMO.Result.ShortName,
                  ProductType = findDDMEMO.Result.ProductType,
                  Currency = findDDMEMO.Result.Currency,
                  Status = findDDMEMO.Result.Status,
                  OpenDat6 = findDDMEMO.Result.OpenDat6,
                  OpenDat7 = findDDMEMO.Result.OpenDat7,
                  Ybal = findDDMEMO.Result.Ybal
               };
            }

            // jika ketemu di tabel ABCS_M_GLMAST
            if (findGLMAST.Result != null)
            {
               return new InquiryAccountNumberResponse()
               {
                  AccountNumber = findGLMAST.Result.AccountNumber,
                  AccountType = findGLMAST.Result.AccountType,
                  Cbal = findGLMAST.Result.Cbal,
                  ShortName = findGLMAST.Result.ShortName,
                  Currency = findGLMAST.Result.Currency,
                  Status = findGLMAST.Result.Status,
                  Ybal = findGLMAST.Result.Ybal
               };
            }

            // jika ketemu di tabel ABCS_M_GLMEMO
            if (findGLMEMO.Result != null)
            {
               return new InquiryAccountNumberResponse()
               {
                  AccountNumber = findGLMEMO.Result.AccountNumber,
                  AccountType = findGLMEMO.Result.AccountType,
                  Cbal = findGLMEMO.Result.Cbal,
                  ShortName = findGLMEMO.Result.ShortName,
                  Currency = findGLMEMO.Result.Currency,
                  Status = findGLMEMO.Result.Status,
                  Ybal = findGLMEMO.Result.Ybal
               };
            }

            // jika ketemu di tabel ABCS_M_LNMAST
            if (findLNMAST.Result != null)
            {
               return new InquiryAccountNumberResponse()
               {
                  AccountNumber = findLNMAST.Result.AccountNumber,
                  AccountType = findLNMAST.Result.AccountType,
                  CifNum = findLNMAST.Result.CifNum,
                  Cbal = findLNMAST.Result.Cbal,
                  Hold = findLNMAST.Result.Hold,
                  ShortName = findLNMAST.Result.ShortName,
                  ProductType = findLNMAST.Result.ProductType,
                  Currency = findLNMAST.Result.Currency,
                  Status = findLNMAST.Result.Status,
                  OpenDat6 = findLNMAST.Result.OpenDat6,
                  OpenDat7 = findLNMAST.Result.OpenDat7
               };
            }

            // jika ketemu di tabel ABCS_M_LNMEMO
            if (findLNMEMO.Result != null)
            {
               return new InquiryAccountNumberResponse()
               {
                  AccountNumber = findLNMEMO.Result.AccountNumber,
                  AccountType = findLNMEMO.Result.AccountType,
                  CifNum = findLNMEMO.Result.CifNum,
                  Cbal = findLNMEMO.Result.Cbal,
                  Hold = findLNMEMO.Result.Hold,
                  ShortName = findLNMEMO.Result.ShortName,
                  ProductType = findLNMEMO.Result.ProductType,
                  Currency = findLNMEMO.Result.Currency,
                  Status = findLNMEMO.Result.Status,
                  OpenDat6 = findLNMEMO.Result.OpenDat6,
                  OpenDat7 = findLNMEMO.Result.OpenDat7
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

      // method to inquiry rekening by CIFNUM
      public async Task<List<InquiryAccountNumberResponse>?> InquiryByCifNumAsync(string? inputCifNum)
      {
         try
         {
            var findDDMAST = _ddmastRepo.GetByCifNumAsync(inputCifNum);
            var findCDMAST = _cdmastRepo.GetByCifNumAsync(inputCifNum);
            var findCDMEMO = _cdmemoRepo.GetByCifNumAsync(inputCifNum);
            var findDDMEMO = _ddmemoRepo.GetByCifNumAsync(inputCifNum);
            var findLNMAST = _lnmastRepo.GetByCifNumAsync(inputCifNum);
            var findLNMEMO = _lnmemoRepo.GetByCifNumAsync(inputCifNum);

            // wait all task done
            Task.WaitAll(findDDMAST, findDDMEMO, findCDMAST, findDDMEMO, findLNMAST, findLNMEMO);

            List<InquiryAccountNumberResponse>? listRekening = new List<InquiryAccountNumberResponse>();

            // jika sudah ada di table cdmast
            if (findCDMAST?.Result?.Count > 0)
            {
               foreach (var dataCDMAST in findCDMAST.Result)
               {
                  listRekening.Add(new InquiryAccountNumberResponse()
                  {
                     AccountNumber = dataCDMAST.AccountNumber,
                     AccountType = dataCDMAST.AccountType,
                     CifNum = dataCDMAST.CifNum,
                     Cbal = dataCDMAST.Cbal,
                     Hold = dataCDMAST.Hold,
                     ShortName = dataCDMAST.ShortName,
                     ProductType = dataCDMAST.ProductType,
                     Currency = dataCDMAST.Currency,
                     Status = dataCDMAST.Status,
                     OpenDat6 = dataCDMAST.OpenDat6,
                     OpenDat7 = dataCDMAST.OpenDat7,
                     Ybal = dataCDMAST.Ybal
                  });
               }
            }

            // jika ada data di tabel cdmemo
            if (findCDMEMO?.Result?.Count > 0)
            {
               foreach (var dataCDMEMO in findCDMEMO.Result)
               {
                  listRekening.Add(new InquiryAccountNumberResponse()
                  {
                     AccountNumber = dataCDMEMO.AccountNumber,
                     AccountType = dataCDMEMO.AccountType,
                     CifNum = dataCDMEMO.CifNum,
                     Cbal = dataCDMEMO.Cbal,
                     Hold = dataCDMEMO.Hold,
                     ShortName = dataCDMEMO.ShortName,
                     ProductType = dataCDMEMO.ProductType,
                     Currency = dataCDMEMO.Currency,
                     Status = dataCDMEMO.Status,
                     OpenDat6 = dataCDMEMO.OpenDat6,
                     OpenDat7 = dataCDMEMO.OpenDat7,
                     Ybal = dataCDMEMO.Ybal
                  });
               }
            }

            // jika data sudah ketemu di ddmast
            if (findDDMAST?.Result?.Count > 0)
            {
               foreach (var dataDDMAST in findDDMAST.Result)
               {
                  listRekening.Add(new InquiryAccountNumberResponse()
                  {
                     AccountNumber = dataDDMAST.AccountNumber,
                     AccountType = dataDDMAST.AccountType,
                     CifNum = dataDDMAST.CifNum,
                     Cbal = dataDDMAST.Cbal,
                     Hold = dataDDMAST.Hold,
                     ShortName = dataDDMAST.ShortName,
                     ProductType = dataDDMAST.ProductType,
                     Currency = dataDDMAST.Currency,
                     Status = dataDDMAST.Status,
                     OpenDat6 = dataDDMAST.OpenDat6,
                     OpenDat7 = dataDDMAST.OpenDat7,
                     Ybal = dataDDMAST.Ybal
                  });
               }
            }
            
            // jika ada data di tabel ddemmo
            if (findDDMEMO?.Result?.Count > 0)
            {
               foreach (var dataDDMEMO in findDDMEMO.Result)
               {
                  listRekening.Add(new InquiryAccountNumberResponse()
                  {
                     AccountNumber = dataDDMEMO.AccountNumber,
                     AccountType = dataDDMEMO.AccountType,
                     CifNum = dataDDMEMO.CifNum,
                     Cbal = dataDDMEMO.Cbal,
                     Hold = dataDDMEMO.Hold,
                     ShortName = dataDDMEMO.ShortName,
                     ProductType = dataDDMEMO.ProductType,
                     Currency = dataDDMEMO.Currency,
                     Status = dataDDMEMO.Status,
                     OpenDat6 = dataDDMEMO.OpenDat6,
                     OpenDat7 = dataDDMEMO.OpenDat7,
                     Ybal = dataDDMEMO.Ybal
                  });
               }
            }

            // jika data ketemu di lnmast
            if (findLNMAST?.Result?.Count > 0)
            {
               foreach (var dataLNMAST in findLNMAST.Result)
               {
                  listRekening.Add(new InquiryAccountNumberResponse()
                  {
                     AccountNumber = dataLNMAST.AccountNumber,
                     AccountType = dataLNMAST.AccountType,
                     CifNum = dataLNMAST.CifNum,
                     Cbal = dataLNMAST.Cbal,
                     Hold = dataLNMAST.Hold,
                     ShortName = dataLNMAST.ShortName,
                     ProductType = dataLNMAST.ProductType,
                     Currency = dataLNMAST.Currency,
                     Status = dataLNMAST.Status,
                     OpenDat6 = dataLNMAST.OpenDat6,
                     OpenDat7 = dataLNMAST.OpenDat7
                  });
               }
            }

            // jika ketemu data di lnmemo
            if (findLNMEMO?.Result?.Count > 0)
            {
               foreach(var dataLNMEMO in findLNMEMO.Result)
               {
                  listRekening.Add(new InquiryAccountNumberResponse()
                  {
                     AccountNumber = dataLNMEMO.AccountNumber,
                     AccountType = dataLNMEMO.AccountType,
                     CifNum = dataLNMEMO.CifNum,
                     Cbal = dataLNMEMO.Cbal,
                     Hold = dataLNMEMO.Hold,
                     ShortName = dataLNMEMO.ShortName,
                     ProductType = dataLNMEMO.ProductType,
                     Currency = dataLNMEMO.Currency,
                     Status = dataLNMEMO.Status,
                     OpenDat6 = dataLNMEMO.OpenDat6,
                     OpenDat7 = dataLNMEMO.OpenDat7
                  });
               }
            }

            return (listRekening.Count == 0) ? null : listRekening;
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
