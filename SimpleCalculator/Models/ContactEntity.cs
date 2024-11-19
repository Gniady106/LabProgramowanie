using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCalculator.Models;

[Table("contacts")]
public class ContactEntity
{
    
    public int Id { get; set; }
    
    
    [Required]
    [MaxLength(length:20)]
    [MinLength(length:2)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(length:50)]
    
    public string LastName { get; set; }
    
    
    [Required]

    public string Email { get; set; }
    
    

    public DateOnly BirthDate { get; set; }
    
   
    public Category Category { get; set;}
    
    
    
  
    
    public DateTime Created { get; set; }
    
    [Column("phone_num")]
    public string PhoneNum { get; set; }





    public int OrganizationId { get; set; }


    public OrganizationEntity? Organization { get; set; }
    
    
    
    
}
