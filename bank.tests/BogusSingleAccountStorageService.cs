using bank.lib;
using System;
using System.Collections.Generic;

namespace bank.tests;

public class InMemoryStorageService : IStorageService
{
    private List<Account> accounts;

    public InMemoryStorageService()
    {
        accounts = new List<Account>(new []{new CheckingAccount("Bogus Checking Account", CheckingAccountLevel.Standard)});
    }

    public IEnumerable<Account> LoadAccounts()
    {
        return accounts;
    }

    public void SaveAccounts(IEnumerable<Account> accounts)
    {
        this.accounts.Clear();
        this.accounts.AddRange(accounts);
    }
}
