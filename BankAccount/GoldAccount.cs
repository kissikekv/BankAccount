namespace BankAccount
{
    public class StatusGold : Account
    {
        private const decimal coefficient = 1.7m;
        public StatusGold(string accountNumber,
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
            return 2 + (int?)(cost * coefficient * coefficient);
        }
    }
}
