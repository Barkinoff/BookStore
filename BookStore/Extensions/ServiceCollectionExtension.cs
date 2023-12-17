using BookStore.Data.Databases;
using BookStore.Data.IRepositories;
using BookStore.Data.Repositories;
using BookStore.Domain.Entites;
using BookStore.Service.IServices;
using BookStore.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Extensions;

public static class ServiceCollectionExtension
{

    public static void AddInjections(this IServiceCollection services) 
    {
        services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
        services.AddScoped<IGenericRepository<Book>, GenericRepository<Book>>();

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IBookService, BookService>();
    }

    public static void AddDbContextSetting(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(option =>
        option.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), op => op.MigrationsAssembly("BookStore.Data")));
    }
}
