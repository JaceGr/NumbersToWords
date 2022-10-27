namespace NumToWordsTesting;
using NumToWords; 

/**
 * This class is unit testing the ConvertSection method that is used throughout ConverNumber
 */
public class SectionConverterUnitTests
{
    [Fact]
    public void SimpleAmountCorrect()
    {
        string expected = "ELEVEN";
        string actual = new ConversionService().ConvertSection(11);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SimpleAmountIncorrect()
    {
        string expected = "EIGHT";
        string actual = new ConversionService().ConvertSection(11);
        Assert.NotEqual(expected, actual);
    }

    [Fact]
    public void TensUnits()
    {
        string expected = "SEVENTY-EIGHT";
        string actual = new ConversionService().ConvertSection(78);
        Assert.Equal(expected, actual);
    }

    // Testing Just tens without units
    [Fact]
    public void Tens()
    {
        string expected = "FORTY";
        string actual = new ConversionService().ConvertSection(40);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void HundredsTensUnits()
    {
        string expected = "ONE HUNDRED AND FIFTY-SIX";
        string actual = new ConversionService().ConvertSection(156);
        Assert.Equal(expected, actual);
    }

    // Testing a number in the hundreds with the tens digit missing.
    [Fact]
    public void HundredsUnits()
    {
        string expected = "TWO HUNDRED AND THREE";
        string actual = new ConversionService().ConvertSection(203);
        Assert.Equal(expected, actual);
    }

    // Testing just a hundred
    [Fact]
    public void Hundreds()
    {
        string expected = "TWO HUNDRED";
        string actual = new ConversionService().ConvertSection(200);
        Assert.Equal(expected, actual);
    }

    // Testing hundreds and tens
    [Fact]
    public void HundredsTens()
    {
        string expected = "NINE HUNDRED AND NINETY";
        string actual = new ConversionService().ConvertSection(990);
        Assert.Equal(expected, actual);
    }

    // Testing the bottom edge case of 0
    [Fact]
    public void Zero()
    {
        string expected = "ZERO";
        string actual = new ConversionService().ConvertSection(0);
        Assert.Equal(expected, actual);
    }
}