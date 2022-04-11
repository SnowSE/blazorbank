using bank.lib.Exceptions;

namespace bank.lib;

public partial class Bank
{
    public partial string CoerceIntoDebtBondage();
    public const decimal InterestRate = 0.02M;
    private readonly IStorageService storageService;

    //any regular plain old comment
    //i can say anything
    //the compiler doesn't care

    private List<Account> accounts;

    ///<summary>
    /// Constructor for Bank Class - it's great!
    ///</summary>
    public Bank(IStorageService storageService)
    {
        accounts = new List<Account>();
        this.storageService = storageService;
    }

    /// <summary>
    /// This shows the interest rate, casted as an integer.  Can be read but not modified.
    /// </summary>
    /// <value></value>
    public int ReadOnlyNumber
    {
        get
        {
            return (int)InterestRate;
        }
    }

    #region Boring Code

    public IEnumerable<Account> Accounts => accounts;

    public Account GetBiggestAccount()
    {
        var biggestAccount = accounts[0];
        foreach(var a in accounts)
        {
            if(a.Balance > biggestAccount.Balance)
            {
                biggestAccount = a;
            }
        }
        return biggestAccount;
    }

    public Account GetBiggestAccount2()
    {
        return accounts.OrderByDescending(a => a.GetHashCode()).First();
    }

    public static List<string> GetDetails(object o)
    {
        var output = new List<string>();

        var objectType = o.GetType();
        foreach(var p in objectType.GetProperties())
        {
            output.Add($"{p.Name}: {p.GetValue(o)}");
        }

        return output;
    }

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
        storageService.SaveAccounts(accounts);
    }

    public void LoadAccounts()
    {
        accounts.Clear();
        accounts.AddRange(storageService.LoadAccounts());
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
