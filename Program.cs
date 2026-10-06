var builder = WebApplication.CreateBuilder(args);

// 1. Add API controllers only
builder.Services.AddControllers();

// 2. Configure CORS for Angular dev server
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // <-- References Angular's port
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();

// UseCors must be placed between UseRouting and UseAuthorization
app.UseCors("AllowAngularDev");

app.UseAuthorization();

// Map attribute-routed API controllers (e.g. [Route("api/[controller]")])
app.MapControllers();

app.MapGet("/", () => Results.Ok("ASP.NET Core Web API is running!"));

app.Run();