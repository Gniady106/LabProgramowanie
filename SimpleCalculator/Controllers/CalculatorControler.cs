using Microsoft.AspNetCore.Mvc;
using SimpleCalculator.Models;

namespace SimpleCalculator.Controllers;

public class CalculatorController : Controller
{
    // GET
    
    
    [HttpPost]
    public IActionResult Result([FromForm] Calculator model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }
    
    // public IActionResult Result(Calculator model)
    // {
    //     if (!model.IsValid())
    //     {
    //         return View("Error");
    //     }
    //     return View(model);
    // }
        
        // public IActionResult Result(Op? op, double? a, double? b)
        // {
        //     // var op = Request.Query["op"];
        //     // var a = double.Parse(Request.Query["a"]);
        //     // var b = double.Parse(Request.Query["b"]);
        //
        //     if (a is null || b is null)
        //     {
        //         ViewBag.ErrorMessage = "Niepoprawny format liczby w parametrze a lub b!";
        //         return View("CustomError");
        //     }
        //     if (op is null)
        //     {
        //         ViewBag.ErrorMessage = "Nieznany operator";
        //         return View("CustomError");   
        //     }
        //
        //
        //     ViewBag.A = a;
        //     ViewBag.B = b;
        //
        //     switch (op)
        //     {
        //         case Op.add:
        //             ViewBag.Result = a + b;
        //             ViewBag.Operator = "+";
        //             break;
        //         case Op.sub:
        //             ViewBag.Result = a - b;
        //             ViewBag.Operator = "-";
        //             break;
        //         case Op.div:
        //             ViewBag.Result = a / b;
        //             ViewBag.Operator = "/";
        //             break;
        //         case Op.mul:
        //             ViewBag.Result = a * b;
        //             ViewBag.Operator = "x";
        //             break;
        //  
        //     }
        //     return View();
        // }

        public IActionResult Form()
        {
            return View();
        }
        
        // public enum Op
        // {
        //
        //     add, sub, mul, div
        //
        // }
        
        
        
        
        
    
}