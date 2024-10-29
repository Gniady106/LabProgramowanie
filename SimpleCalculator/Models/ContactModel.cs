using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;

namespace SimpleCalculator.Models;

public class ContactModel
{
    
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Proszę wpisać swoje imię")]
    [MaxLength(length:20, ErrorMessage = "Imię nie może być dłuższe niż 20 znaków")]
    [MinLength(length:2, ErrorMessage = "Imię nie może być krótsze niż 2 znaki")]
    [RegularExpression(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ]+$", ErrorMessage = "Imię może zawierać tylko litery")]
    [Display(Name = "Imię")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Proszę wpisać swoje Nazwisko")]
    [MaxLength(length:50, ErrorMessage = "Imię nie może być dłuższe niż 20 znaków")]
    [RegularExpression(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ]+$", ErrorMessage = "Nazwisko może zawierać tylko litery")]
    [Display(Name = "Nazwisko")]
    public string LastName { get; set; }
    
    [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
    [Required(ErrorMessage ="Proszę podać poprawny eamil!")]
    [Display(Name = "Adres email")]
    public string Email { get; set; }
    
    
    [Display(Name = "Data urodzenia")]
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }
    
    [Display(Name = "Kategoria")]
    public Category Category { get; set;}
    
    
    
  
    
    
    [Display(Name = "Numer telefonu")]
    [Phone(ErrorMessage = "Proszę wpisać poprawny numer telefonu.")]
    [RegularExpression("\\d\\d\\d \\d\\d\\d \\d\\d\\d", ErrorMessage = "Wpisz numer wg wzoru: xxx xxx xxx")]
    public string PhoneNum { get; set; }
}