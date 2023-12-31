﻿using inq_accont.Data;
using dnet_models.Entity.Core;
using Microsoft.EntityFrameworkCore;

namespace inq_accont.Repositories
{
    public class ABCS_M_DDMEMO_Repository
    {
        // global variable
        private readonly InqAccountContext _db;

        // create constructor
        public ABCS_M_DDMEMO_Repository(InqAccountContext db)
        {
            this._db = db;
        }

        // methood get data rekening saving by cifnum
        public async Task<List<ABCS_M_DDMEMO>?> GetSavingByCifNumAsync(string? inputCifNum)
        {
            try
            {
                return await _db.ABCS_M_DDMEMO.AsQueryable().Where(x => x.AccountType.Equals("S") && x.CifNum.Equals(inputCifNum)).ToListAsync<ABCS_M_DDMEMO>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

        // method get data rekening saving by cifnum and accountnumber
        public async Task<List<ABCS_M_DDMEMO>?> GetSavingByCifNumAndAccountNumberAsync(string? inputCifNum, string? inputAccountNumber)
        {
            try
            {
                return await _db.ABCS_M_DDMEMO.AsQueryable().Where(x => x.AccountType.Equals("S") && x.CifNum.Equals(inputCifNum) && x.AccountNumber.Equals(inputAccountNumber)).Take(1).ToListAsync<ABCS_M_DDMEMO>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

        // method get data rekening saving by accountnumber
        public async Task<List<ABCS_M_DDMEMO>?> GetSavingByAccountNumber(string? inputAccountNumber)
        {
            try
            {
                return await _db.ABCS_M_DDMEMO.AsQueryable().Where(x => x.AccountType.Equals("S") && x.AccountNumber.Equals(inputAccountNumber)).Take(1).ToListAsync<ABCS_M_DDMEMO>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

        // method get data rekening giro by cifnum
        public async Task<List<ABCS_M_DDMEMO>?> GetGiroByCifNumAsync(string? inputCifNum)
        {
            try
            {
                return await _db.ABCS_M_DDMEMO.AsQueryable().Where(x => x.AccountType.Equals("D") && x.CifNum.Equals(inputCifNum)).ToListAsync<ABCS_M_DDMEMO>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

        // method get data rekening giro by accountnumber
        public async Task<List<ABCS_M_DDMEMO>?> GetGiroByAccountNumber(string? inputAccountNumber)
        {
            try
            {
                return await _db.ABCS_M_DDMEMO.AsQueryable().Where(x => x.AccountType.Equals("D") && x.AccountNumber.Equals(inputAccountNumber)).Take(1).ToListAsync<ABCS_M_DDMEMO>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }

        // method get data rekening giro by cifnum and accountnumber
        public async Task<List<ABCS_M_DDMEMO>?> GetGiroByCifNumAndAccountNumberAsync(string? inputCifNum, string? inputAccountNumber)
        {
            try
            {
                return await _db.ABCS_M_DDMEMO.AsQueryable().Where(x => x.AccountType.Equals("D") && x.CifNum.Equals(inputCifNum) && x.AccountNumber.Equals(inputAccountNumber)).Take(1).ToListAsync<ABCS_M_DDMEMO>();
            }
            catch (Exception err)
            {
                throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
        }
    }
}
