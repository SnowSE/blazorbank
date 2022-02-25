namespace blazorbank;

public abstract class Account
{
    public Account(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public decimal Balance{get;private set;}

    public virtual void MakeDeposit(decimal depositAmount)
    {
        Balance += depositAmount;
    }

    public virtual void Save(StreamWriter writer)
    {
        writer.WriteLine("Name:"+this.Name);
        writer.WriteLine("Balance:"+this.Balance);
    }
}

public class SavingsAccount : Account
{
    public SavingsAccount(string name) : base(name)
    {

    }

    public decimal MaxBalance{get;set;}

    public override void Save(StreamWriter writer)
    {
        base.Save(writer);
        writer.WriteLine("MaxBalance:"+MaxBalance);
    }
}

public class CheckingAccount : Account
{
    public CheckingAccount(string name, CheckingAccountLevel accountLevel) : base(name)
    {
        if (name.ToUpper()[0] == name[0])
        {
            if(name.Length > 2)
            {
                //is good
            }
            else{
                //is bad
                throw new NameTooShortException();
            }
            //is good
        }
        else
        {
            //is bad
            throw new NameMustStartWithCapitalException();
        }
        AccountLevel = accountLevel;
    }

    public CheckingAccountLevel AccountLevel { get; }
    
    public override void Save(StreamWriter writer)
    {
        base.Save(writer);
        writer.WriteLine("AccountLevel:"+AccountLevel);
    }
}

public enum CheckingAccountLevel
{
    Standard,
    PoorBoor,
    CollegeStudent,
    HighRoller
}