namespace bank.lib;

public partial class Bank
{
    public int NewPropertyDefinedInPartialClass{get;set;}

    public partial string CoerceIntoDebtBondage()
    {
        return "Accept new debt, You deserve it!";
    }
}