using inq_cif.Models;

namespace inq_cif.Services
{
   public interface InterfaceInqCifService
   {
      // method get data by cifnum
      public Task<ABCS_M_CFMAST?> GetByCifNumAsync(string? inputCifNum);
   }
}
