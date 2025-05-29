using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataDemo.Data;
using ODataDemo.Models;

namespace ODataDemo.Controllers
{
    public class GadgetsController : ODataController
    {
        private readonly AppDbContext _context;
        public GadgetsController(AppDbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Gadget> Get()
        {
            return _context.Gadgets;
        }
    }
}
