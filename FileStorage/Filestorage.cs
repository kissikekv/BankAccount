
namespace Storage
{
    public class FileStorage : IStorage
    {
        private readonly string _path;

        public FileStorage(string path)
        {
            StorageValidator.ValidateFilePath(path);
            _path = path;
        }

        public void AddAccount(string accountNumber,
            string nameOfOwner,
            string surnameOfOwner,
            decimal balance, int bonuses)
        {
            using (StreamWriter stwriter = new StreamWriter(_path, true))
            {
                stwriter.WriteLine(accountNumber);
                stwriter.WriteLine(nameOfOwner);
                stwriter.WriteLine(surnameOfOwner);
                stwriter.WriteLine(balance);
                stwriter.WriteLine(bonuses);
            }
        }

        public AccountDto? FindAccountByNumber(string? number)
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
                        return new AccountDto()
                        {
                            AccountNumber = tempAccountNumber,
                            NameOfOwner = tempNameOfOwner,
                            SurnameOfOwner = tempSurnameOfOwner,
                            Balance = Convert.ToDecimal(tempBalance),
                            Bonuses = Convert.ToInt32(tempBonuses)
                        };
                    }
                }
                return default;
            }
        }
        public void RewriteFileWith(List<AccountDto> accList)
        {
            File.Delete(_path);
            foreach (AccountDto item in accList)
            {
                AddAccount(
                    item.AccountNumber,
                    item.NameOfOwner,
                    item.SurnameOfOwner,
                    item.Balance,
                    item.Bonuses);
            }
        }
        public void DeleteAccount(string accountNumber)
        {
            List<AccountDto> accList = ReadAccounts();
            var bookForDelete = accList.FirstOrDefault(book => book.AccountNumber == accountNumber);
            if (ReferenceEquals(bookForDelete, null))
            {
                return;
            }
            accList.Remove(bookForDelete);
            RewriteFileWith(accList);
        }
        public List<AccountDto> ReadAccounts()
        {
            List<AccountDto> accList = new List<AccountDto>();

            using (StreamReader sreader = new StreamReader(_path))
            {
                while (!sreader.EndOfStream)
                {
                    AccountDto acc = new AccountDto()
                    {
                        AccountNumber = sreader.ReadLine(),
                        NameOfOwner = sreader.ReadLine(),
                        SurnameOfOwner = sreader.ReadLine(),
                        Balance = Convert.ToDecimal(sreader.ReadLine()),
                        Bonuses = Convert.ToInt32(sreader.ReadLine())
                    };
                    accList.Add(acc);
                }
            }
            return accList;
        }
        public void Update(AccountDto? acc)
        {            
            List<AccountDto> accList = ReadAccounts();
            for (int i = 0; i < accList.Count; i++)
            {
                if (accList[i].AccountNumber == acc.AccountNumber)
                {
                    accList[i] = acc;
                    break;
                }
            }
            RewriteFileWith(accList);
        }
    }
}
