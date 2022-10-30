namespace NumToWordsTesting;
using NumToWords; 

/**
 * This class is validating the full functionality of the ConvertNumber method
 */
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
    public void ZeroDollarsZeroCents2()
    {
        string expected = "ZERO DOLLARS AND ZERO CENTS";
        string actual = new ConversionService().ConvertNumber(0.0);
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

    [Fact]
    public void MillionDollar()
    {
        string expected = "NINE HUNDRED AND EIGHTY-SEVEN MILLION DOLLARS AND ZERO CENTS";
        string actual = new ConversionService().ConvertNumber(987000000);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MillionThousandsDollarCent()
    {
        string expected = "NINE HUNDRED AND EIGHTY-SEVEN MILLION, FOUR HUNDRED AND FIFTY-TWO THOUSAND DOLLARS AND ZERO CENTS";
        string actual = new ConversionService().ConvertNumber(987452000);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MillionHundredDollarCent()
    {
        string expected = "NINE HUNDRED AND EIGHTY-SEVEN MILLION, THIRTY DOLLARS AND SEVENTY-EIGHT CENTS";
        string actual = new ConversionService().ConvertNumber(987000030.78);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MillionThousandDollarCent()
    {
        string expected = "NINE HUNDRED AND EIGHTY-SEVEN MILLION, FOUR HUNDRED AND FIFTY-TWO THOUSAND, TWO HUNDRED AND NINETY-TWO DOLLARS AND ONE CENTS";
        string actual = new ConversionService().ConvertNumber(987452292.01);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MillionDollarCent()
    {
        string expected = "ONE MILLION DOLLARS AND ONE CENTS";
        string actual = new ConversionService().ConvertNumber(1000000.01);
        Assert.Equal(expected, actual);
    }

    // Testing range above billions
    [Fact]
    public void BillionDollar()
    {
        string expected = "ONE BILLION DOLLARS AND ZERO CENTS";
        string actual = new ConversionService().ConvertNumber(1000000000.00);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BillionThousandDollar()
    {
        string expected = "TWENTY-ONE BILLION, SIXTY THOUSAND DOLLARS AND ZERO CENTS";
        string actual = new ConversionService().ConvertNumber(21000060000.00);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BillionMillionThousandDollar()
    {
        string expected = "NINE HUNDRED AND EIGHTY-SEVEN BILLION, SIX HUNDRED AND FIFTY-FOUR MILLION, "
            + "THREE HUNDRED AND TWENTY-ONE THOUSAND, TWO HUNDRED AND THIRTY-FOUR DOLLARS AND ZERO CENTS";
        string actual = new ConversionService().ConvertNumber(987654321234.00);
        Assert.Equal(expected, actual);
    }

    // Testing range above one trillion
    [Fact]
    public void TrillionDollar()
    {
        string expected = "ONE TRILLION DOLLARS AND ZERO CENTS";
        string actual = new ConversionService().ConvertNumber(1000000000000.00);
        Assert.Equal(expected, actual);
    }

    // Testing range above one trillion
    [Fact]
    public void TrillionMillionDollar()
    {
        string expected = "ONE HUNDRED TRILLION, EIGHT HUNDRED AND SIXTY-FOUR MILLION DOLLARS AND ZERO CENTS";
        string actual = new ConversionService().ConvertNumber(100000864000000.00);
        Assert.Equal(expected, actual);
    }

    // Testing outside largest range bound in case this somehow gets past validation method.
    [Fact]
    public void UpperBoundDollar()
    {
        string expected = "";
        string actual = new ConversionService().ConvertNumber(1000000000000000.00);
        Assert.Equal(expected, actual);
    }
}