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

      // method get data rekening saving by cifnum
      public Task<List<CaSaResponse>?> GetSavingByCifNumAsync(string? inputCifNum);

      // method get data rekening saving by accountnumber
      public Task<List<CaSaResponse>?> GetSavingByAccountNumber(string? inputAccountNumber);

      // method get data rekening saving by cifnum and accountnumber
      public Task<List<CaSaResponse>?> GetSavingByCifNumAndAccountNumber(string? inputCifNum, string? inputAccountNumber);

      // method get data rekening giro by cifnum
      public Task<List<CaSaResponse>?> GetGiroByCifNum(string? inputCifNum);

      // method get data rekening giro by accountnumber
      public Task<List<CaSaResponse>?> GetGiroByAccountNumber(string? inputAccountNumber);

      // method get data rekening giro by cifnum and accoutnumber
      public Task<List<CaSaResponse>?> GetGiroByCifNumAndAccountNumber(string? inputCifNum, string? inputAccountNumber);
   }
}
