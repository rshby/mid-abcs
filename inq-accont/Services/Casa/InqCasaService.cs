using dnet_models.DTO.Core;
using dnet_models.Entity.Core;
using inq_accont.Helper;
using inq_accont.Repositories;
using System.Transactions;
using entityLocal = inq_accont.Models.Entity.CoreEntity;

namespace inq_accont.Services.Casa
{
    public class InqCasaService : InterfaceInqCasaService
    {
        // global variable
        private readonly ABCS_M_DDMEMO_Repository _ddmemoRepo;
        private readonly ABCS_M_DDMAST_Repository _ddmastRepo;
        private readonly ABCS_P_DDPAR2_Repository _ddpar2Repo;
        private readonly ABCS_T_TLLOG_Repository _tllogRepo;
        private readonly BRINJOURNALSEQ_Repository _brinjournalRepo;
        private readonly HelperJulianDate _helperJulianDate;

        // create constructor
        public InqCasaService(ABCS_M_DDMEMO_Repository ddmemoRepo, ABCS_M_DDMAST_Repository ddmastRepo, ABCS_P_DDPAR2_Repository ddpar2Repo, ABCS_T_TLLOG_Repository tllogRepo, BRINJOURNALSEQ_Repository brinjournalRepo)
        {
            this._ddmemoRepo = ddmemoRepo;
            this._ddmastRepo = ddmastRepo;
            this._ddpar2Repo = ddpar2Repo;
            this._tllogRepo = tllogRepo;
            this._brinjournalRepo = brinjournalRepo;
            this._helperJulianDate = new HelperJulianDate();
        }

