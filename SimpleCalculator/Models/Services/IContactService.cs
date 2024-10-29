namespace SimpleCalculator.Models.Services;

public interface IContactService
{
    
    void Add(ContactModel model);
    void Update(ContactModel model);
    void Delete(ContactModel model);
    List<ContactModel> GetAll();
    ContactModel? GetById(int id);

}