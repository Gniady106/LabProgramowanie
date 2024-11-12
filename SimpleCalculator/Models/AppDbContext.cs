using Microsoft.EntityFrameworkCore;

namespace SimpleCalculator.Models;



public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }

    private string DbPath { get; set; }
    
    
    
    
    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "contacts.db");
        
        


    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>().HasData(new ContactEntity()
        {
            Id = 4, Name = "Darek", LastName = "Kowal", Email = "michal@gmail.pl", BirthDate = new(2000, 10, 10),
            PhoneNum = "123123123"
        });
    }
}