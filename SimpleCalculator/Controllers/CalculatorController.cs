using Microsoft.AspNetCore.Mvc;

namespace SimpleCalculator.Controllers;

public class CalculatorController : Controller
{
    // GET

    [HttpGet("/calculate")]
    public IActionResult Calculate(int num1, int num2)
    {
        int result = num1 + num2;
        return Content($"Result is: {result}");
    }
}
// http://localhost:5000/calculate?num1=10&num2=5