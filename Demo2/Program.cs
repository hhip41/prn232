using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Demo2.Data;
using Demo2.Models;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình InMemory Database
builder.Services.AddDbContext<LibraryContext>(opt =>
    opt.UseInMemoryDatabase("LibraryDb"));

// Cấu hình Entity Data Model (EDM) cho OData
var edmBuilder = new ODataConventionModelBuilder();
edmBuilder.EntitySet<Book>("BooksOdata");
edmBuilder.EntitySet<Press>("PressesOdata");

// Cấu hình OData
builder.Services.AddControllers()
    .AddOData(opt => opt
        .AddRouteComponents("odata", edmBuilder.GetEdmModel())
        .Select().Filter().Expand().Count().OrderBy().SetMaxTop(100).SkipToken());

// Cấu hình Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Bật Swagger UI khi ở chế độ Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
