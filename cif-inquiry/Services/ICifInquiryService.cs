using Inquiry.Models.Entity;

namespace cif_inquiry.Services
{
   public interface ICifInquiryService
   {
      // method to get data ABCS_M_CFMAST by cifnum
      public Task<ABCS_M_CFMAST?> GetByCifNumAsync(string? cifnum);      
   }
}
