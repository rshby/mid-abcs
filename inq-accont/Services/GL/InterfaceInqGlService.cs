using dnet_models.DTO.Core;

namespace inq_accont.Services.GL
{
   public interface InterfaceInqGlService
   {
      // method to get data rekening gl by accountnumber
      public Task<List<GlAccountResponse>?> GetByAccountNumberAsync(string? inputAccountNumber);
   }
}
