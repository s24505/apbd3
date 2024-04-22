using apbd3.Repositiories;
using apbd3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container./ Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddXmlSerializerFormatters();

builder.Services.AddScoped<IAnimalsService, AnimalsService>();
builder.Services.AddScoped<IAnimalsRepository, AnimalsRepository>();

//GET api/students
//new StudentController(new StudentService(new StudentREpository));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();