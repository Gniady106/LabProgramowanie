using Microsoft.AspNetCore.Mvc;
using SimpleCalculator.Models;

namespace SimpleCalculator.Controllers;

public class BookController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Create(){
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Book contact)
    {
        if (ModelState.IsValid)
        {

            return View();
            //kod wykonywany gdy dane są poprawne
        } else {
    	return View(); // ponowne wyświetlenie formularza z informacjami o błędach
        }
    }

}