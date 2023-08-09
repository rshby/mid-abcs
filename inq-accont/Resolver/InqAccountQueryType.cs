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
      public async Task<List<CaSaResponse>?> GetCasaByAccountNumberAsync([Service] InterfaceInqCasaService inqCasaService, string? cifnum, string? account_number)
      {
         if (cifnum != null && account_number == null)
         {
            return await inqCasaService.GetByCifNumAsync(cifnum);
         }

         if (cifnum == null && account_number != null)
         {

            return await inqCasaService.GetByAccountNumberAsync(account_number);
         }

         if (cifnum != null && account_number != null)
         {
            return await inqCasaService.GetByCifNumAndAccountNumberAsync(cifnum, account_number);
         }

         throw new GraphQLException(new ErrorBuilder().SetMessage("parameter required").Build());
      }

      // handler get data rekening saving
      [GraphQLName("abcs_inq_saving")]
      public async Task<List<CaSaResponse>?> GetSavingAsync([Service] InterfaceInqCasaService inqCasaService, string? cifnum, string? account_number)
      {
         if (cifnum != null && account_number == null)
         {
            return await inqCasaService.GetSavingByCifNumAsync(cifnum);
         }

         if (cifnum == null && account_number != null)
         {
            return await inqCasaService.GetSavingByAccountNumber(account_number);
         }

         if (cifnum != null && account_number != null)
         {
            return await inqCasaService.GetSavingByCifNumAndAccountNumber(cifnum, account_number);
         }

         throw new GraphQLException(new ErrorBuilder().SetMessage("input required").Build());
      }

      // handler get data rekening deposit by accountnumber
      [GraphQLName("abcs_inq_deposit")]
      public async Task<List<DepositAccountResponse>?> GetDepositByAccountNumberAsync([Service] InterfaceInqDepositService inqDepositService, [Required] string? account_number) => await inqDepositService.GetByAccountNumberAsync(account_number);

      // handler get data rekening gl by accountnumber
      [GraphQLName("abcs_inq_gl")]
      public async Task<List<GlAccountResponse>?> GetGlByAccountNumberAsync([Service] InterfaceInqGlService inqGlService, [Required] string? account_number) => await inqGlService.GetByAccountNumberAsync(account_number);

      // handler get data rekening loan by accountnumber
      [GraphQLName("abcs_inq_loan")]
      public async Task<List<LoanAccountResponse>?> GetLoanByAccountNumber([Service] InterfaceInqLoanService inqLoanService, [Required] string? account_number) => await inqLoanService.GetByAccountNumberAsync(account_number);
   }
}
