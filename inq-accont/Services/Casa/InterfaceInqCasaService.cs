using dnet_models.DTO.Core;

namespace inq_accont.Services.Casa
{
   public interface InterfaceInqCasaService
   {
      // method get data rekening saving by cifnum and accountnumber
      public Task<List<CaSaResponse>?> GetSavingByCifNumAndAccountNumber(string? inputCifNum, string? inputAccountNumber);

      // method get data rekening giro by cifnum and accoutnumber
      public Task<List<CaSaResponse>?> GetGiroByCifNumAndAccountNumber(string? inputCifNum, string? inputAccountNumber);
   }
}
