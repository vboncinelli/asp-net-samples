using PlayingWithActionFilters.Filters;

namespace PlayingWithActionFilters
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
           
            builder.Services.AddLogging();

            // Registering custom filters
            builder.Services.AddScoped<LoggingActionFilter>();
            builder.Services.AddScoped<ValidationActionFilter>();

            //builder.Services.AddControllersWithViews(options =>
            //{
            //    // Add LoggingActionFilter as a filter for all controllers and views
            //    options.Filters.Add<LoggingActionFilter>();
            //    // Add ValidationActionFilter as a filter for all controllers and views
            //    options.Filters.Add<ValidationActionFilter>();
            //});

            var app = builder.Build();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
