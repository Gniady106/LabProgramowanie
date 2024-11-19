using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleCalculator.Models;

namespace SimpleCalculator;

public class AppDbContext: IdentityDbContext<IdentityUser>
{
    public DbSet<ContactEntity> Contacts { get; set; }

    public DbSet<OrganizationEntity> Organizations { get; set; }
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
        base.OnModelCreating(modelBuilder);
        string USER_ID = Guid.NewGuid().ToString();
        string ADMIN_ID = Guid.NewGuid().ToString();
        string USER_ROLE_ID = Guid.NewGuid().ToString();
        string ADMIN_ROLE_ID = Guid.NewGuid().ToString();

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Id = USER_ROLE_ID,
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = USER_ROLE_ID
            },
            new IdentityRole()
            {
                Id = ADMIN_ROLE_ID,
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = ADMIN_ROLE_ID
                
        }
            

        );

        var user = new IdentityUser()
        {
            Id = USER_ID,
            Email = "michal@gmd.pl",
            NormalizedEmail = "MICHAL@GMD.PL",
            UserName = "Michal",
            NormalizedUserName = "MICHAL",
            EmailConfirmed = true
        };

        var admin = new IdentityUser()
        {
            Id = ADMIN_ID,
            Email = "patryk@gmd.pl",
            NormalizedEmail = "PATRYK@GMD.PL",
            UserName = "Patryk",
            NormalizedUserName = "PATRYK",
            EmailConfirmed = true
        };
        
        PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
       user.PasswordHash = hasher.HashPassword(user, "1234!");
        admin.PasswordHash = hasher.HashPassword(admin, "!4321");
        modelBuilder.Entity<IdentityUser>().HasData(user, admin);


        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>()
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            },
            new IdentityUserRole<string>()
            {
                RoleId = USER_ROLE_ID,
                UserId = ADMIN_ID
            },
            new IdentityUserRole<string>()
            {
                RoleId = USER_ROLE_ID,
                UserId = USER_ID
            }


        );
        
        modelBuilder.Entity<OrganizationEntity>().OwnsOne(e => e.Address)
            .HasData(
                new{OrganizationEntityId =101,City="Kraków",Street="św. Silipa17"},
                new{OrganizationEntityId =102,City="Warszawa",Street="Dworcowa 9"});
        
        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organization")
            .HasData(
            new OrganizationEntity
            {
                Id = 101,
                Name = "Wsei",
                NIP="283792834",
                Region = "2427381273"
            },
            new OrganizationEntity
            {
                Id = 102,
                Name = "PKP",
                NIP="2834792834",
                Region = "2422181273"
            }
            
            
            );
        modelBuilder.Entity<ContactEntity>()
            .HasOne<OrganizationEntity>(c=>c.Organization)
            .WithMany(o=>o.Contacts)
            .HasForeignKey(c=>c.OrganizationId);
        modelBuilder.Entity<ContactEntity>()
            .HasData(
            new ContactEntity()
            {
                Id = 1,
                Name = "Patrick",
                LastName = "Nowak",
                BirthDate = new(2000, 10, 10),
                PhoneNum = "666666666",
                Email = "patryk@o2.pl",
                Created = DateTime.Now,
                OrganizationId = 101
            }, new ContactEntity(){
                Id = 2,
                Name = "Michał",
                LastName = "Kowalski",
                BirthDate = new(2003, 09, 09),
                PhoneNum = "666666666",
                Email = "patryk@o2.pl",
                Created = DateTime.Now,
                OrganizationId = 102
            }
            );
    }
}