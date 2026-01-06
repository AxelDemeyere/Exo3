using System.ComponentModel.DataAnnotations;

namespace Exo3.Models;

public class ContactViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Le nom est requis")]
    [Display(Name = "Nom")]
    public string Name { get; set; } = "";
    
    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "L'e-mail est requis")]
    [EmailAddress] 
    public string Email { get; set; } = "";
    
    private static List<ContactViewModel> _contacts = new List<ContactViewModel>
    {
        new ContactViewModel(1, "Alice Smith", "alice.smith@gmail.com"),
        new ContactViewModel(2, "Bob Johnson", "bob.johnson@gmail.com"),
        new ContactViewModel(3, "Charlie Brown", "charlie.brown@gmail.com"),
    };
    
    public ContactViewModel() {}
    public ContactViewModel(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public static List<ContactViewModel> GetAllContacts()
    {
        return _contacts;
    }
}