using inq_accont.Models.DTO;

namespace inq_accont.Services.GL
{
   public interface InterfaceInqGlService
   {
      // method to get data rekening gl by accountnumber
      public Task<GlAccountResponse?> GetByAccountNumberAsync(string? inputAccountNumber);
   }
}
