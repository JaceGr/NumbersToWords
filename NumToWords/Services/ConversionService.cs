namespace NumToWords;

public class ConversionService
{
    private Dictionary<long, string> words = new Dictionary<long, string>()
    {
        {1, "ONE"}, {2, "TWO"}, {3, "THREE"}, {4, "FOUR"}, {5, "FIVE"}, {6, "SIX"},
        {7, "SEVEN"}, {8, "EIGHT"}, {9, "NINE"}, {10, "TEN"}, {11, "ELEVEN"}, {12, "TWELVE"},
        {13, "THIRTEEN"}, {14, "FOURTEEN"}, {15, "FIFTEEN"}, {16, "SIXTEEN"}, {17, "SEVENTEEN"},
        {18, "EIGHTEEN"}, {19, "NINETEEN"}, {20, "TWENTY"}, {30, "THIRTY"}, {40, "FORTY"},
        {50, "FIFTY"}, {60, "SIXTY"}, {70, "SEVENTY"}, {80, "EIGHTY"}, {90, "NINETY"}, {0, ""}
    };

    /** 
     * Validating whether a string can be converted to a number.
     * returns -1 if unable to convert the number, or the converted number as a double if validated.
     */
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
        if(inputAsNum >= 10000000000000 || inputAsNum < 0) {
            return -1;
        }

        return inputAsNum;
    }

    /**
     * Converts a double to words.
     */
    public String ConvertNumber(double inputNum)
    {
        long dollars = (long)inputNum; 
        long cents = (long)Math.Round( (inputNum - (double)dollars) * 100);

        string text = "";
        if(dollars == 0) {
            text = "ZERO";
        } else if(dollars < 1000) {
            text = this.ConvertSection(dollars);
        } else if(dollars < 1000000) {
            text = this.ConvertThousand(dollars);
            if(dollars % 1000 != 0) {
                text += this.ConvertSection(dollars % 1000);
            }
        } else if(dollars < 1000000000) {
            text = this.ConvertMillion(dollars);
            if(dollars % 1000000 != 0) {
                text += this.ConvertThousand(dollars);
                if(dollars % 1000 != 0) {
                    text += this.ConvertSection(dollars % 1000);
                }
            } 
        } else if(dollars < 1000000000000) {
            text = this.ConvertBillion(dollars);
            if(dollars % 1000000000 != 0) {
                text += this.ConvertMillion(dollars);
                if(dollars % 1000000 != 0) {
                    text += this.ConvertThousand(dollars);
                    if(dollars % 1000 != 0) {
                        text += this.ConvertSection(dollars % 1000);
                    }
                }
            }
        } else if(dollars < 1000000000000000) {
            text = this.ConvertTrillion(dollars);
            if(dollars % 1000000000000 != 0) {
                text += this.ConvertBillion(dollars);
                if(dollars % 1000000000 != 0) {
                    text += this.ConvertMillion(dollars);
                    if(dollars % 1000000 != 0) {
                        text += this.ConvertThousand(dollars);
                        if(dollars % 1000 != 0) {
                            text += this.ConvertSection(dollars % 1000);
                        }
                    }
                }
            } 
        } else {
            return String.Empty;
        }

        text += " DOLLARS";

        text += " AND " + this.ConvertSection(cents) + " CENTS";
        return text;
    }

    /**
     * Converts the thousands block of a number to words. 
     */
    private String ConvertThousand(long number) 
    {
        String text = "";
        if(number % 1000 == 0) {
            text += this.ConvertSection(this.GetThousands(number)) + " THOUSAND";
        } else {
            if(this.GetThousands(number) != 0) {
                text += this.ConvertSection(this.GetThousands(number)) + " THOUSAND, ";
            }
        }
        return text;
    }

    /**
     * Converts the millions block of a number to words. 
     */
    private String ConvertMillion(long number) 
    {
        String text = "";
        if(number % 1000000 == 0) {
            text += this.ConvertSection(this.GetMillions(number)) + " MILLION";
        } else {
            if(this.GetMillions(number) != 0) {
                text += this.ConvertSection(this.GetMillions(number)) + " MILLION, ";
            }
        }
        return text;
    }

    /**
     * Converts the billions block of a number to words. 
     */
    private String ConvertBillion(long number) 
    {
        String text = "";
        if(number % 1000000000 == 0) {
            text += this.ConvertSection(this.GetBillions(number)) + " BILLION";
        } else {
            if(this.GetBillions(number) != 0) {
                text += this.ConvertSection(this.GetBillions(number)) + " BILLION, ";
            }
        }
        return text;
    }

    /**
     * Converts the trillions block of a number to words. 
     */
    private String ConvertTrillion(long number) 
    {
        String text = "";
        if(number % 1000000000000 == 0) {
            text += this.ConvertSection(this.GetTrillions(number)) + " TRILLION";
        } else {
            if(this.GetTrillions(number) != 0) {
                text += this.ConvertSection(this.GetTrillions(number)) + " TRILLION, ";
            }
        }
        return text;
    }

    /* Convert a three digit number to words. 
     * This method can be reused for thousands, millions etc.
     */
    public string ConvertSection(long section)
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
    private string ConvertTens(long number)
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
    private string ConvertHundreds(long number)
    {
        if(number % 100 > 0) {
            return this.words[this.GetHundredDigit(number)] + " HUNDRED AND " 
                + this.ConvertTens(this.GetTenDigit(number) + this.GetUnitDigit(number));
            
        } else {
            return this.words[this.GetHundredDigit(number)] + " HUNDRED";
        }
    }

    // Method to retrieve the unit digit in a three digit number.
    private long GetUnitDigit(long number)
    {
        return number % 10;
    }

    // Method to retrieve the tens digit in a three digit number.
    private long GetTenDigit(long number)
    {
        return (number % 100) / 10 * 10;
    }

    // Method to retrieve the hundreds digit in a three digit number.
    private long GetHundredDigit(long number)
    {
        return number / 100;
    }

    // Method to retrieve the number of thousands from any number.
    private long GetThousands(long number)
    {
        return (number % 1000000) / 1000;
    }

    // Method to retrieve the number of millions from any number.
    private long GetMillions(long number)
    {
        return (number % 1000000000) / 1000000;
    }

    // Method to retrieve the number of billions from any number.
    private long GetBillions(long number)
    {
        return (number % 1000000000000) / 1000000000;
    }

    // Method to retrieve the number of trillions from any number.
    private long GetTrillions(long number)
    {
        return (number % 1000000000000000) / 1000000000000;
    }
}