using Microsoft.EntityFrameworkCore;

namespace PhoneBook;

internal class ContactContext: DbContext
{
    public DbSet<Contact> Contacts { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=PhoneBookDB;Integrated Security = true;TrustServerCertificate=True");
    }
}
