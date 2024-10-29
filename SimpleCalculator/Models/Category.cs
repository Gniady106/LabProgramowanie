using System.ComponentModel.DataAnnotations;

namespace SimpleCalculator.Models;

public enum Category
{
    [Display(Name = "Rodzina", Order = 1)]
    Family,
    [Display(Name = "Przyjaciel", Order = 3)]
    Friend,
    [Display(Name = "Kontakt zawodowy",Order = 2) ]
    Buisness
    
}