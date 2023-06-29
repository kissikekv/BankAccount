namespace BankAccount
{
    internal class FileStorage
    {     
        private readonly string _path;

        public FileStorage(string path)
        {
            Validator.ValidateFilePath(path);
            _path = path;
        }

        public Account? FindAccountByNumber(string? number)
        {
            if (!File.Exists(_path))
            {
                return default;
            }

            using (StreamReader sreader = new StreamReader(_path))
            {
                while (!sreader.EndOfStream)
                {
                    var tempAccountNumber = sreader.ReadLine();
                    var tempNameOfOwner = sreader.ReadLine();
                    var tempSurnameOfOwner = sreader.ReadLine();
                    var tempBalance = sreader.ReadLine();
                    var tempBonuses = sreader.ReadLine();                    
                    if (tempAccountNumber == number)
                    {
                        return new Account(
                            tempAccountNumber,
                            tempNameOfOwner,
                            tempSurnameOfOwner,
                            Convert.ToDecimal(tempBalance),
                            Convert.ToInt32(tempBonuses)
                            );
                    }
                }
                return default;
            }
        }

        public void RefillMoney(decimal amountOfMoney, string number)
        {
            var acc = FindAccountByNumber(number);
            acc.Balance = acc.Balance + amountOfMoney;            
        }

        public void WriteOffMoney(decimal amountOfMoney, string number)
        {
            var acc = FindAccountByNumber(number);
            if (acc.Balance >= amountOfMoney)
            {
                acc.Balance -= amountOfMoney;                
            }
            else
            {
                return;
            }
        }

        public void CreateNewAccount(string accountNumber, string nameOfOwner, string surnameOfOwner, decimal balance, int bonuses, string accountGradation)
        {
            using (StreamWriter stwriter = new StreamWriter(_path, true))
            {
                stwriter.WriteLine(accountNumber);
                stwriter.WriteLine(nameOfOwner);
                stwriter.WriteLine(surnameOfOwner);
                stwriter.WriteLine(balance);
                stwriter.WriteLine(bonuses);
                stwriter.WriteLine(accountGradation);
            }
        }

        public void RemoveAccount(string accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
