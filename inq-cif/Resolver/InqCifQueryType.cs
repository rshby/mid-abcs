using inq_cif.Models;
using inq_cif.Services;
using System.ComponentModel.DataAnnotations;

namespace inq_cif.Resolver
{
   public class InqCifQueryType
   {
      [GraphQLName("mbase_inq_cif")]
      public async Task<ABCS_M_CFMAST?> GetByCifNumAsync([Service] InterfaceInqCifService inqCifService, [Required] string? cifnum) => await inqCifService.GetByCifNumAsync(cifnum);
   }
}
