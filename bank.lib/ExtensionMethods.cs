namespace bank.lib;

public static class ExtensionMethods
{
    public static int DoubleIt(this int num)
    {
        return num * 2;
    }

    public static string DoubleIt(this string str)
    {
        return str+str;
    }

    public static double DoubleIt(this double num) => num*2;
}
