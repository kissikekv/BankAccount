namespace BankAccount
{
    class Program
    {
        public static void Main(string[] args)
        {
            Account acc = new Account("2222 2222 2222 2222", "heusos", "pidor", 1.4m, 2, 1.2m);

            Console.WriteLine(acc.ToString());

            StatusBlack blackAcc = new StatusBlack("2222 2222 2222 2222", "heusos", "pidor", 1.4m, 2, 1.4m);

            Console.WriteLine(blackAcc.BonusAmount(14, (decimal)blackAcc.Coefficient));
        }
    }
}
