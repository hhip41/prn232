using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using ODataDemo.Data;
using ODataDemo.Models;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình DbContext dùng SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Tạo mô hình OData EDM
var odataBuilder = new ODataConventionModelBuilder();
odataBuilder.EntitySet<Gadget>("Gadgets");

// Đăng ký dịch vụ OData với các query option
builder.Services.AddControllers().AddOData(opt =>
    opt.Select()
        .Filter()
        .Count()
        .OrderBy()
        .Expand()
        .SetMaxTop(100)
        .AddRouteComponents("odata", odataBuilder.GetEdmModel()));

// Thêm Swagger (tùy chọn)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Tạo DB và thêm dữ liệu mẫu nếu chưa có
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    if (!db.Gadgets.Any())
    {
        db.Gadgets.AddRange(
            new Gadget { ProductName = "iPhone 15", Cost = 999 },
            new Gadget { ProductName = "Samsung Galaxy", Cost = 899 },
            new Gadget { ProductName = "Google Pixel", Cost = 799 }
        );
        db.SaveChanges();
    }
}

// Cấu hình middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
