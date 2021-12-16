namespace ContactsManager.Apis.v1.Interfaces;

public interface IContactApi
{
    IResult Get(AppDbContext context);
    IResult GetById(Guid id, AppDbContext context);
    IResult Post(Contact contact, AppDbContext context);
    IResult Put(Guid id, Contact updateContact, AppDbContext context);
    IResult Delete(Guid id, AppDbContext context);
    void Register(WebApplication app);
}
