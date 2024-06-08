using System;

namespace PersonalPortfolio4;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        if (Sum(2, 2) != 4) { throw new Exception(); }
    }

    private int Sum(int left, int right) => left + right;
}