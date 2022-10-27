namespace NumToWordsTesting;
using NumToWords; 

public class DollarConverterUnitTests
{
    [Fact]
    public void ZeroDollarsZeroCents()
    {
        string expected = "ZERO DOLLARS AND ZERO CENTS";
        string actual = new ConversionService().ConvertNumber(0);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SimpleDollarAmountCorrect()
    {
        string expected = "ELEVEN DOLLARS AND ZERO CENTS";
        string actual = new ConversionService().ConvertNumber(11);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DollarCentSimple()
    {
        string expected = "NINE HUNDRED AND EIGHTY-SEVEN DOLLARS AND SIXTY-THREE CENTS";
        string actual = new ConversionService().ConvertNumber(987.63);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ThousandAndHundredDollarCent()
    {
        string expected = "ONE HUNDRED AND TWENTY-THREE THOUSAND, FOUR HUNDRED AND FIFTY-SIX DOLLARS AND SEVENTY-EIGHT CENTS";
        string actual = new ConversionService().ConvertNumber(123456.78);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ThousandDollarCent()
    {
        string expected = "ONE HUNDRED AND TWENTY-THREE THOUSAND DOLLARS AND NINETY-EIGHT CENTS";
        string actual = new ConversionService().ConvertNumber(123000.98);
        Assert.Equal(expected, actual);
    }
}