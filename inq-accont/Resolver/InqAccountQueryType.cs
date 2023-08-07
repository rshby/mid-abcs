using inq_accont.Models.DTO;
using inq_accont.Services.Casa;
using inq_accont.Services.Deposit;
using inq_accont.Services.GL;
using inq_accont.Services.Loan;
using System.ComponentModel.DataAnnotations;

namespace inq_accont.Resolver
{
   public class InqAccountQueryType
   {
      // handler get data rekening casa by accountnumber
      [GraphQLName("abcs_inq_casa")]
      public async Task<CaSaResponse?> GetCasaByAccountNumberAsync([Service] InterfaceInqCasaService inqCasaService, [Required] string? accountnumber) => await inqCasaService.GetByAccountNumberAsync(accountnumber);

      // handler get data rekening deposit by accountnumber
      [GraphQLName("abcs_inq_deposit")]
      public async Task<DepositAccountResponse?> GetDepositByAccountNumberAsync([Service] InterfaceInqDepositService inqDepositService, [Required] string? accountnumber) => await inqDepositService.GetByAccountNumberAsync(accountnumber);

      // handler get data rekening gl by accountnumber
      [GraphQLName("abcs_inq_gl")]
      public async Task<GlAccountResponse?> GetGlByAccountNumberAsync([Service] InterfaceInqGlService inqGlService, [Required] string? accountnumber) => await inqGlService.GetByAccountNumberAsync(accountnumber);

      // handler get data rekening loan by accountnumber
      [GraphQLName("abcs_inq_loan")]
      public async Task<LoanAccountResponse?> GetLoanByAccountNumber([Service] InterfaceInqLoanService inqLoanService, [Required] string? accountnumber) => await inqLoanService.GetByAccountNumberAsync(accountnumber);
   }
}
