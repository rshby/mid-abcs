using dnet_models.DTO.Core;
using dnet_models.Entity.Core;
using inq_accont.Helper;
using inq_accont.Repositories;
using System.Transactions;
using entityLocal = inq_accont.Models.Entity.CoreEntity;

namespace inq_accont.Services.Deposit
{
    public class InqDepositService : InterfaceInqDepositService
    {
        // global variable
        private readonly ABCS_M_CDMEMO_Repository _cdmemoRepo;
        private readonly ABCS_M_CDMAST_Repository _cdmastRepo;
        private readonly ABCS_P_DDPAR2_Repository _ddpar2Repo;
        private readonly ABCS_T_TLLOG_Repository _tllogRepo;
        private readonly HelperJulianDate _helperJulianDate;
        private readonly BRINJOURNALSEQ_Repository _brinjournalRepo;

        // create constructor
        public InqDepositService(ABCS_M_CDMEMO_Repository cdmemoRepo, ABCS_M_CDMAST_Repository cdmastRepo, ABCS_P_DDPAR2_Repository ddpar2Repo, ABCS_T_TLLOG_Repository tllogRepo, BRINJOURNALSEQ_Repository brinjournalRepo)
        {
            this._cdmemoRepo = cdmemoRepo;
            this._cdmastRepo = cdmastRepo;
            this._ddpar2Repo = ddpar2Repo;
            this._tllogRepo = tllogRepo;
            this._helperJulianDate = new HelperJulianDate();
            this._brinjournalRepo = brinjournalRepo;
        }

