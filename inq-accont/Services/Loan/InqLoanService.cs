using dnet_models.DTO.Core;
using dnet_models.Entity.Core;
using inq_accont.Repositories;
using System.Transactions;

namespace inq_accont.Services.Loan
{
    public class InqLoanService : InterfaceInqLoanService
    {
        // global variable
        private readonly ABCS_M_LNMEMO_Repository _lnmemoRepo;
        private readonly ABCS_M_LNMAST_Repository _lnmastRepo;
        private readonly ABCS_P_DDPAR2_Repository _ddpar2Repo;

        // create constructor
        public InqLoanService(ABCS_M_LNMEMO_Repository lnmemoRepo, ABCS_M_LNMAST_Repository lnmastRepo, ABCS_P_DDPAR2_Repository ddpar2Repo)
        {
            this._lnmemoRepo = lnmemoRepo;
            this._lnmastRepo = lnmastRepo;
            this._ddpar2Repo = ddpar2Repo;
        }

        // method get data rekening loan
        public async Task<List<LoanAccountResponse>?> GetByCifNumAndAccountNumberAsync(string? inputCifNum, string? inputAccountNumber)
        {
            using (var tr = new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Suppress))
            {
                try
                {
                    Task<List<ABCS_M_LNMEMO>?> findLNMEMO;
                    Task<List<ABCS_M_LNMAST>?> findLNMAST;

                    if (inputCifNum != null && inputAccountNumber == null)
                    {
                        findLNMEMO = _lnmemoRepo.GetByCifNumAsync(inputCifNum);
                        findLNMAST = _lnmastRepo.GetByCifNumAsync(inputCifNum);
                    }
                    else if (inputCifNum == null && inputAccountNumber != null)
                    {
                        findLNMEMO = _lnmemoRepo.GetByAccountNumberAsync(inputAccountNumber);
                        findLNMAST = _lnmastRepo.GetByAccountNumberAsync(inputAccountNumber);
                    }
                    else if (inputCifNum != null && inputAccountNumber != null)
                    {
                        findLNMEMO = _lnmemoRepo.GetByCifNumAndAccountNumberAsync(inputCifNum, inputAccountNumber);
                        findLNMAST = _lnmastRepo.GetByCifNumAndAccountNumberAsync(inputCifNum, inputAccountNumber);
                    }
                    else
                    {
                        tr.Dispose();
                        throw new GraphQLException(new ErrorBuilder().SetMessage("at least one input parameter required").Build());
                    }

                    List<LoanAccountResponse>? response = new List<LoanAccountResponse>();
                    Task.WaitAll(findLNMEMO, findLNMAST);

                    // ambil semua data yang ada di LNMEMO -> masukkan ke response
                    foreach (var dataLNMEMO in findLNMEMO.Result)
                    {
                        string? minBal = _ddpar2Repo.GetByProductTypeAsync(dataLNMEMO.LoanType).Result?.MinimumBalance;
                        response.Add(new LoanAccountResponse()
                        {
                            AccountNumber = dataLNMEMO.AccountNumber,
                            AccountType = dataLNMEMO.AccountType,
                            ShortName = dataLNMEMO.ShortName,
                            CifNum = dataLNMEMO.CifNum,
                            Currency = dataLNMEMO.Currency,
                            OpenDate = dataLNMEMO.OpenDat6,
                            Hold = dataLNMEMO.Hold,
                            Cbal = dataLNMEMO.Cbal,
                            AvailableBalance = (Convert.ToDouble(dataLNMEMO.Cbal) - Convert.ToDouble(dataLNMEMO.Hold) - Convert.ToDouble(minBal)).ToString("0.0000000"),
                            MinBalance = minBal,
                            Status = dataLNMEMO.Status
                        });
                    }

                    if (findLNMAST.Result?.Count > 0)
                    {
                        // masukkan data LNMAST ke response
                        foreach (var dataLNMAST in findLNMAST.Result)
                        {
                            if (!response.Select(x => x.AccountNumber).Contains(dataLNMAST.AccountNumber))
                            {
                                string? minBal = _ddpar2Repo.GetByProductTypeAsync(dataLNMAST.LoanType).Result?.MinimumBalance;
                                response.Add(new LoanAccountResponse()
                                {
                                    AccountNumber = dataLNMAST.AccountNumber,
                                    AccountType = dataLNMAST.AccountType,
                                    ShortName = dataLNMAST.ShortName,
                                    CifNum = dataLNMAST.CifNum,
                                    Currency = dataLNMAST.Currency,
                                    OpenDate = dataLNMAST.OpenDat6,
                                    Hold = dataLNMAST.Hold,
                                    Cbal = dataLNMAST.Cbal,
                                    AvailableBalance = (Convert.ToDouble(dataLNMAST.Cbal) - Convert.ToDouble(dataLNMAST.Hold) - Convert.ToDouble(minBal)).ToString("0.0000000"),
                                    MinBalance = minBal,
                                    Status = dataLNMAST.Status
                                });
                            }
                        }
                    }

                    if (response.Count > 0)
                    {
                        foreach (var dataResponse in response)
                        {
                            // insert ke tabel ABCS_T_TLLOG
                        }
                    }

                    // jika not found
                    if (response.Count.Equals(0))
                    {
                        tr.Dispose();
                        return null;
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
