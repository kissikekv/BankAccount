namespace BankAccount
{    public class BlackAccount : Account
    {
        private const decimal coefficient = 1.6m;

        public BlackAccount(string accountNumber,
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
            return 1 + (int?)(cost * coefficient * coefficient);
        }
    }
}
