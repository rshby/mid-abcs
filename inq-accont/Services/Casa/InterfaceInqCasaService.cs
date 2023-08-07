using inq_accont.Models.DTO;

namespace inq_accont.Services.Casa
{
   public interface InterfaceInqCasaService
   {
      // method to get rekening casa by accountnumber
      public Task<CaSaResponse?> GetByAccountNumberAsync(string? inputAccountNumber);
   }
}
