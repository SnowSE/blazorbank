using bank.lib.Exceptions;

namespace bank.lib;
public class Bank
{
    private List<Account> accounts;

    public Bank()
    {
        accounts = new List<Account>();
    }

    public IEnumerable<Account> Accounts => accounts;

    public string MakeAccount(string newAccountName)
    {
        string errorMessage;
        
        try
        {
            var newAccount = new CheckingAccount(newAccountName, CheckingAccountLevel.HighRoller);
            accounts.Add(newAccount);
            errorMessage = null;
        }
        catch (NameMustStartWithCapitalException)
        {
            errorMessage = "Invaild Name: must start with capital letter.";
        }
        catch (NameTooShortException)
        {
            errorMessage = "Invalid Name: Your name is too short";
        }

        return errorMessage;
    }

    public void SaveAccounts()
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
