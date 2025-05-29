using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Demo2.Data;
using Demo2.Models;

namespace Demo2.Controllers;

public class PressesOdataController : ODataController
{
    private readonly LibraryContext _context;

    public PressesOdataController(LibraryContext context)
    {
        _context = context;
    }

    [EnableQuery]
    public IQueryable<Press> Get()
    {
        return _context.Presses;
    }
}
