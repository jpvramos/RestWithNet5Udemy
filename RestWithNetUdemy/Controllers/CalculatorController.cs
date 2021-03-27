using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("calculator")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    
    [HttpGet]
    [Route("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }


    [HttpGet]
    [Route("sub/{firstNumber}/{secondNumber}")]
    public IActionResult GetSub(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sub.ToString());
        }
        return BadRequest("Invalid Input");
    }
    
    [HttpGet]
    [Route("mul/{firstNumber}/{secondNumber}")]
    public IActionResult GetMul(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var mul = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(mul.ToString());
        }
        return BadRequest("Invalid Input");
    }
    
    [HttpGet]
    [Route("div/{firstNumber}/{secondNumber}")]
    public IActionResult GetDiv(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            if(ConvertToDecimal(secondNumber) == 0){
                return BadRequest("Invalid divisor");
            }

            var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(div.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet]
    [Route("mean/{firstNumber}/{secondNumber}")]
    public IActionResult GetMean(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var mean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;
            return Ok(mean.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet]
    [Route("sqrt/{firstNumber}")]
    public IActionResult GetSqrt(string firstNumber)
    {
        if (IsNumeric(firstNumber))
        {
            
            var sqrt = Math.Sqrt((double)ConvertToDecimal(firstNumber));
            return Ok(sqrt.ToString());
        }
        return BadRequest("Invalid Input");
    }


    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;
        if(decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }
        return 0;
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber, 
            System.Globalization.NumberStyles.Any, 
            System.Globalization.NumberFormatInfo.InvariantInfo, 
            out number);
        return isNumber;
    }
}