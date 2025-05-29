using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Demo2.Data;
using Demo2.Models;

namespace Demo2.Controllers;

public class BooksOdataController : ODataController
{
    private readonly LibraryContext _context;

    public BooksOdataController(LibraryContext context)
    {
        _context = context;
    }

    [EnableQuery]
    public IQueryable<Book> Get()
    {
        return _context.Books;
    }
}
