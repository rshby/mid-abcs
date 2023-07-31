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
      public Task<List<InquiryAccountNumberResponse>?> InquiryByCifNumAsync(string? inputCifNum)
      {
         try
         {
            throw new NotImplementedException();
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
