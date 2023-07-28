using Inquiry.Models.DTO;
using Inquiry.Models.Entity;
using Inquiry.Repositories;
using System.Transactions;

namespace Inquiry.Services
{
   public class InquiryService : InterfaceInquiryService
   {
      // global variable
      private readonly ABCS_M_CFMAST_Repo _cfmastRepo;
      private readonly ABCS_M_DDMAST_Repo _ddmastRepo;
      private readonly ABCS_M_DDMEMO_Repo _ddmemoRepo;
      private readonly ABCS_M_CDMAST_Repo _cdmastRepo;
      private readonly ABCS_M_CDMEMO_Repo _cdmemoRepo;

      // create constructor
      public InquiryService(ABCS_M_CFMAST_Repo cfmastRepo, ABCS_M_DDMAST_Repo ddmastRepo, ABCS_M_DDMEMO_Repo ddmemoRepo, ABCS_M_CDMAST_Repo cdmastRepo, ABCS_M_CDMEMO_Repo cdmemoRepo)
      {
         this._cfmastRepo = cfmastRepo;
         this._ddmastRepo = ddmastRepo;
         this._ddmemoRepo = ddmemoRepo;
         this._cdmastRepo = cdmastRepo;
         this._cdmemoRepo = cdmemoRepo;
      }

      // method inquiry
      public async Task<DataCifResponse?> InquiryAsync(string? inputCifNum)
      {
         try
         {
            var findCFMAST = _cfmastRepo.GetByCifNumAsync(null, inputCifNum);
            var findDDMAST = _ddmastRepo.GetByCifNumAsync(null, inputCifNum);
            var findCDMAST = _cdmastRepo.GetByCifNumAsync(null, inputCifNum);
            var findCDMEMO = _cdmemoRepo.GetByCifNumAsync(null, inputCifNum);
            var findDDMEMO = _ddmemoRepo.GetByCifNumAsync(null, inputCifNum);

            // wait all task done
            Task.WaitAll(findCFMAST, findDDMAST, findDDMEMO, findCDMAST, findDDMEMO);

            if (findCFMAST.Result == null)
            {
               return null;
            }

            // proses get list of rekening
            List<DataRekeningResponse>? listRekening = new List<DataRekeningResponse>();

            // jika data sudah ketemu di ddmast
            if (findDDMAST?.Result?.Count > 0)
            {
               foreach (var dataDDMAST in findDDMAST.Result)
               {
                  listRekening.Add(new DataRekeningResponse()
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
                  listRekening.Add(new DataRekeningResponse()
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

            // jika sudah ada di table cdmast
            if (findCDMAST?.Result?.Count > 0)
            {
               foreach (var dataCDMAST in findCDMAST.Result)
               {
                  // add to list of rekening
                  listRekening.Add(new DataRekeningResponse()
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
                  listRekening.Add(new DataRekeningResponse()
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

            // create response
            return new DataCifResponse()
            {
               CifNum = findCFMAST.Result.CifNum,
               BranchNo = findCFMAST.Result.BranchNo,
               NamaCetakan = findCFMAST?.Result.NamaCetakan,
               Negara = findCFMAST?.Result.Negara,
               FederalWhCode = findCFMAST?.Result.FederalWhCode,
               NoId = findCFMAST?.Result.NoId,
               Npwp = findCFMAST?.Result.Npwp,
               NamaSesuaiId = findCFMAST?.Result.NamaSesuaiId,
               NamaLengkap = findCFMAST?.Result.NamaLengkap,
               JenisKelamin = findCFMAST?.Result.JenisKelamin,
               Kewarganegaraan = findCFMAST?.Result.Kewarganegaraan,
               TempatLahir = findCFMAST?.Result.TempatLahir,
               TanggalLahir = findCFMAST?.Result.TanggalLahir,
               JenisKartuIdentitas = findCFMAST?.Result.JenisKartuIdentitas,
               Agama = findCFMAST?.Result.Agama,
               AlamatId1 = findCFMAST?.Result.AlamatId1,
               KelurahanId = findCFMAST?.Result.KelurahanId,
               KecamatanId = findCFMAST?.Result.KecamatanId,
               KotaId = findCFMAST?.Result.KotaId,
               PropinsiId = findCFMAST?.Result.PropinsiId,
               NoHp = findCFMAST?.Result.NoHp,
               Rekening = (listRekening.Count == 0) ? null : listRekening
            };
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
