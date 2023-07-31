using accountnumber_inquiry.Models.DTO;
using accountnumber_inquiry.Services;
using System.ComponentModel.DataAnnotations;

namespace accountnumber_inquiry.Resolver
{
   public class AccountNumberInquiryQueryType
   {
      [GraphQLName("accountnumber_inquiry")]
      public async Task<InquiryAccountNumberResponse?> InquiryByAccountNumber([Service] IAccountNumberInquiryService accNumService, [Required] string? accountnumber) => await accNumService.InquiryByAccountNumberAsync(accountnumber);
   }
}
