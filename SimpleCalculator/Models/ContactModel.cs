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
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Proszę wpisać swoje Nazwisko")]
    [MaxLength(length:50, ErrorMessage = "Imię nie może być dłuższe niż 20 znaków")]
    public string LastName { get; set; }
    
    [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
    [Required(ErrorMessage ="Proszę podać poprawny eamil!")]
    public string Email { get; set; }
    
    
    
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    
    
    
  
    
    
    
    [Phone]
    [RegularExpression("\\d\\d\\d \\d\\d\\d \\d\\d\\d", ErrorMessage = "Wpisz numer wg wzoru: xxx xxx xxx")]
    public string PhoneNum { get; set; }
}