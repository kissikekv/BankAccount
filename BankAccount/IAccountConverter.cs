﻿using BankAccount;
using Storage;

namespace BLL
{
    internal interface IAccountConverter
    {
        public BlackAccount CreateBlackAccount(AccountDto accountDto);
        public GoldAccount CreateGoldAccount(AccountDto accountDto);
        public PlatinumAccount CreatePlatinumAccount(AccountDto accountDto);
    }
}
