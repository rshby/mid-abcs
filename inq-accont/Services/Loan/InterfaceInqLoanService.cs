using dnet_models.DTO.Core;

namespace inq_accont.Services.Loan
{
   public interface InterfaceInqLoanService
   {
      // method get data rekening loan by accountnumber
      public Task<List<LoanAccountResponse>?> GetByCifNumAndAccountNumberAsync(string? inputCifNum, string? inputAccountNumber);
   }
}
