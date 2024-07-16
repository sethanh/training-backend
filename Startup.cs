using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = "Server=localhost;Database=mydatabase;User=esg;Password=ctnet@@1812;";
        services.AddDbContext<MyAppDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddControllers();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}