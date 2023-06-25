namespace BankAccount
{
    internal interface ICreditableidk
    {
        public void RefillMoney(decimal s);

        public void WriteOffMoney();

        public void CreateNewAccont();

        public void RemoveAccont();
    }
}
