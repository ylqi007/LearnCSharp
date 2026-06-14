namespace Oop.Examples;

public static class ConstructorExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Constructor Examples =====");

        var account = new BankAccount("A001", "Alex");

        Console.WriteLine(account.GetSummary());
    }

    private class BankAccount
    {
        public string AccountId { get; }

        public string OwnerName { get; }

        public BankAccount(string accountId, string ownerName)
        {
            AccountId = accountId;
            OwnerName = ownerName;
        }

        public string GetSummary()
        {
            return $"AccountId = {AccountId}, Owner = {OwnerName}";
        }
    }
}
