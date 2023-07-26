using sa_inquiry.Models.Entity;

namespace sa_inquiry.Services
{
   public interface ISaInquiryService
   {
      // method to inquiry Sa
      public Task<ABCS_M_DDMAST?> InquirySaAsync(string? inputAccountNumber);
   }
}
