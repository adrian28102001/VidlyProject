using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyModel.Context;
using VidlyModel.Models;
using VidlyModel.Pages;

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
        var viewModel = new CustomerFromViewModel()
        {
            MembershipTypes = membershipTypes
        };
        return View("CustomerForm", viewModel);
    }

    public async Task<ViewResult> Index()
    {
        var customers = await _context.Customers.Include(c => c.MembershipType).ToListAsync();


        return View(customers);
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
    public IActionResult Save(Customer customer)
    {
        if (customer.Id == 0)
            _context.Customers.Add(customer);
        else
        {
            var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            

        }
        _context.SaveChanges();
        return RedirectToAction("Index", "Customers");
    }

    public IActionResult Edit(int id)
    {
        var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
        if (customer == null)
            return StatusCode(418); //HTTP not found

        var viewModel = new CustomerFromViewModel
        {
            Customer = customer,
            MembershipTypes = _context.MembershipTypes.ToList()
        };

        return View("CustomerForm", viewModel);
    }
}