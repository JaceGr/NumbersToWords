using Microsoft.AspNetCore.Mvc;

namespace NumToWords.Controllers;

[ApiController]
[Route("[controller]")]
public class ConversionController : ControllerBase
{
    private ConversionService _conversionService = new ConversionService(); 

    
    [HttpPost]
    public ReturnTextObject Post([FromBody] NumberInputObject input)
    {
        if(input.inputNum == null) {
            return new ReturnTextObject("", "inputNum was not sent");
        }

        double validatedNum = _conversionService.ValidateNumber(input.inputNum);

        if(validatedNum < 0) {
            ReturnTextObject errorOutput = new ReturnTextObject(String.Empty, "Please enter a valid number");
            return errorOutput;
        }

        string text = _conversionService.ConvertNumber(validatedNum);

        ReturnTextObject output = new ReturnTextObject(text, String.Empty);
        return output;
    }

}

public class NumberInputObject
{
    public String? inputNum { get; set; }
}

public class ReturnTextObject
{
    public String? outputText { get; set; }

    public String? error { get; set; }

    public ReturnTextObject(String outputText, String error)
    {
        this.outputText = outputText;
        this.error = error;
    }
}
