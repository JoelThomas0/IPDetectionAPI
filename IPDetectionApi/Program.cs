var builder = WebApplication.CreateBuilder(args);

// Add services for controllers
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

// Map controller routes (important!)
app.MapControllers();

app.Run();