        // method to get data rekening deposit
        public async Task<List<DepositAccountResponse>?> GetByCifNumAndAccountNumber(string? inputCifNum, string? inputAccountNumber)
        {
            using (var tr = new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Suppress))
            {
                try
                {
                    Task<List<ABCS_M_CDMEMO>?> findCDMEMO;
                    Task<List<ABCS_M_CDMAST>?> findCDMAST;

                    if (inputCifNum != null && inputAccountNumber == null)
                    {
                        findCDMEMO = _cdmemoRepo.GetByCifNum(inputCifNum);
                        findCDMAST = _cdmastRepo.GetByCifNumAsync(inputCifNum);
                    }
                    else if (inputCifNum == null && inputAccountNumber != null)
                    {
                        findCDMEMO = _cdmemoRepo.GetByAccountNumberAsync(inputAccountNumber);
                        findCDMAST = _cdmastRepo.GetByAccountNumberAsync(inputAccountNumber);
                    }
                    else if (inputCifNum != null && inputAccountNumber != null)
                    {
                        findCDMEMO = _cdmemoRepo.GetByCifNumAndAccountNumberAsync(inputCifNum, inputAccountNumber);
                        findCDMAST = _cdmastRepo.GetByCifNumAndAccountNumberAsync(inputCifNum, inputAccountNumber);
                    }
                    else
                    {
                        tr.Dispose();
                        throw new GraphQLException(new ErrorBuilder().SetMessage("at least one input parameter required").Build());
                    }

                    string? minimumBalance = null;
                    List<DepositAccountResponse>? response = new List<DepositAccountResponse>();
                    Task.WaitAll(findCDMEMO, findCDMAST);

                    // set minimumBalance (sekali saja)
                    if (findCDMEMO.Result?.Count > 0)
                    {
                        minimumBalance = _ddpar2Repo.GetByProductTypeAsync(findCDMEMO.Result[0].ProductType).Result?.MinimumBalance;
                    }
                    else
                    {
                        if (findCDMAST.Result?.Count > 0)
                        {
                            minimumBalance = _ddpar2Repo.GetByProductTypeAsync(findCDMAST.Result[0].ProductType).Result?.MinimumBalance;
                        }
                    }

                    if (findCDMEMO.Result?.Count > 0)
                    {
                        foreach (var dataCDMEMO in findCDMEMO.Result)
                        {
                            response.Add(new DepositAccountResponse()
                            {
                                AccountNumber = dataCDMEMO.AccountNumber,
                                AccountType = dataCDMEMO.AccountType,
                                ShortName = dataCDMEMO.ShortName,
                                CifNum = dataCDMEMO.CifNum,
                                Currency = dataCDMEMO.Currency,
                                OpenDate = dataCDMEMO.OpenDate6,
                                Hold = dataCDMEMO.Hold,
                                Cbal = dataCDMEMO.Cbal,
                                AvailableBalance = (Convert.ToDouble(dataCDMEMO.Cbal) - Convert.ToDouble(dataCDMEMO.Hold) - Convert.ToDouble(minimumBalance)).ToString("0.0000000"),
                                MinBalance = minimumBalance,
                                Status = dataCDMEMO.Status
                            });
                        }
                    }

                    if (findCDMAST.Result?.Count > 0)
                    {
                        foreach (var dataCDMAST in findCDMAST.Result)
                        {
                            if (!response.Select(x => x.AccountNumber).Contains(dataCDMAST.AccountNumber))
                            {
                                response.Add(new DepositAccountResponse()
                                {
                                    AccountNumber = dataCDMAST.AccountNumber,
                                    AccountType = dataCDMAST.AccountType,
                                    ShortName = dataCDMAST.ShortName,
                                    CifNum = dataCDMAST.CifNum,
                                    Currency = dataCDMAST.Currency,
                                    OpenDate = dataCDMAST.OpenDate6,
                                    Hold = dataCDMAST.Hold,
                                    Cbal = dataCDMAST.Cbal,
                                    AvailableBalance = (Convert.ToDouble(dataCDMAST.Cbal) - Convert.ToDouble(dataCDMAST.Hold) - Convert.ToDouble(minimumBalance)).ToString("0.0000000"),
                                    MinBalance = minimumBalance,
                                    Status = dataCDMAST.Status
                                });
                            }
                        }
                    }


                    List<Task>? taskInsertTlLog = new List<Task>();
                    ///*
                    if (response.Count > 0)
                    {
                        foreach (var dataResponse in response)
                        {
                            // insert ke tabel ABCS_T_TLLOG : buat asynchronus yaa
                            var _ = Task.Run(async () =>
                            {
                                var brinJournalSeq = await _brinjournalRepo.GetJournalSeqMobile();
                                var entityTlLog = new entityLocal.ABCS_T_TLLOG()
                                {
                                    WorkStationId = "RV",
                                    TellerId = "0999999",
                                    TransactionCode = "4000001",
                                    TransactionDate = _helperJulianDate.GetTransactionDate(),
                                    DefaultCurrency = dataResponse.Currency,
                                    Currency1 = dataResponse.Currency,
                                    Branch1 = "0999",
                                    ErrorCode = "0000",
                                    EffectiveDate = _helperJulianDate.GetTransactionDate(),
                                    EffDate7 = _helperJulianDate.GetJulianDate(),
                                    TxTime = _helperJulianDate.GetTime()
                                };

                                //Task.WaitAll(brinJournalSeq);
                                string? journalSeq = (Convert.ToInt64(brinJournalSeq?.JournalSeq) + 1).ToString();
                                entityTlLog.JournalSeq = journalSeq;
                                entityTlLog.Trrefn = entityTlLog.TellerId.PadLeft(7, '0') + entityTlLog.EffectiveDate.PadLeft(6, '0') + entityTlLog.JournalSeq.PadLeft(7, '0') + "0";

                                await _brinjournalRepo.UpdateJournalSeqMobile();
                                await _tllogRepo.InsertData(entityTlLog);
                            });
                            taskInsertTlLog.Add(_);
                        }
                    }
                    //*/

                    // jika not found
                    if (response.Count.Equals(0))
                    {
                        tr.Dispose();
                        return null;
                    }

                    Task.WaitAll(taskInsertTlLog.ToArray());

                    // success get data
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
