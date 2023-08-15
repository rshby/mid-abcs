using dnet_models.DTO.Core;
using inq_accont.Services.Casa;
using inq_accont.Services.Deposit;
using inq_accont.Services.GL;
using inq_accont.Services.Loan;
using System.ComponentModel.DataAnnotations;

namespace inq_accont.Resolver
{
    public class InqAccountQueryType
    {
        // handler get data rekening saving
        [GraphQLName("abcs_inq_saving")]
        public async Task<List<CaSaResponse>?> GetSavingAsync([Service] InterfaceInqCasaService inqCasaService, string? cifnum, string? account_number) => await inqCasaService.GetSavingByCifNumAndAccountNumber(cifnum, account_number);

        // handler get data rekening giro
        [GraphQLName("abcs_inq_giro")]
        public async Task<List<CaSaResponse>?> GetGiroAsync([Service] InterfaceInqCasaService inqCasaService, string? cifnum, string? account_number) => await inqCasaService.GetGiroByCifNumAndAccountNumber(cifnum, account_number);

        // handler get data rekening deposit by accountnumber
        [GraphQLName("abcs_inq_deposit")]
        public async Task<List<DepositAccountResponse>?> GetDepositByAccountNumberAsync([Service] InterfaceInqDepositService inqDepositService, string? cifnum, string? account_number) => await inqDepositService.GetByCifNumAndAccountNumber(cifnum, account_number);

        // handler get data rekening gl by accountnumber
        [GraphQLName("abcs_inq_gl")]
        public async Task<List<GlAccountResponse>?> GetGlByAccountNumberAsync([Service] InterfaceInqGlService inqGlService, [Required] string? account_number) => await inqGlService.GetByAccountNumberAsync(account_number);

        // handler get data rekening loan by accountnumber
        [GraphQLName("abcs_inq_loan")]
        public async Task<List<LoanAccountResponse>?> GetLoanByAccountNumber([Service] InterfaceInqLoanService inqLoanService, string? cifnum, string? account_number) => await inqLoanService.GetByCifNumAndAccountNumberAsync(cifnum, account_number);
    }
}
