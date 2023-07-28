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
         using (var tr = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
         {
            try
            {
               List<Task>? listTask = new List<Task>();

               var findCFMAST = new ABCS_M_CFMAST();
               Task? taskGetCFMAST = Task.Run(() =>
               {
                  findCFMAST = _cfmastRepo.GetByCifNumAsync(tr, inputCifNum).Result;
               });
               listTask.Add(taskGetCFMAST);

               var findDDMAST = new List<ABCS_M_DDMAST>();
               Task? taskGetDDMAST = Task.Run(() =>
               {
                  findDDMAST = _ddmastRepo.GetByCifNumAsync(tr, inputCifNum).Result;
               });
               listTask.Add(taskGetDDMAST);

               var findDDMEMO = new List<ABCS_M_DDMEMO>();
               Task? taskGetDDMEMO = Task.Run(() =>
               {
                  findDDMEMO = _ddmemoRepo.GetByCifNumAsync(tr, inputCifNum).Result;
               });
               listTask.Add(taskGetDDMEMO);

               var findCDMAST = new List<ABCS_M_CDMAST>();
               Task? taskGetCDMAST = Task.Run(() =>
               {
                  findCDMAST = _cdmastRepo.GetByCifNumAsync(tr, inputCifNum).Result;
               });
               listTask.Add(taskGetCDMAST);

               var findCDMEMO = new List<ABCS_M_CDMEMO>();
               Task? taskGetCDMEMO = Task.Run(() =>
               {
                  findCDMEMO = _cdmemoRepo.GetByCifNumAsync(tr, inputCifNum).Result;
               });
               listTask.Add(taskGetCDMEMO);

               // wait all task done
               await Task.WhenAll(listTask);

               if (findCFMAST == null)
               {
                  tr.Dispose();
                  return null;
               }

               // proses get list of rekening
               List<DataRekeningResponse>? listRekening = new List<DataRekeningResponse>();
               Task? taskGetRekeningSA = Task.Run(() =>
               {
                  // jika data sudah ketemu di ddmast
                  if (findDDMAST.Count > 0)
                  {
                     foreach (var dataDDMAST in findDDMAST)
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
                     return;
                  }

                  // jika adanya di DDMEMO
                  foreach (var dataDDMEMO in findDDMEMO)
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
               });

               Task? taskGetRekeningCA = Task.Run(() =>
               {
                  // jika sudah ada di table cdmast
                  if (findCDMAST.Count > 0)
                  {
                     foreach (var dataCDMAST in findCDMAST)
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
                     return;
                  }

                  foreach(var dataCDMEMO in findCDMEMO)
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
               });

               // wait all task done
               Task.WaitAll(taskGetRekeningSA, taskGetRekeningCA);

               // create response
               var response = new DataCifResponse()
               {
                  CifNum = findCFMAST.CifNum,
                  BranchNo = findCFMAST.BranchNo,
                  NamaCetakan = findCFMAST?.NamaCetakan,
                  Negara = findCFMAST?.Negara,
                  FederalWhCode = findCFMAST?.FederalWhCode,
                  NoId = findCFMAST?.NoId,
                  Npwp = findCFMAST?.Npwp,
                  NamaSesuaiId = findCFMAST?.NamaSesuaiId,
                  NamaLengkap = findCFMAST?.NamaLengkap,
                  JenisKelamin = findCFMAST?.JenisKelamin,
                  Kewarganegaraan = findCFMAST?.Kewarganegaraan,
                  TempatLahir = findCFMAST?.TempatLahir,
                  TanggalLahir = findCFMAST?.TanggalLahir,
                  JenisKartuIdentitas = findCFMAST?.JenisKartuIdentitas,
                  Agama = findCFMAST?.Agama,
                  AlamatId1 = findCFMAST?.AlamatId1,
                  KelurahanId = findCFMAST?.KelurahanId,
                  KecamatanId = findCFMAST?.KecamatanId,
                  KotaId = findCFMAST?.KotaId,
                  PropinsiId = findCFMAST?.PropinsiId,
                  NoHp = findCFMAST?.NoHp,
                  Rekening = (listRekening.Count == 0) ? null : listRekening
               };

               tr.Complete();
               return response;
            }
            catch (Exception err)
            {
               tr.Dispose();
               throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
         }
      }
   }
}
