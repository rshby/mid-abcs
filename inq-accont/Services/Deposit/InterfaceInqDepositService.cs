using dnet_models.DTO.Core;

namespace inq_accont.Services.Deposit
{
    public interface InterfaceInqDepositService
    {
        public Task<List<DepositAccountResponse>?> GetByCifNumAndAccountNumber(string? inputCifNum, string? inputAccountNumber);
    }
}
