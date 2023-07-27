using Inquiry.Models.DTO;

namespace Inquiry.Services
{
   public interface InterfaceInquiryService
   {
      // method to inquiry
      public Task<DataCifResponse?> InquiryAsync(string? inputCifNum);
   }
}
