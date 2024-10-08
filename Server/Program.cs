using Microsoft.EntityFrameworkCore;
using IrepoQuizAppp.Services;
using IrepoQuizAppp.Model;
using IrepoQuizAppp.Factories; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(sp => new FileRepository<QuizQuestion>("C://Users//abhishekwas//Desktop//question23.json"));
builder.Services.AddScoped(typeof(DatabaseRepository<QuizQuestion>)); 
builder.Services.AddScoped<RepositoryFactory>(); 

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var repository = services.GetRequiredService<DatabaseRepository<QuizQuestion>>();
//    await repository.AddSampleDataAsync();
//}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
