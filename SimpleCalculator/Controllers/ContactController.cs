using Microsoft.AspNetCore.Mvc;
using SimpleCalculator.Models;

namespace SimpleCalculator.Controllers;

public class ContactController : Controller
{
    // Lista kontaktów
    public IActionResult Index()
    {
        return View(_contacts);
    }
    
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        
        {1, new ContactModel(){Id = 1,Name = "Michal", LastName = "Skrzynka", Email = "michal@glkkkk.pl",BirthDate = new DateTime(2004,11,21), PhoneNum = "999 999 999"}},
        {2, new ContactModel(){Id = 2,Name = "Kamil", LastName = "Krawiec", Email = "michal@kkkkk.pl",BirthDate = new DateTime(2002,12,22), PhoneNum = "998 998 998"}},
        {3, new ContactModel(){Id = 3,Name = "Jakob", LastName = "Kowal", Email = "michal@jkkkkk.pl",BirthDate = new DateTime(2004,10,23), PhoneNum = "997 997 997"}}
        
    };

    private static int currentId = 3;

    //Usunięcie odpowieniego wpisu
    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        
        return View("Index", _contacts);
    }

    public IActionResult Details()
    {
        return View("Add");
    }
    
    
    //Edit form 
    [HttpGet]
    public IActionResult Edit(int id)
    {
        if (_contacts.Keys.Contains(id))
        {
            var contact = _contacts[id];
            return View(contact);
        }
        
        else
        {
            return NotFound();
        }
        
    }
    
    // Save przy edicie
    [HttpPost]
    public IActionResult Save(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Edit", model);
        }
        
        
        _contacts[model.Id] = model;
        
       

        return RedirectToAction("Index");
    }
    
    
    
    
    

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    
    

    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Id = ++currentId;
        _contacts.Add(model.Id, model);
        return View("Index", _contacts);
    }
    
    
    
    
    
    
}