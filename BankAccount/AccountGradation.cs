namespace BankAccount
{
    public class StatusBlack : Account
    {
        private readonly decimal coefficient = 1.6m;

        public StatusBlack(string accountNumber, string nameOfOwner, string surnameOfOwner, decimal balance, int bonuses) : base(accountNumber, nameOfOwner, surnameOfOwner, balance, bonuses)
        {

        }

        public override int? BonusAmount(decimal cost)
        {
            return 1 + (int?)(cost * coefficient * coefficient);
        }
    }

    public class StatusGold : Account
    {
        private readonly decimal coefficient = 1.7m;
        public StatusGold(string accountNumber, string nameOfOwner, string surnameOfOwner, decimal balance, int bonuses, decimal? coefficient) : base(accountNumber, nameOfOwner, surnameOfOwner, balance, bonuses, coefficient)
        {

        }

        public override int? BonusAmount(decimal cost)
        {
            return 2 + (int?)(cost * coefficient * coefficient);
        }
    }

    public class StatusPlatinum : Account
    {
        private readonly decimal coefficient = 1.9m;
        public StatusPlatinum(string accountNumber, string nameOfOwner, string surnameOfOwner, decimal balance, int bonuses, decimal? coefficient) : base(accountNumber, nameOfOwner, surnameOfOwner, balance, bonuses, coefficient)
        {

        }

        public override int? BonusAmount(decimal cost)
        {
            return 3 + (int?)(cost * coefficient * coefficient);
        }
    }
}