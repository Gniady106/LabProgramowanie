namespace SimpleCalculator.Models;

public class ContactMapper
{
    public static ContactEntity ToEntity(ContactModel model)
    {
        return new ContactEntity()
        {
            Id = model.Id,
            Name = model.Name,
            LastName = model.LastName,
            BirthDate = model.BirthDate,
            Email = model.Email,
            PhoneNum = model.PhoneNum,
            Category = model.Category,
            Organization = model.Organization,
            OrganizationId = model.OrganizationId
        };
    }

    public static ContactModel FromEntity(ContactEntity entity)
    {
        return new()
        {
            Id = entity.Id,
            Name = entity.Name,
            LastName = entity.LastName,
            BirthDate = entity.BirthDate,
            Email = entity.Email,
            PhoneNum = entity.PhoneNum,
            Category = entity.Category,
            Organization = entity.Organization,
            OrganizationId = entity.OrganizationId
        };
    }
    
    
    
    
    
    
}