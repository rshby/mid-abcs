using cif_inquiry.Services;
using Inquiry.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace cif_inquiry.Resolver
{
   public class CifInquiryQueryType
   {
      [GraphQLName("cif_inquiry")]
      public async Task<ABCS_M_CFMAST?> GetByCifNumAsync([Service] ICifInquiryService cifInquiryService, [Required] string? cifnum) => await cifInquiryService.GetByCifNumAsync(cifnum);
   }
}
