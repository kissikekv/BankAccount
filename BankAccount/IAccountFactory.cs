using BankAccount;
using Storage;

namespace BLL
{
    internal interface IAccountFactory
    {
        public Account? ReturnAccountGradation(AccountDto accountDto);
    }
}
