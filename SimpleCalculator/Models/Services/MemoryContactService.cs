namespace SimpleCalculator.Models.Services;

public class MemoryContactService : IContactService, IDataTimeProvider
{
    private Dictionary<int, ContactModel> _items = new()
    {
        
        {1, new ContactModel(){Id = 1,Category = Category.Buisness, Name = "Michal", LastName = "Skrzynka", Email = "michal@glkkkk.pl",BirthDate = new DateOnly(2004,11,21), PhoneNum = "999 999 999"}},
        {2, new ContactModel(){Id = 2,Name = "Kamil", Category = Category.Buisness, LastName = "Krawiec", Email = "michal@kkkkk.pl",BirthDate = new DateOnly(2002,12,22), PhoneNum = "998 998 998"}},
        {3, new ContactModel(){Id = 3,Name = "Jakob", Category = Category.Buisness,LastName = "Kowal", Email = "michal@jkkkkk.pl",BirthDate = new DateOnly(2004,10,23), PhoneNum = "997 997 997"}}
        
    };

    
    
    
    public int Add(ContactModel item)
    {
        int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
        item.Id = id + 1;
        item.Created = CurrentTime();
        _items.Add(item.Id, item);
        return item.Id;
    }

    public void Update(ContactModel item)
    {
        _items[item.Id] = item;
    }

    


    public void Delete(int id)
    {
        _items.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _items.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        return _items[id];
    }


    public DateTime CurrentTime()
    {
        return DateTime.Now;
    }
}