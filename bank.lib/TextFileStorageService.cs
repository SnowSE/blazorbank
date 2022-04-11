namespace bank.lib;

public class TextFileStorageService : IStorageService
{
    public IEnumerable<Account> LoadAccounts()
    {
        List<Account> accounts = new List<Account>();
        if (File.Exists("accounts.txt"))
        {
            accounts = Account.Load("accounts.txt");
        }
        return accounts;
    }

    public void SaveAccounts(IEnumerable<Account> accounts)
    {
        using (var writer = new StreamWriter("accounts.txt"))
        {
            foreach (var account in accounts)
            {
                account.Save(writer);
            }
            writer.Close();
        }
    }
}
