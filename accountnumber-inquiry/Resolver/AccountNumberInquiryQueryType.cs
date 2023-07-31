using accountnumber_inquiry.Models.DTO;
using accountnumber_inquiry.Services;
using System.ComponentModel.DataAnnotations;

namespace accountnumber_inquiry.Resolver
{
   public class AccountNumberInquiryQueryType
   {
      [GraphQLName("accountnumber_inquiry")]
      public async Task<InquiryAccountNumberResponse?> InquiryByAccountNumberAsync([Service] IAccountNumberInquiryService accNumService, [Required] string? accountnumber) => await accNumService.InquiryByAccountNumberAsync(accountnumber);

      [GraphQLName("inquiry_by_cif")]
      public async Task<List<InquiryAccountNumberResponse>?> InquiryByCifAsync([Service] IAccountNumberInquiryService accNumService, [Required] string? cifnum) => await accNumService.InquiryByCifNumAsync(cifnum);
   }
}
