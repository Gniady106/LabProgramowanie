using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleCalculator.Models;

namespace SimpleCalculator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Age(DateTime birth, DateTime future)
    {

        ViewBag.birth = birth;
        ViewBag.future = future;
        
        
        if (birth > future)
        {
            ViewBag.DataPrzyszlosci = "Nie możesz być z przyszłości";
            return View("CustomErrorAge");
            
        }

        var dni = (future - birth).Days;
        ViewBag.Age = dni / 365;
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }

    public IActionResult Calculator(Operator? op, double? a, double? b)
    {
        // var op = Request.Query["op"];
        // var a = double.Parse(Request.Query["a"]);
        // var b = double.Parse(Request.Query["b"]);

        if (a is null || b is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby w parametrze a lub b!";
            return View("CustomError");
        }
        if (op is null)
        {
            ViewBag.ErrorMessage = "Nieznany operator";
            return View("CustomError");   
        }
        
        
        ViewBag.A = a;
        ViewBag.B = b;
        
        switch (op)
        {
            case Operator.add:
                ViewBag.Result = a + b;
                ViewBag.Operator = "+";
                break;
            case Operator.sub:
                ViewBag.Result = a - b;
                ViewBag.Operator = "-";
                break;
            case Operator.div:
                ViewBag.Result = a / b;
                ViewBag.Operator = "/";
                break;
            case Operator.mul:
                ViewBag.Result = a * b;
                ViewBag.Operator = "x";
                break;
         
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


public enum Operator
{
    
    add, sub, mul, div

}