namespace BankAccount
{
    public class PlatinumAccount : Account
    {
        private const decimal coefficient = 1.9m;
        public PlatinumAccount(string accountNumber,
            string nameOfOwner,
            string surnameOfOwner,
            decimal balance,
            int bonuses) : base(accountNumber,
                nameOfOwner,
                surnameOfOwner,
                balance,
                bonuses)
        {}

        public override int? BonusAmount(decimal cost)
        {
            return 3 + (int?)(cost * coefficient * coefficient);
        }
    }
}
