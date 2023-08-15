using dnet_models.DTO.Core;
using inq_accont.Helper;
using inq_accont.Repositories;
using System.Transactions;
using entityLocal = inq_accont.Models.Entity.CoreEntity;

namespace inq_accont.Services.GL
{
    public class InqGlService : InterfaceInqGlService
    {
        // global variable
        private readonly ABCS_M_GLMEMO_Repository _glmemoRepo;
        private readonly ABCS_M_GLMAST_Repository _glmastRepo;
        private readonly ABCS_P_DDPAR2_Repository _ddpar2Repo;
        private readonly ABCS_T_TLLOG_Repository _tllogRepo;
        private readonly BRINJOURNALSEQ_Repository _brinjournalRepo;
        private readonly HelperJulianDate _helperJulianDate;

        // create constructor
        public InqGlService(ABCS_M_GLMEMO_Repository glmemoRepo, ABCS_M_GLMAST_Repository glmastRepo, ABCS_P_DDPAR2_Repository ddpar2Repo, ABCS_T_TLLOG_Repository tllogRepo, BRINJOURNALSEQ_Repository brinjournalRepo)
        {
            this._glmemoRepo = glmemoRepo;
            this._glmastRepo = glmastRepo;
            this._ddpar2Repo = ddpar2Repo;
            this._tllogRepo = tllogRepo;
            this._brinjournalRepo = brinjournalRepo;
            this._helperJulianDate = new HelperJulianDate();
        }

        // method to get data rekening gl by accountnumber
        public async Task<List<GlAccountResponse>?> GetByAccountNumberAsync(string? inputAccountNumber)
        {
            using (var tr = new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Suppress))
            {
                try
                {
                    // get data
                    var findGLMEMO = _glmemoRepo.GetByAccountNumberAsync(inputAccountNumber);
                    var findGLMAST = _glmastRepo.GetByAccountNumberAsync(inputAccountNumber);

                    // wait all
                    List<GlAccountResponse>? response = new List<GlAccountResponse>();
                    Task.WaitAll(findGLMEMO, findGLMAST);

                    // masukkan data GLMEMO ke response
                    foreach (var dataGLMEMO in findGLMEMO.Result)
                    {
                        response.Add(new GlAccountResponse()
                        {
                            Branch = dataGLMEMO.Branch,
                            AccountNumber = dataGLMEMO.AccountNumber,
                            AccountType = dataGLMEMO.AccountType,
                            ShortName = dataGLMEMO.ShortName,
                            Currency = dataGLMEMO.Currency,
                            Cbal = dataGLMEMO.Cbal,
                            AvailableBalance = dataGLMEMO.Cbal,
                            Status = dataGLMEMO.Status
                        });
                    }

                    // jika ketemu di tabel ABCS_M_GLMAST
                    if (findGLMAST.Result?.Count > 0)
                    {
                        foreach (var dataGLMAST in findGLMAST.Result)
                        {
                            // jika tidak ketemu -> masukkan dataGLMAST ke response
                            if (response.FirstOrDefault(x => x.Branch.Equals(dataGLMAST.Branch) && x.AccountNumber.Equals(dataGLMAST.AccountNumber) && x.Currency.Equals(dataGLMAST.Currency)) == null)
                            {
                                response.Add(new GlAccountResponse()
                                {
                                    Branch = dataGLMAST.Branch,
                                    AccountNumber = dataGLMAST.AccountNumber,
                                    AccountType = dataGLMAST.AccountType,
                                    ShortName = dataGLMAST.ShortName,
                                    Currency = dataGLMAST.Currency,
                                    Cbal = dataGLMAST.Cbal,
                                    AvailableBalance = dataGLMAST.Cbal,
                                    Status = dataGLMAST.Status
                                });
                            }
                        }
                    }

                    List<Task>? taskInsertTlLog = new List<Task>();
                    if (response.Count > 0)
                    {
                        foreach (var dataResponse in response)
                        {
                            // insert ke tabel ABCS_T_TLLOG
                            var _ = Task.Run(async () =>
                            {
                                var brinjournalSeq = await _brinjournalRepo.GetJournalSeqMobile();
                                var entityTlLog = new entityLocal.ABCS_T_TLLOG()
                                {
                                    WorkStationId = "RV",
                                    TellerId = "0999999",
                                    TransactionCode = "5000003",
                                    TransactionDate = _helperJulianDate.GetTransactionDate(),
                                    DefaultCurrency = dataResponse.Currency,
                                    Currency1 = dataResponse.Currency,
                                    Branch1 = "0999",
                                    ErrorCode = "0000",
                                    EffectiveDate = _helperJulianDate.GetTransactionDate(),
                                    EffDate7 = _helperJulianDate.GetJulianDate(),
                                    TxTime = _helperJulianDate.GetTime()
                                };

                                //Task.WaitAll(brinjournalSeq);

                                string? journalSequence = (Convert.ToInt64(brinjournalSeq?.JournalSeq) + 1).ToString();
                                entityTlLog.JournalSeq = journalSequence;
                                entityTlLog.Trrefn = entityTlLog.TellerId.PadLeft(7, '0') + entityTlLog.EffectiveDate.PadLeft(6, '0') + entityTlLog.JournalSeq.PadLeft(7, '0') + "0";

                                var newData = await _tllogRepo.InsertData(entityTlLog);
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
