using ContactsManager.Apis.v1.Interfaces;
using ContactsManager.Data;
using ContactsManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Tests;

[TestClass]
public class ContactAPITest
{
    private readonly Mock<IContactApi> _mock;
    private readonly AppDbContext _context;

    public ContactAPITest()
    {
        _mock = new Mock<IContactApi>();
        _context = GetDatabaseContext();
    }

    [TestMethod]
    public void Get_All_Contacts_Return_Is_Not_Null()
    {
        // arrange
        var contacts = CreateContact().ToList();

        _mock.Setup(m => m.Get(_context)).Returns(Results.Ok(contacts));

        // act
        var result = _mock.Object.Get(_context);

        // assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Get_Contact_By_Id_Return_Is_Not_Null()
    {
        // arrange
        var contact = CreateContact().FirstOrDefault();

        _mock.Setup(m => m.GetById(contact.Id, _context)).Returns(Results.Ok(contact));

        // act
        var result = _mock.Object.GetById(contact.Id, _context);

        // assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Create_Contact_Is_Not_Null()
    {
        // arrange
        var contact = CreateContact().FirstOrDefault();

        _mock.Setup(m => m.Post(contact, _context)).Returns(Results.Ok(contact));

        // act
        var result = _mock.Object.Post(contact, _context);

        // assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Update_Contact_Is_Not_Null()
    {
        // arrange
        var contact = CreateContact().FirstOrDefault();

        _mock.Setup(m => m.Put(contact.Id, contact, _context)).Returns(Results.NoContent);

        // act
        var result = _mock.Object.Put(contact.Id, contact, _context);

        // assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Delete_Contact_Is_Not_Null()
    {
        // arrange
        var contact = CreateContact().FirstOrDefault();

        _mock.Setup(m => m.Delete(contact.Id, _context)).Returns(Results.NoContent);

        // act
        var result = _mock.Object.Delete(contact.Id, _context);

        // assert
        Assert.IsNotNull(result);
    }

    public IEnumerable<Contact> CreateContact()
    {
        yield return new Contact(
                                 Guid.NewGuid(),
                                 "Thad",
                                 "Moises",
                                 "Thad Moises",
                                 "Thad_Moises@hotmail.com",
                                 "(208)-626-9720",
                                 "08229",
                                 "Virgin Islands, British",
                                 "Wyoming",
                                 "Lake Norwoodfurt",
                                 "America Dam");
    }

    public AppDbContext GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Data Source=contacts.db")
            .Options;

        var databaseContext = new AppDbContext(options);

        databaseContext.Database.EnsureCreated();

        return databaseContext;
    }
}
