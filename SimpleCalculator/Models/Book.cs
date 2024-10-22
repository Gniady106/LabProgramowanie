using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SimpleCalculator.Models;

public class Book
{
    
    [HiddenInput]
    public int Id { get; set; }
    
    
    [Required(ErrorMessage ="Proszę podać tytuł książki!")]
    public string Title { get; set; }
    
    [Required(ErrorMessage ="Proszę podać imię autora!")]
    public string Author { get; set; }

    public int PagesNum { get; set; }

    [MaxLength(length:13, ErrorMessage ="Wiadomość musi mieć co najmniej 5 znaków!")]
    [MinLength(length:10, ErrorMessage ="Wiadomość musi mieć co najmniej 5 znaków!")]
    [Required(ErrorMessage ="Proszę wpisz ISBN")]
    public string ISBN { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    
    [Required(ErrorMessage ="Proszę podać imię autora!")]
    public string Publisher { get; set; }
    // tytuł, autor, lizba stron, ISBN, rok wydania, wydawnictwo
}