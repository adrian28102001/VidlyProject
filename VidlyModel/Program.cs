using AutoMapper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddScoped<Mapper, IMapper>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
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
app.UseAuthorization();
//Automapper


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();

