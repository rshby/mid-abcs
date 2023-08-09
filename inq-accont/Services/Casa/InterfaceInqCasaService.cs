using inq_accont.Models.DTO;

namespace inq_accont.Services.Casa
{
   public interface InterfaceInqCasaService
   {
      // method to get rekening casa by accountnumber
      public Task<List<CaSaResponse>?> GetByAccountNumberAsync(string? inputAccountNumber);

      // method to get data rekening casa by cifnum
      public Task<List<CaSaResponse>?> GetByCifNumAsync(string? inputCifNum);

      // method to get data rekening casa by cifnum and accountnumber
      public Task<List<CaSaResponse>?> GetByCifNumAndAccountNumberAsync(string? inputCifNum, string? inputAccountNumber);
   }
}
