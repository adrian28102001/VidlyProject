using Microsoft.EntityFrameworkCore;
using VidlyModel.Areas.Identity.Data;
using VidlyModel.Context;

namespace VidlyModel;

public class Startup
{
    private readonly ConfigurationManager _configurationManager;

    public Startup(ConfigurationManager configurationManager)
    {
        _configurationManager = configurationManager;
    }

    public void ConfigureServices(IServiceCollection serviceCollection)
    {
        var connectionString = _configurationManager.GetConnectionString("DefaultConnection");

        serviceCollection.AddDbContext<VidlyDbContext>(options =>
            options.UseSqlServer(connectionString));

        serviceCollection.AddDefaultIdentity<VidlyIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<VidlyDbContext>();
        serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        serviceCollection.AddControllersWithViews();
    }

    public void ConfigurePipeline(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

// using (var db = new VidlyDbContext())
// {
//     var movie = db.Set<Movie>();
//     movie.Add(new Movie {Name = "Movie1", DateAdded = DateTime.Now, GenreId = 1, ReleaseDate = DateTime.Today, NumberInStock = 2});
//     movie.Add(new Movie {Name = "Movie2", DateAdded = DateTime.Now, GenreId = 2, ReleaseDate = DateTime.Today, NumberInStock = 4});
//     movie.Add(new Movie {Name = "Movie3", DateAdded = DateTime.Now, GenreId = 3, ReleaseDate = DateTime.Today, NumberInStock = 3});
//     movie.Add(new Movie {Name = "Movie4", DateAdded = DateTime.Now, GenreId = 4, ReleaseDate = DateTime.Today, NumberInStock = 1});
//     db.SaveChanges();
// }

// using (var db = new VidlyDbContext())
// {
//     var customer = db.Set<Customer>();
//     customer.Add(new Customer { Name = "Adrian", Birthdate = new DateTime(2008, 3, 9), MembershipTypeId = 1,IsSubscribedToNewsletter = false,});
//     customer.Add(new Customer { Name = "George", Birthdate = new DateTime(2009, 3, 9), MembershipTypeId = 2,IsSubscribedToNewsletter = false,});
//
//     db.SaveChanges();
// }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        ;
        app.UseAuthorization();
        app.MapRazorPages();


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    }
}