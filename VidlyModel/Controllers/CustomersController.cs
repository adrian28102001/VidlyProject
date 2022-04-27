using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyModel.Context;

namespace VidlyModel.Controllers;

public class CustomersController : Controller
{
    private VidlyDbContext _context;

    public CustomersController()
    {
        _context = new VidlyDbContext();
    }

    protected override void Dispose(bool disposing)
    {
        _context.Dispose();
    }
    
    public async Task<ViewResult> Index()
    {
        var customers =await _context.Customers.Include(c => c.MembershipType).ToListAsync();

        return View(customers);
    }

    public ActionResult Details(int id)
    {
        var customer = _context.Customers.SingleOrDefault(c => c.Id == id); ;
        if (customer == null)
            return StatusCode(418); //HTTP not found

        return View(customer);

    }
}