namespace ContactsManager.Apis.v1;

public class ContactApi : Interfaces.IContactApi
{
    private readonly ILogger<ContactApi> _logger;

    public ContactApi(ILogger<ContactApi> logger)
    {
        _logger = logger;
    }

    public void Register(WebApplication app)
    {
        app.MapGet("/v1/contacts", Get);
        app.MapGet("/v1/contacts/{id}", GetById);
        app.MapPost("/v1/contacts", Post).Produces<Contact>(StatusCodes.Status201Created);
        app.MapPut("/v1/contacts/{id}", Put).Produces(StatusCodes.Status404NotFound).Produces(StatusCodes.Status204NoContent);
        app.MapDelete("/v1/contacts/{id}", Delete).Produces(StatusCodes.Status204NoContent);
    }

    public IResult Get(AppDbContext context) =>
        Results.Ok(context.Contacts);

    public IResult GetById(Guid id, AppDbContext context)
    {
        var contact = context.Contacts.FirstOrDefault(x => x.Id == id);

        if (contact is null)
        {
            ContactNotFoundLog(id, "GetById");
            return Results.NotFound();
        }

        return Results.Ok(contact);
    }

    public IResult Post(Contact contact, AppDbContext context)
    {
        try
        {
            context.Add(contact);
            context.SaveChanges();

            _logger.LogInformation("Contact inserted successfully", nameof(Post));
            return Results.Created($"/contact/{contact.Id}", contact);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error ocurred while posting to Contact: {ex.Message}", nameof(Post));
            return Results.BadRequest($"Error ocurred while posting to Contact: {ex.Message}");
        }
    }

    public IResult Put(Guid id, Contact updateContact, AppDbContext context)
    {
        try
        {
            var contact = context.Contacts.Find(id);

            if (contact is null)
            {
                ContactNotFoundLog(id, "Put");
                return Results.NotFound();
            }

            context.Entry(contact).CurrentValues.SetValues(updateContact);

            context.SaveChanges();

            _logger.LogInformation("Contact updated successfully", nameof(Put));
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Error ocurred while puting to Contact: {ex.Message}");
        }
    }

    public IResult Delete(Guid id, AppDbContext context)
    {
        var contact = context.Contacts.Find(id);

        if (contact is null) 
        {
            ContactNotFoundLog(id, "Delete");
            return Results.NotFound();
        }

        context.Contacts.Remove(contact);

        context.SaveChangesAsync();

        _logger.LogInformation("Contact deleted successfully");
        return Results.NoContent();
    }

    private void ContactNotFoundLog(Guid id, string methodName) =>
        _logger.LogError($"Contact not found to id: {id} - [{methodName}]");
    
}

