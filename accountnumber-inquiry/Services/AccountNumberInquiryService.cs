using accountnumber_inquiry.Models.DTO;
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

      // create constructor
      public AccountNumberInquiryService(ABCS_M_CDMAST_Repo cdmastRepo, ABCS_M_CDMEMO_Repo cdmemoRepo, ABCS_M_DDMAST_Repo ddmastRepo, ABCS_M_DDMEMO_Repo ddmemoRepo)
      {
         this._cdmastRepo = cdmastRepo;
         this._cdmemoRepo = cdmemoRepo;
         this._ddmastRepo = ddmastRepo;
         this._ddmemoRepo = ddmemoRepo;
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

            // wait all task done
            Task.WaitAll(findCDMAST, findCDMEMO, findDDMAST, findDDMEMO);

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

            // wait all task done
            Task.WaitAll(findDDMAST, findDDMEMO, findCDMAST, findDDMEMO);

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
            else
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
            else
            {
               // jika adanya di DDMEMO
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

            return (listRekening.Count == 0) ? null : listRekening;
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
