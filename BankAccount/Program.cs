namespace BankAccount
{
    class Program
    {
        public static void Main(string[] args)
        {
            Account acc = new Account("2222 2222 2222 2222", "heusos", "pidor", 1.4m, 2);

            Console.WriteLine(acc.ToString());

            StatusBlack blackAcc = new StatusBlack("2222 2222 2222 2222", "heusos", "pidor", 1.4m, 2);

            Console.WriteLine(blackAcc.BonusAmount(14));
        }
    }
}
