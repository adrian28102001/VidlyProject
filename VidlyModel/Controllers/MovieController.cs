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

    public IActionResult New()
    {
        var genres = _context.Genres.ToList();
        var viewModel = new MovieFormViewModel()
        {
            Genres = genres
        };
        return View("MoviewForm", viewModel);
    }

    public IActionResult Save(Movie movie)
    {
        if (movie.Id == 0)
        {
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
        }
        else
        {
            var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
            movieInDb.Name = movie.Name;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.ReleaseDate = movie.ReleaseDate;
        }

        _context.SaveChanges();
        return RedirectToAction("Index", "Movie");
    }

    public IActionResult Edit(int id)
    {
        var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
        if (movie == null)
            return StatusCode(418);
        var viewModel = new MovieFormViewModel()
        {
            Movie = movie,
            Genres = _context.Genres.ToList()
        };
        return View("MoviewForm", viewModel);
    }
}