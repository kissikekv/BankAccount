namespace Storage
{
    public interface IStorage
    {
        public void AddAccount(string accountNumber,
            string nameOfOwner,
            string surnameOfOwner,
            decimal balance, int bonuses);
        public AccountDto? FindAccountByNumber(string? number);
        public void RewriteFileWith(List<AccountDto> accList);
        public void DeleteAccount(string accountNumber);
        public List<AccountDto> ReadAccounts();
        public void Update(AccountDto? acc);
    }
}
