using NUnit.Framework;
using bank.lib;

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
}