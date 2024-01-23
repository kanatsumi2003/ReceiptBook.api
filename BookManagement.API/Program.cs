using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Services;
using DataAccessLayer;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddEndpointsApiExplorer();
        services.AddControllers();
        services.AddSwaggerGen();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        });
    }
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services);
        // Add services to the container.
        builder.Services.AddDbContext<UserContext>(options
           => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }
        app.UseCors("AllowOrigin");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}