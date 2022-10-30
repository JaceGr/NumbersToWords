namespace NumToWordsTesting;
using NumToWords; 

/**
 * This class is unit testing the validation of input numbers that are received at the controller.
 */
public class ValidationUnitTests
{
    [Fact]
    public void ValidNumber()
    {
        double expected = 987.54;
        double actual = new ConversionService().ValidateNumber("987.54");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void NegativeDollars()
    {
        double expected = -1;
        double actual = new ConversionService().ValidateNumber("-10.5");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ZeroDollars()
    {
        double expected = 0;
        double actual = new ConversionService().ValidateNumber("0");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void NegativeCents()
    {
        double expected = -1;
        double actual = new ConversionService().ValidateNumber("0.-5");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void UpperRangeBound()
    {
        double expected = -1;
        double actual = new ConversionService().ValidateNumber("1000000000000000");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void UpperRangeBoundInner()
    {
        double expected = 999999999999999.9;
        double actual = new ConversionService().ValidateNumber("999999999999999.9");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void NegativeOntoDecimal()
    {
        double expected = -1;
        double actual = new ConversionService().ValidateNumber("-.5");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Symbol1()
    {
        double expected = -1;
        double actual = new ConversionService().ValidateNumber("!5");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Symbol2()
    {
        double expected = -1;
        double actual = new ConversionService().ValidateNumber("87.0_");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Letter()
    {
        double expected = -1;
        double actual = new ConversionService().ValidateNumber("87.ab");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void HexLetter()
    {
        double expected = -1;
        double actual = new ConversionService().ValidateNumber("0x87");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Space()
    {
        double expected = -1;
        double actual = new ConversionService().ValidateNumber("87 0");
        Assert.Equal(expected, actual);
    }
}