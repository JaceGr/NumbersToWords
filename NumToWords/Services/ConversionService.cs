namespace NumToWords;

public class ConversionService
{
    private Dictionary<int, string> words = new Dictionary<int, string>()
    {
        {1, "ONE"}, {2, "TWO"}, {3, "THREE"}, {4, "FOUR"}, {5, "FIVE"}, {6, "SIX"},
        {7, "SEVEN"}, {8, "EIGHT"}, {9, "NINE"}, {10, "TEN"}, {11, "ELEVEN"}, {12, "TWELVE"},
        {13, "THIRTEEN"}, {14, "FOURTEEN"}, {15, "FIFTEEN"}, {16, "SIXTEEN"}, {17, "SEVENTEEN"},
        {18, "EIGHTEEN"}, {19, "NINETEEN"}, {20, "TWENTY"}, {30, "THIRTY"}, {40, "FORTY"},
        {50, "FIFTY"}, {60, "SIXTY"}, {70, "SEVENTY"}, {80, "EIGHTY"}, {90, "NINETY"}, {0, ""}
    };

    public double ValidateNumber(string input)
    {
        double inputAsNum;
        // Check if number is a valid double
        try
        {
            inputAsNum = double.Parse(input);
        } catch {
            return -1;
        }
        
        // Check if number is within the allowed range
        if(inputAsNum > 999999 || inputAsNum < 0) {
            return -1;
        }

        return inputAsNum;
    }

    public string ConvertNumber(double inputNum)
    {
        int dollars = (int)inputNum; 
        int cents = (int)Math.Round( (inputNum - (double)dollars) * 100);

        string text = "";
        if(dollars == 0) {
            text = "ZERO";
        } else if(dollars < 1000) {
            text = this.ConvertSection(dollars);
        } else if(dollars < 1000000) {
            if(dollars % 1000 == 0) {
                text = this.ConvertSection(this.GetThousands(dollars)) + " THOUSAND";
            } else {
                text = this.ConvertSection(this.GetThousands(dollars)) + " THOUSAND, "
                    + this.ConvertSection(dollars % 1000);
            }
        }

        text += " DOLLARS";

        text = text + " AND " + this.ConvertSection(cents) + " CENTS";
        return text;
    }

    /* Convert a three digit number to words. 
     * This method can be reused for thousands, millions, billions.
     */
    public string ConvertSection(int section)
    {
        if(section == 0) {
            return "ZERO";
        }else if(section < 20) {
            return this.words[section];
        } else if(section < 100) {
            return this.ConvertTens(section);
        } else {
            return this.ConvertHundreds(section);
        }
    }

    // Convert a number between 20 and 99 to text.
    private string ConvertTens(int number)
    {
        if(number % 10 == 0) {
            return this.words[this.GetTenDigit(number)];
        } else if(number / 10 == 0) {
            return this.words[this.GetUnitDigit(number)];
        } else {
            return this.words[this.GetTenDigit(number)] + "-" + this.words[this.GetUnitDigit(number)];
        }
    }

    // Convert a number between 100 and 999 to text.
    private string ConvertHundreds(int number)
    {
        if(number % 100 > 0) {
            return this.words[this.GetHundredDigit(number)] + " HUNDRED AND " 
                + this.ConvertTens(this.GetTenDigit(number) + this.GetUnitDigit(number));
            
        } else {
            return this.words[this.GetHundredDigit(number)] + " HUNDRED";
        }
    }

    // Method to retrieve the unit digit in a three digit number.
    private int GetUnitDigit(int number)
    {
        return number % 10;
    }

    // Method to retrieve the tens digit in a three digit number.
    private int GetTenDigit(int number)
    {
        return (number % 100) / 10 * 10;
    }

    // Method to retrieve the hundreds digit in a three digit number.
    private int GetHundredDigit(int number)
    {
        return number / 100;
    }

    // Method to retrieve the number of thousands from any number.
    private int GetThousands(int number)
    {
        return number / 1000;
    }
}