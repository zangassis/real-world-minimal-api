namespace ContactsManager.Models;

public record class Contact
{
    public Contact()
    {

    }

    public Contact(Guid id,
        string firstName, 
        string lastName, 
        string fullName, 
        string email, 
        string phone,
        string zipCode,
        string country,
        string state,
        string city, 
        string streetName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        FullName = fullName;
        Email = email;
        Phone = phone;
        ZipCode = zipCode;
        Country = country;
        State = state;
        City = city;
        StreetName = streetName;  
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string StreetName { get; set; }

    public static Faker<Contact> FakeData { get; } =
        new Faker<Contact>()
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.FirstName())
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.FirstName, c.LastName))
                .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber("(###)-###-####"))
                .RuleFor(c => c.ZipCode, f => f.Address.ZipCode())
                .RuleFor(c => c.Country, f => f.Address.Country())
                .RuleFor(c => c.State, f => f.Address.State())
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.StreetName, f => f.Address.StreetName());
}

