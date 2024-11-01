using Microsoft.AspNetCore.Mvc;
using SimpleCalculator.Models;
using SimpleCalculator.Models.Services;

namespace SimpleCalculator.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;
    private readonly IDataTimeProvider _timeProvider;
    
   
  
    public ContactController(IContactService contactService, IDataTimeProvider timeProvider)
    {
        _contactService = contactService;
        _timeProvider = timeProvider;
    }
   
    
    public IActionResult Index()
    {
        return View(_contactService.GetAll());
    }
    
    

    //Usunięcie odpowieniego wpisu
    public IActionResult Delete(int id)
    {
        _contactService.Delete(id);
        
        return View("Index", _contactService.GetAll());
    }

    public IActionResult Details(int id)
    {
     
            var contact = _contactService.GetById(id);
            return View(contact);
        
    
        
    }
    
    
    
     [HttpGet]
     public IActionResult Edit(int id)
     {
                
             var contact = _contactService.GetById(id);
             return View(contact);
             
         
     }


     [HttpPost]
     public IActionResult Edit(ContactModel model)
     {
         if (ModelState.IsValid)
         {
             _contactService.Update(model);
             return RedirectToAction("Index");
         }
         else
         {
             return View(model);
         }
         
     }
    
    
    
    
    
    
    

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    
    

    [HttpPost]
    public IActionResult Create(ContactModel model)
    {
        if (ModelState.IsValid)
        {
            _contactService.Add(model);
            return RedirectToAction("Index");
        }
        else
        {
            return View(model);
        }
    }
    
    
    
    
    
    
}