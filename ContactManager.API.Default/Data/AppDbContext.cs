namespace ContactsManager.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var fakeData = Contact.FakeData.Generate(10).ToList();

        foreach (var fake in fakeData)
        {
            modelBuilder.Entity<Contact>().HasData(new Contact()
            {
                Id = Guid.NewGuid(),
                FirstName = fake.FirstName,
                LastName = fake.LastName,
                FullName = $"{fake.FirstName} {fake.LastName}",
                Email = fake.Email,
                Phone = fake.Phone,
                ZipCode = fake.ZipCode,
                Country = fake.Country,
                State = fake.State,
                City = fake.City,
                StreetName = fake.StreetName,
            });
        }
    }
}

