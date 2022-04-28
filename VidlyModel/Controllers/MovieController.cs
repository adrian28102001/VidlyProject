using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyModel.Context;
using VidlyModel.Models;
using VidlyModel.Pages;

namespace VidlyModel.Controllers;

public class MovieController : Controller
{
    private VidlyDbContext _context;

    public MovieController()
    {
        _context = new VidlyDbContext();
    }
    
    protected override void Dispose(bool disposing)
    {
        _context.Dispose();
    }

    public async Task<ViewResult> Index()
    {
        var movies = await _context.Movies.Include(m => m.Genre).ToListAsync();

        return View(movies);    
    }
    public ActionResult Details(int id)
    {
        var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

        if (movie == null)
            return StatusCode(418); //HTTP not found

        return View(movie);

    }
    // GET: Movies/Random
    public ActionResult Random()
    {
        var movie = new Movie() { Name = "Shrek!" };
        var customers = new List<Customer>
        {
            new Customer { Name = "Customer 1" },
            new Customer { Name = "Customer 2" }
        };

        var viewModel = new RandomMovieViewModel
        {
            Movie = movie,
            Customers = customers
        };

        return View(viewModel);
    }
}
