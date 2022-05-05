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
            .AddRoles<VidlyIdentityRole>()
            .AddEntityFrameworkStores<VidlyDbContext>();

        serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        serviceCollection.AddAuthorization(options =>
        {
            options.AddPolicy("CanManageMovies",
                policy => policy.RequireRole("CanManageMovies"));
        });

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
        

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication(); ;
        app.UseAuthorization();
        app.MapRazorPages();


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    }
}