namespace BankAccount
{
    public class Messages
    {
        private static void WriteOffMessage(object sender, EventArgs eventArgs)
        {
            if(sender is FileStorage) 
            {
                Console.WriteLine($"хуй {eventArgs}");
            }
        }
    }
}
