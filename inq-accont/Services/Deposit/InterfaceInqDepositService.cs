﻿using inq_accont.Models.DTO;

namespace inq_accont.Services.Deposit
{
   public interface InterfaceInqDepositService
   {
      // method to get data rekening deposit by accountnumber
      public Task<List<DepositAccountResponse>?> GetByAccountNumberAsync(string? inputAccountNumber);
   }
}