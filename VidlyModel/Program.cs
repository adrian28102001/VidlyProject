using VidlyModel.Context;
using VidlyModel.Models;

var builder = WebApplication.CreateBuilder(args);

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
//     var customer = db.Set<Customer>();
//     customer.Add(new Customer { Name = "Adrian", Birthdate = new DateTime(2008, 3, 9), MembershipTypeId = 1,IsSubscribedToNewsletter = false,});
//     customer.Add(new Customer { Name = "George", Birthdate = new DateTime(2009, 3, 9), MembershipTypeId = 2,IsSubscribedToNewsletter = false,});
//
//     db.SaveChanges();
// }
// using (var db = new VidlyDbContext())
// {
//     var type = db.Set<MembershipType>();
//     type.Add(new MembershipType {Id = 1, Name = "Pay as You Go", DiscountRate = 0, DurationInMonth = 0,SignUpFee = 0});
//     type.Add(new MembershipType {Id = 2, Name = "Monthly", DiscountRate = 10, DurationInMonth = 1,SignUpFee = 30});
//     type.Add(new MembershipType {Id = 3,Name = "Quarterly", DiscountRate = 15,DurationInMonth = 3,SignUpFee = 90});
//     type.Add(new MembershipType {Id = 4, Name = "Annual", DiscountRate = 20,DurationInMonth = 12,SignUpFee = 300});
//
//     db.SaveChanges();
// }
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();