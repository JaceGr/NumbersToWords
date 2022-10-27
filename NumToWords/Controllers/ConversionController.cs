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
        double validatedNum = double.Parse(input.inputNum);

        string text = _conversionService.ConvertNumber(validatedNum);

        ReturnTextObject output = new ReturnTextObject(text, "error");
        return output;
    }
    
    [HttpGet]
    [Route("result")]
    public ReturnTextObject Result()
    {
        double validatedNum = double.Parse("123.45");

        string text = _conversionService.ConvertNumber(validatedNum);

        ReturnTextObject output = new ReturnTextObject(text, "error");
        return output;
    }

}

public class NumberInputObject
{
    public string? inputNum { get; set; }
}

public class ReturnTextObject
{
    public string? outputText { get; set; }

    public string? error { get; set; }

    public ReturnTextObject(string outputText, string error)
    {
        this.outputText = outputText;
        this.error = error;
    }
}
