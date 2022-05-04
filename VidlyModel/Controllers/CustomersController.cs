using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyModel.Context;
using VidlyModel.Models;
using VidlyModel.ViewModels;

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

    public ActionResult New()
    {
        var membershipTypes = _context.MembershipTypes.ToList();
        var viewModel = new CustomerFormViewModel()
        {
            Customer = new Customer(),
            MembershipTypes = membershipTypes
        };
        return View("CustomerForm", viewModel);
    }

    public Task<ViewResult> Index()
    {
        return Task.FromResult(View());
    }

    public ActionResult Details(int id)
    {
        var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
        ;
        if (customer == null)
            return StatusCode(418); //HTTP not found

        return View(customer);
    }

    [HttpPost]
    public async Task<IActionResult> Save(Customer customer)
    {
        // if (!ModelState.IsValid)
        // {
        //     var viewModel = new CustomerFormViewModel()
        //     {
        //         Customer = customer,
        //         MembershipTypes = await _context.MembershipTypes.ToListAsync()
        //     };
        //
        //     return View("CustomerForm", viewModel);
        // }
        
        if (customer.Id == 0)
            await _context.Customers.AddAsync(customer);
        else
        {
            var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Customers");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
        if (customer == null)
            return StatusCode(418); //HTTP not found

        var viewModel = new CustomerFormViewModel()
        {
            Customer = customer,
            MembershipTypes = await _context.MembershipTypes.ToListAsync()
        };

        return View("CustomerForm", viewModel);
    }
}