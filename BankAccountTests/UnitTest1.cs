using BankAccount;

namespace BankAccountTests
{
    [TestFixture]
    public class Tests
    {
        [TestCase("asdasdasd", true)]
        [TestCase("asdasdasd1", false)]
        public void Validate_Name_NameIsValidate(string name, bool expectation)
        {
            var validator = new BankAccount.Validator();

            bool exp = validator.NameValidator(name);

            Assert.That(exp, Is.EqualTo(expectation));
        }        
    }
}