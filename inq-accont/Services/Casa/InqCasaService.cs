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

        // method untuk get rekening casa by cif
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

        // method to get data rekening casa by cif and account_number
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


        // method get data rekening saving by cifnum
        public async Task<List<CaSaResponse>?> GetSavingByCifNumAsync(string? inputCifNum)
        {
            //using (var tr = new TransactionScope(TransactionScopeOption.Suppress, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted, Timeout = TimeSpan.FromSeconds(60) }, TransactionScopeAsyncFlowOption.Suppress))
            using (var tr = new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var findSavingDDMAST = _ddmastRepo.GetSavingByCifNumAsync(inputCifNum);
                    var findSavingDDMEMO = _ddmemoRepo.GetSavingByCifNumAsync(inputCifNum);

                    double? minimumBalance = null;
                    List<CaSaResponse>? response = new List<CaSaResponse>();
                    Task.WaitAll(findSavingDDMEMO, findSavingDDMAST);

                    // set minimumBalance di awal sekali saja (karena productypenya sama)
                    if (findSavingDDMEMO.Result?.Count > 0)
                    {
                        minimumBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findSavingDDMEMO.Result[0].ProductType).Result?.MinimumBalance);
                    }
                    else
                    {
                        if (findSavingDDMAST.Result?.Count > 0)
                        {
                            minimumBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findSavingDDMAST.Result[0].ProductType).Result?.MinimumBalance);
                        }
                    }

                    // ambil semua data yang ada di tabel ABCS_M_DDMEMO, masukkan ke response
                    foreach (var dataSavingDDMEMO in findSavingDDMEMO.Result)
                    {
                        response.Add(new CaSaResponse()
                        {
                            AccountNumber = dataSavingDDMEMO.AccountNumber,
                            ShortName = dataSavingDDMEMO.ShortName,
                            MinimalBalance = (minimumBalance != null) ? minimumBalance : Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(dataSavingDDMEMO.ProductType).Result?.MinimumBalance)
                        });
                    }

                    // looping semua data di ABCS_M_DDMAST 
                    if (findSavingDDMAST.Result?.Count > 0)
                    {
                        foreach (var dataSavingDDMAST in findSavingDDMAST.Result)
                        {
                            // jika value property account_number yg ada di data DDMAST tidak ada di data DDMEMO -> masukkan ke response
                            if (!response.Select(x => x.AccountNumber).Contains(dataSavingDDMAST.AccountNumber))
                            {
                                response.Add(new CaSaResponse()
                                {
                                    AccountNumber = dataSavingDDMAST.AccountNumber,
                                    ShortName = dataSavingDDMAST.ShortName,
                                    MinimalBalance = (minimumBalance != null) ? minimumBalance : Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(dataSavingDDMAST.ProductType).Result?.MinimumBalance)
                                });
                            }
                        }
                    }

                    if (response.Count > 0)
                    {
                        foreach (CaSaResponse? resp in response)
                        {
                            // insert ke tabel ABCS_T_TLLOG -> dibikin Task.Run supaya asynchronous
                        }
                    }

                    // jika not found
                    if (response.Count.Equals(0))
                    {
                        tr.Complete();
                        return null;
                    }

                    // success get data
                    tr.Dispose();
                    return response;
                }
                catch (Exception err)
                {
                    tr.Dispose();
                    throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
                }
            }
        }

        // method get data rekening saving by accountnumber
        public async Task<List<CaSaResponse>?> GetSavingByAccountNumber(string? inputAccountNumber)
        {
            using (var tr = new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Suppress))
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
                            AccountNumber = findDDMEMO.Result.AccountNumber,
                            ShortName = findDDMEMO.Result.ShortName,
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
                                AccountNumber = findDDMAST.Result.AccountNumber,
                                ShortName = findDDMAST.Result?.ShortName,
                                MinimalBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findDDMAST.Result?.ProductType).Result?.MinimumBalance)
                            });
                        };
                    }

                    if (response.Count > 0)
                    {
                        foreach (var dataResp in response)
                        {
                            // insert ke tabel ABCS_T_TLLOG
                        }
                    }

                    if (response.Count.Equals(0))
                    {
                        tr.Dispose();
                        return null;
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

        // method get data rekening saving by cifnum and accountnumber
        public async Task<List<CaSaResponse>?> GetSavingByCifNumAndAccountNumber(string? inputCifNum, string? inputAccountNumber)
        {
            using (var tr = new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Suppress))
            {
                try
                {
                    var findDDMEMO = _ddmemoRepo.GetSavingByCifNumAndAccountNumberAsync(inputCifNum, inputAccountNumber);
                    var findDDMAST = _ddmastRepo.GetSavingByCifNumAndAccountNumberAsync(inputCifNum, inputAccountNumber);

                    List<CaSaResponse>? response = new List<CaSaResponse>();
                    Task.WaitAll(findDDMEMO, findDDMAST);

                    // jika ketemu di tabel DDMEMO
                    if (findDDMEMO.Result != null)
                    {
                        response.Add(new CaSaResponse()
                        {
                            AccountNumber = findDDMEMO.Result.AccountNumber,
                            ShortName = findDDMEMO.Result.ShortName,
                            MinimalBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findDDMEMO.Result.ProductType).Result?.MinimumBalance)
                        });
                    }
                    else
                    {
                        // jika ketemunya di tabel DDMAST
                        if (findDDMAST.Result != null)
                        {
                            response.Add(new CaSaResponse()
                            {
                                AccountNumber = findDDMAST.Result.AccountNumber,
                                ShortName = findDDMAST.Result.ShortName,
                                MinimalBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findDDMAST.Result.ProductType).Result?.MinimumBalance)
                            });
                        }
                    }

                    if (response.Count > 0)
                    {
                        // proses insert ke tabel ABCS_T_TLLOG -> dibikin Task.Run supaya asynchronous
                        foreach (CaSaResponse dataResp in response)
                        {

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

        // method get data rekening giro by cifnum
        public async Task<List<CaSaResponse>?> GetGiroByCifNum(string? inputCifNum)
        {
            using (var tr = new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Suppress))
            {
                try
                {
                    var findDDMEMO = _ddmemoRepo.GetGiroByCifNumAsync(inputCifNum);
                    var findDDMAST = _ddmastRepo.GetGiroByCifNumAsync(inputCifNum);

                    double? minimumBalance = null;
                    List<CaSaResponse>? response = new List<CaSaResponse>();
                    Task.WaitAll(findDDMEMO, findDDMAST);

                    // set minimumBalance di awal sekali saja (karena jika ada banyak rekening sudah pasti productype sama)
                    if (findDDMEMO.Result?.Count > 0)
                    {
                        minimumBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findDDMEMO.Result[0].ProductType).Result?.MinimumBalance);
                    }
                    else
                    {
                        if (findDDMAST.Result?.Count > 0)
                        {
                            minimumBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findDDMAST.Result[0].ProductType).Result?.MinimumBalance);
                        }
                    }

                    foreach (var dataDDMEMO in findDDMEMO.Result)
                    {
                        response.Add(new CaSaResponse()
                        {
                            AccountNumber = dataDDMEMO.AccountNumber,
                            ShortName = dataDDMEMO.ShortName,
                            MinimalBalance = (minimumBalance != null) ? minimumBalance : Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(dataDDMEMO.ProductType).Result?.MinimumBalance)
                        });
                    }

                    if (findDDMAST.Result?.Count > 0)
                    {
                        foreach (var dataDDMAST in findDDMAST.Result)
                        {
                            // cek jika value property account_number yg ada di data DDMAST tidak ada di list response -> maka masukkan ke response
                            if (!response.Select(x => x.AccountNumber).Contains(dataDDMAST.AccountNumber))
                            {
                                response.Add(new CaSaResponse()
                                {
                                    AccountNumber = dataDDMAST.AccountNumber,
                                    ShortName = dataDDMAST.ShortName,
                                    MinimalBalance = (minimumBalance != null) ? minimumBalance : Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(dataDDMAST.ProductType).Result?.MinimumBalance)
                                });
                            }
                        }
                    }

                    if (response.Count > 0)
                    {
                        foreach (var eachResponse in response)
                        {
                            // insert ke tabel ABCS_T_TLLOG
                        }
                    }

                    // wait all task insert TLLOG

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

        // method get data rekening giro by accountnumber (only)
        public async Task<List<CaSaResponse>?> GetGiroByAccountNumber(string? inputAccountNumber)
        {
            using (var tr = new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Suppress))
            {
                try
                {
                    // 1. get data dari tabel DDMEMO dan DDMAST
                    var findDDMEMO = _ddmemoRepo.GetGiroByAccountNumber(inputAccountNumber);
                    var findDDMAST = _ddmastRepo.GetGiroByAccountNumber(inputAccountNumber);

                    List<CaSaResponse>? response = new List<CaSaResponse>();
                    Task.WaitAll(findDDMEMO, findDDMAST);

                    // 2. cek jika data ada di tabel DDMEMO -> masukkan ke response
                    if (findDDMEMO.Result != null)
                    {
                        response.Add(new CaSaResponse()
                        {
                            AccountNumber = findDDMEMO.Result.AccountNumber,
                            ShortName = findDDMEMO.Result.ShortName,
                            MinimalBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findDDMEMO.Result.ProductType).Result?.MinimumBalance)
                        });
                    }
                    else
                    {
                        if (findDDMAST.Result != null)
                        {
                            response.Add(new CaSaResponse()
                            {
                                AccountNumber = findDDMAST.Result.AccountNumber,
                                ShortName = findDDMAST.Result.ShortName,
                                MinimalBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findDDMAST.Result.ProductType).Result?.MinimumBalance)
                            });
                        }
                    }

                    if (response.Count > 0)
                    {
                        // insert ke tabel ABCS_T_TLLOG
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

        // method get data rekening giro by cifnum and accountnumber
        public async Task<List<CaSaResponse>?> GetGiroByCifNumAndAccountNumber(string? inputCifNum, string? inputAccountNumber)
        {
            using (var tr = new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Suppress))
            {
                try
                {
                    var findDDMEMO = _ddmemoRepo.GetGiroByCifNumAndAccountNumberAsync(inputCifNum, inputAccountNumber);
                    var findDDMAST = _ddmastRepo.GetGiroByCifNumAndAccountNumberAsync(inputCifNum, inputAccountNumber);

                    List<CaSaResponse>? response = new List<CaSaResponse>();
                    Task.WaitAll(findDDMEMO, findDDMAST);

                    if (findDDMEMO.Result != null)
                    {
                        response.Add(new CaSaResponse()
                        {
                            AccountNumber = findDDMEMO.Result.AccountNumber,
                            ShortName = findDDMEMO.Result.ShortName,
                            MinimalBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findDDMEMO.Result.ProductType).Result?.MinimumBalance)
                        });
                    }
                    else
                    {
                        if (findDDMAST.Result != null)
                        {
                            response.Add(new CaSaResponse()
                            {
                                AccountNumber = findDDMAST.Result.AccountNumber,
                                ShortName = findDDMAST.Result.ShortName,
                                MinimalBalance = Convert.ToDouble(_ddpar2Repo.GetByProductTypeAsync(findDDMAST.Result.ProductType).Result?.MinimumBalance)
                            });
                        }
                    }

                    if (response.Count > 0)
                    {
                        // insert ke tabel ABCS_T_TLLOG
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
