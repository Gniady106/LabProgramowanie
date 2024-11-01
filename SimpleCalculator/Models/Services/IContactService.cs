namespace SimpleCalculator.Models.Services;

public interface IContactService
{
    
    int Add(ContactModel model);
    void Update(ContactModel model);
    void Delete(int id);
    List<ContactModel> GetAll();
    ContactModel? GetById(int id);
    


}