using Microsoft.AspNetCore.Mvc;
using SimpleCalculator.Models;

namespace SimpleCalculator.Controllers;

public class BirthController : Controller
{
    // GET
    public IActionResult BirthForm()
    {
        return View();
    }


    public IActionResult BirthResult(Birth model)
    {
        if (!model.IsValid())
        {
            return View("Error");

        }

        return View("BirthResult", model);
    }
}