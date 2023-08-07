using inq_accont.Models.DTO;
using inq_accont.Services.Casa;
using inq_accont.Services.Deposit;
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
      public async Task<DepositAccountResponse?> GetDepositByAccountNumber([Service] InterfaceInqDepositService inqDepositService, [Required] string? accountnumber) => await inqDepositService.GetByAccountNumberAsync(accountnumber);
   }
}
