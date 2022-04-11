using NUnit.Framework;
using bank.lib;
using System.Linq;
using System;

namespace bank.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestExtensionMethod()
    {
        int x = 5;
        var y = x.DoubleIt();
        Assert.AreEqual(y, 10);
    }

    [Test]
    public void TestExtensionMethod_String()
    {
        string greeting = "Hello";
        var doubled = greeting.DoubleIt();
        Assert.AreEqual(doubled, "HelloHello");

        var bank = new Bank();
        
    }

    [Test]
    public void TestReflection()
    {
        var bank = new Bank();
        var error = bank.MakeCheckingAccount("Account 1");
        Assert.IsNull(error);
        var account = bank.Accounts.First();
        account.MakeDeposit(500);
        
        var details = Bank.GetDetails(account);
        
        var otherDetails = Bank.GetDetails(DateTime.Now);
        var now = DateTime.Now;

        
    }
}