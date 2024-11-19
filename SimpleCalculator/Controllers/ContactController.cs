using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
             contact.Organizations = _contactService.GetOrganizations()
                 .Select(o => new SelectListItem { Value = o.Id.ToString(), Text = o.Name }).ToList();
             
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
    [Authorize]
    public IActionResult Create()
    {
        var model = new ContactModel();
        model.Organizations = _contactService.GetOrganizations()
            .Select(i => new SelectListItem()
            {
                Value = i.Id.ToString(),
                Text = i.Name,
                Selected = i.Id == 1

            }).ToList();
        
        return View(model);
    }
    
    
    

    [HttpPost]
    [Authorize]
    public IActionResult Create(ContactModel model)
    {
        if (ModelState.IsValid)
        {
            _contactService.Add(model);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View(model);
        }
    }
    
    
    
    
    
    
}