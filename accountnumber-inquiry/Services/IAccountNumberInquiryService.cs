using accountnumber_inquiry.Models.DTO;

namespace accountnumber_inquiry.Services
{
   public interface IAccountNumberInquiryService
   {
      //  method inquiry rekening by CIFNUM
      public Task<List<InquiryAccountNumberResponse>?> InquiryByCifNumAsync(string? inputCifNum);

      // method inquiry rekening by ACCOUNTNUMBER
      public Task<InquiryAccountNumberResponse?> InquiryByAccountNumberAsync(string? inputAccountNumber);
   }
}
