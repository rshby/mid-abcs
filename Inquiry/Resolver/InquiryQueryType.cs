using Inquiry.Models.DTO;
using Inquiry.Services;
using System.ComponentModel.DataAnnotations;

namespace Inquiry.Resolver
{
   public class InquiryQueryType
   {
      // handler to inquiry
      [GraphQLName("inquiry")]
      public async Task<DataCifResponse?> InquiryAsync([Service] InterfaceInquiryService inqService, [Required] string? cifnum) => await inqService.InquiryAsync(cifnum);
   }
}
