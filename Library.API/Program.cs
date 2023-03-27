using Library.Application.Dtos.AuthorDto;
using Library.Persistance.DB;
using Library.Persistance.Implementations;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Repositories.Author2BookRepository;
using WebApiProject.Repositories.AuthorRepository;
using WebApiProject.Repositories.BookRepository;
using WebApiProject.Repositories.LibraryRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"),
         b => b.MigrationsAssembly("Library.API")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthor2BookRepository, Author2BookRepository>();
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddAutoMapper(typeof(BaseAuthorDto).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
