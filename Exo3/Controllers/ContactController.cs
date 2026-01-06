using Exo3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exo3.Controllers;

public class ContactController : Controller
{
    private readonly ILogger<ContactController> _logger;

    public ContactController(ILogger<ContactController> logger)
    {
        _logger = logger;
    }

    public IActionResult Contacts()
    {
        var contacts = ContactViewModel.GetAllContacts();
        return View(contacts);
    }

    public IActionResult Contact(int id)
    {
        var contacts = ContactViewModel.GetAllContacts();
        var contact = contacts.FirstOrDefault(c => c.Id == id);
        
        if (contact == null)
        {
            return NotFound();
        }
        
        return View(contact);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ContactViewModel contact)
    {
        if (!ModelState.IsValid) return View(contact);
        
        var contacts = ContactViewModel.GetAllContacts();
        contact.Id = contacts.Any() ? contacts.Max(c => c.Id) + 1 : 1;
        
        contacts.Add(contact);
        return RedirectToAction("Contacts");
    }
}