        // method get data rekening saving by cifnum and accountnumber
        public async Task<List<CaSaResponse>?> GetSavingByCifNumAndAccountNumber(string? inputCifNum, string? inputAccountNumber)
        {
            using (var tr = new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Suppress))
            {
                try
                {
                    Task<List<ABCS_M_DDMEMO>?> findDDMEMO;
                    Task<List<ABCS_M_DDMAST>?> findDDMAST;

                    // jika hanya get saving by cifnum
                    if (inputCifNum != null && inputAccountNumber == null)
                    {
                        findDDMEMO = _ddmemoRepo.GetSavingByCifNumAsync(inputCifNum);
                        findDDMAST = _ddmastRepo.GetSavingByCifNumAsync(inputCifNum);
                    }
                    else if (inputCifNum == null && inputAccountNumber != null)
                    {
                        // jika get saving by accountnumber (only)
                        findDDMEMO = _ddmemoRepo.GetSavingByAccountNumber(inputAccountNumber);
                        findDDMAST = _ddmastRepo.GetSavingByAccountNumber(inputAccountNumber);
                    }
                    else if (inputCifNum != null && inputAccountNumber != null)
                    {
                        // jika get saving by cifnum and accountnumber
                        findDDMEMO = _ddmemoRepo.GetSavingByCifNumAndAccountNumberAsync(inputCifNum, inputAccountNumber);
                        findDDMAST = _ddmastRepo.GetSavingByCifNumAndAccountNumberAsync(inputCifNum, inputAccountNumber);
                    }
                    else
                    {
                        tr.Dispose();
                        throw new GraphQLException(new ErrorBuilder().SetMessage("at least one input parameter required").Build());
                    }

                    string? minimumBalance = null;
                    List<CaSaResponse>? response = new List<CaSaResponse>();
                    Task.WaitAll(findDDMEMO, findDDMAST);

                    // set minimumBalance
                    if (findDDMEMO.Result?.Count > 0)
                    {
                        minimumBalance = _ddpar2Repo.GetByProductTypeAsync(findDDMEMO.Result[0].ProductType).Result?.MinimumBalance;
                    }
                    else
                    {
                        if (findDDMAST.Result?.Count > 0)
                        {
                            minimumBalance = _ddpar2Repo.GetByProductTypeAsync(findDDMAST.Result[0].ProductType).Result?.MinimumBalance;
                        }
                    }

                    // masukkan data DDMEMO ke response
                    foreach (var dataMEMO in findDDMEMO.Result)
                    {
                        response.Add(new CaSaResponse()
                        {
                            AccountNumber = dataMEMO.AccountNumber,
                            AccountType = dataMEMO.AccountType,
                            ShortName = dataMEMO.ShortName,
                            CifNum = dataMEMO.CifNum,
                            Currency = dataMEMO.Currency,
                            OpenDate = dataMEMO.OpenDat6,
                            Hold = dataMEMO.Hold,
                            Cbal = dataMEMO.Cbal,
                            AvailableBalance = (Convert.ToDouble(dataMEMO.Cbal) - Convert.ToDouble(dataMEMO.Hold) - Convert.ToDouble(minimumBalance)).ToString("0.0000000"),
                            MinBalance = minimumBalance,
                            Status = dataMEMO.Status
                        });
                    }

                    // jika ketemunya di tabel DDMAST
                    if (findDDMAST.Result?.Count > 0)
                    {
                        foreach (var dataMAST in findDDMAST.Result)
                        {
                            if (!response.Select(x => x.AccountNumber).Contains(dataMAST.AccountNumber))
                            {
                                response.Add(new CaSaResponse()
                                {
                                    AccountNumber = dataMAST.AccountNumber,
                                    AccountType = dataMAST.AccountType,
                                    ShortName = dataMAST.ShortName,
                                    CifNum = dataMAST.CifNum,
                                    Currency = dataMAST.Currency,
                                    OpenDate = dataMAST.OpenDat6,
                                    Hold = dataMAST.Hold,
                                    Cbal = dataMAST.Cbal,
                                    AvailableBalance = (Convert.ToDouble(dataMAST.Cbal) - Convert.ToDouble(dataMAST.Hold) - Convert.ToDouble(minimumBalance)).ToString("0.0000000"),
                                    MinBalance = minimumBalance,
                                    Status = dataMAST.Status
                                });
                            }
                        }
                    }

                    List<Task>? taskInsertTlLog = new List<Task>();
                    if (response.Count > 0)
                    {
                        // proses insert ke tabel ABCS_T_TLLOG
                        foreach (CaSaResponse dataResp in response)
                        {
                            var _ = Task.Run(() =>
                            {
                                var brinJournalSeq = _brinjournalRepo.GetJournalSeqMobile();
                                var entity = new entityLocal.ABCS_T_TLLOG()
                                {
                                    WorkStationId = "RV",
                                    TellerId = "0999999",
                                    TransactionCode = "1000001",
                                    TransactionDate = _helperJulianDate.GetTransactionDate(),
                                    DefaultCurrency = dataResp.Currency,
                                    Currency1 = dataResp.Currency,
                                    Branch1 = "0999",
                                    ErrorCode = "0000",
                                    EffectiveDate = _helperJulianDate.GetTransactionDate(),
                                    EffDate7 = _helperJulianDate.GetJulianDate(),
                                    TxTime = _helperJulianDate.GetTime()
                                };

                                Task.WaitAll(brinJournalSeq);

                                string? journalSequence = (Convert.ToInt64(brinJournalSeq.Result?.JournalSeq) + 1).ToString();
                                entity.JournalSeq = journalSequence;
                                entity.Trrefn = "0999999".PadLeft(7, '0') + DateTime.Now.ToLocalTime().ToString("ddMMyy").PadLeft(6, '0') + journalSequence.PadLeft(7, '0') + "0";

                                var newData = _tllogRepo.InsertData(entity).Result;
                            });
                            taskInsertTlLog.Add(_);
                        }
                    }

                    // jika not found
                    if (response.Count.Equals(0))
                    {
                        tr.Dispose();
                        return null;
                    }

                    if (taskInsertTlLog.Count > 0)
                    {
                        Task.WaitAll(taskInsertTlLog.ToArray());
                    }

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

        // method get data rekening giro by cifnum and accountnumber
        public async Task<List<CaSaResponse>?> GetGiroByCifNumAndAccountNumber(string? inputCifNum, string? inputAccountNumber)
        {
            using (var tr = new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Suppress))
            {
                try
                {
                    Task<List<ABCS_M_DDMEMO>?> findDDMEMO;
                    Task<List<ABCS_M_DDMAST>?> findDDMAST;

                    // jika get giro by cifnum (only)
                    if (inputCifNum != null && inputAccountNumber == null)
                    {
                        findDDMEMO = _ddmemoRepo.GetGiroByCifNumAsync(inputCifNum);
                        findDDMAST = _ddmastRepo.GetGiroByCifNumAsync(inputCifNum);
                    }
                    else if (inputCifNum == null && inputAccountNumber != null)
                    {
                        // jika get giro by accountnumber (only)
                        findDDMEMO = _ddmemoRepo.GetGiroByAccountNumber(inputAccountNumber);
                        findDDMAST = _ddmastRepo.GetGiroByAccountNumber(inputAccountNumber);
                    }
                    else if (inputCifNum != null && inputAccountNumber != null)
                    {
                        // jika get giro by cifnum and accountnumber
                        findDDMEMO = _ddmemoRepo.GetGiroByCifNumAndAccountNumberAsync(inputCifNum, inputAccountNumber);
                        findDDMAST = _ddmastRepo.GetGiroByCifNumAndAccountNumberAsync(inputCifNum, inputAccountNumber);
                    }
                    else
                    {
                        tr.Dispose();
                        throw new GraphQLException(new ErrorBuilder().SetMessage("at least one input parameter required").Build());
                    }

                    string? minimumBalance = null;
                    List<CaSaResponse>? response = new List<CaSaResponse>();
                    Task.WaitAll(findDDMEMO, findDDMAST);

                    // set minimumBalance sekali saja
                    if (findDDMEMO.Result?.Count > 0)
                    {
                        minimumBalance = _ddpar2Repo.GetByProductTypeAsync(findDDMEMO.Result[0].ProductType).Result?.MinimumBalance;
                    }
                    else
                    {
                        if (findDDMAST.Result?.Count > 0)
                        {
                            minimumBalance = _ddpar2Repo.GetByProductTypeAsync(findDDMAST.Result[0].ProductType).Result?.MinimumBalance;
                        }
                    }

                    // masukkan semua data dari DDMEMO ke response
                    foreach (var dataMEMO in findDDMEMO.Result)
                    {
                        response.Add(new CaSaResponse()
                        {
                            AccountNumber = dataMEMO.AccountNumber,
                            AccountType = dataMEMO.AccountType,
                            ShortName = dataMEMO.ShortName,
                            CifNum = dataMEMO.CifNum,
                            Currency = dataMEMO.Currency,
                            OpenDate = dataMEMO.OpenDat6,
                            Hold = dataMEMO.Hold,
                            Cbal = dataMEMO.Cbal,
                            AvailableBalance = (Convert.ToDouble(dataMEMO.Cbal) - Convert.ToDouble(dataMEMO.Hold) - Convert.ToDouble(minimumBalance)).ToString("0.0000000"),
                            MinBalance = minimumBalance,
                            Status = dataMEMO.Status
                        });
                    }

                    if (findDDMAST.Result?.Count > 0)
                    {
                        foreach (var dataMAST in findDDMAST.Result)
                        {
                            if (!response.Select(x => x.AccountNumber).Contains(dataMAST.AccountNumber))
                            {
                                response.Add(new CaSaResponse()
                                {
                                    AccountNumber = dataMAST.AccountNumber,
                                    AccountType = dataMAST.AccountType,
                                    ShortName = dataMAST.ShortName,
                                    CifNum = dataMAST.CifNum,
                                    Currency = dataMAST.Currency,
                                    OpenDate = dataMAST.OpenDat6,
                                    Hold = dataMAST.Hold,
                                    Cbal = dataMAST.Cbal,
                                    AvailableBalance = (Convert.ToDouble(dataMAST.Cbal) - Convert.ToDouble(dataMAST.Hold) - Convert.ToDouble(minimumBalance)).ToString("0.0000000"),
                                    MinBalance = minimumBalance,
                                    Status = dataMAST.Status
                                });
                            }
                        }
                    }

                    List<Task>? taskInsertTlLog = new List<Task>();
                    if (response.Count > 0)
                    {
                        foreach (var dataResponse in response)
                        {
                            // insert ke tabel ABCS_T_TLLOG : pake asynchronus yaa
                            var _ = Task.Run(async () =>
                            {
                                var brinJournalSeq = _brinjournalRepo.GetJournalSeqMobile();
                                var entity = new entityLocal.ABCS_T_TLLOG()
                                {
                                    WorkStationId = "RV",
                                    TellerId = "0999999",
                                    TransactionCode = "2000001",
                                    TransactionDate = _helperJulianDate.GetTransactionDate(),
                                    DefaultCurrency = dataResponse.Currency,
                                    Currency1 = dataResponse.Currency,
                                    Branch1 = "0999",
                                    ErrorCode = "0000",
                                    EffectiveDate = _helperJulianDate.GetTransactionDate(),
                                    EffDate7 = _helperJulianDate.GetJulianDate(),
                                    TxTime = _helperJulianDate.GetTime()
                                };

                                Task.WaitAll(brinJournalSeq);

                                string? journalSequence = (Convert.ToInt64(brinJournalSeq.Result?.JournalSeq) + 1).ToString();
                                entity.JournalSeq = journalSequence;
                                entity.Trrefn = entity.TellerId.PadLeft(7, '0') + entity.EffectiveDate.PadLeft(6, '0') + entity.JournalSeq.PadLeft(7, '0') + "0";

                                var newData = await _tllogRepo.InsertData(entity);
                            });
                            taskInsertTlLog.Add(_);
                        }
                    }

                    // jika not found
                    if (response.Count.Equals(0))
                    {
                        tr.Dispose();
                        return null;
                    }

                    if (taskInsertTlLog.Count > 0)
                    {
                        Task.WaitAll(taskInsertTlLog.ToArray());
                    }

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
