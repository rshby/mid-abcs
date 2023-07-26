using sa_inquiry.Models.Entity;
using sa_inquiry.Services;
using System.ComponentModel.DataAnnotations;

namespace sa_inquiry.Resolver
{
   public class SaInquiryQueryType
   {
      // handler to inquiry Sa Account
      [GraphQLName("sa_inquiry")]
      public async Task<ABCS_M_DDMAST?> InquirySaAsync([Service] ISaInquiryService inquiryService, [Required] string? account_number) => await inquiryService.InquirySaAsync(account_number);
   }
}
