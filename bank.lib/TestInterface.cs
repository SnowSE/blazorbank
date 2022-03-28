namespace bank.lib;

public interface TestInterface
{
    void Method();
    string Name{get;}
    string ReadWrite{get;set;}

    static int GetEmotionScore(string greeting)
    {
        switch(greeting)
        {
            default:
                return 0;
        }
    }
}
