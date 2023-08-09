using inq_accont.Models.DTO;

namespace inq_accont.Services.Loan
{
   public interface InterfaceInqLoanService
   {
      // method get data rekening loan by accountnumber
      public Task<List<LoanAccountResponse>?> GetByAccountNumberAsync(string? inputAccountNumber);
   }
}
