using Libreria.Controllers;
using Libreria.Data;
using Microsoft.EntityFrameworkCore;
using wsLibreria.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ValidarUsuario>();
builder.Services.AddTransient<ValidarLibro>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("LibreriaDb"))
);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });   
});


var app = builder.Build();
AgregarDatosIniciales(app);

static void AgregarDatosIniciales(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<AppDbContext>();

    Libro libro1 = new Libro();
    libro1.Id = 1;
    libro1.Nombre = "Lo Que El Viento Se Llevo";
    libro1.Existencia = 3;
    libro1.Prestado = 0;

    Libro libro2 = new Libro();
    libro2.Id = 2;
    libro2.Nombre = "Don Quijote de la Mancha";
    libro2.Existencia = 4;
    libro2.Prestado = 0;

    Libro libro3 = new Libro();
    libro3.Id = 3;
    libro3.Nombre = "Padre Rico, Padre Pobre";
    libro3.Existencia = 7;
    libro3.Prestado = 0;

    db.Libro.Add(libro1);
    db.Libro.Add(libro2);
    db.Libro.Add(libro3);
    db.SaveChanges();


    Usuario usuario1 = new Usuario();
    usuario1.Id = 1;
    usuario1.Username = "admin";
    usuario1.Password = "123";
    usuario1.Nombre = "Pedro Lopez";
    db.Usuario.Add(usuario1);
    db.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
