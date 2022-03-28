using bank.lib.Exceptions;

namespace bank.lib;

public partial class Bank
{
    public partial string CoerceIntoDebtBondage();
    public const decimal InterestRate = 0.02M;
    
    private List<Account> accounts;

    public Bank()
    {
        accounts = new List<Account>();
    }

    public int ReadOnlyNumber
    {
        get
        {
            return (int)InterestRate;
        }
    }

    #region Boring Code

    public IEnumerable<Account> Accounts => accounts;

    public string MakeCheckingAccount(string newAccountName)
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

    #endregion

    public string MakeSavingsAccount(string newAccountName)
    {
        try
        {
            accounts.Add(new SavingsAccount(newAccountName));
            return null;
        }
        catch(Exception ex)
        {
            return ex.Message;
        }
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

    public void LoadAccounts()
    {
        if (File.Exists("accounts.txt"))
        {
            accounts = Account.Load("accounts.txt");
        }
    }

    private class NestedBankClass
    {        
        public NestedBankClass()
        {
            SomeProperty = DateTime.Now.Ticks;
        }

        public long SomeProperty{get;set;}
    }
}
