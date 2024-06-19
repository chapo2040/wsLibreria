using Libreria.Controllers;
using Libreria.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject1
{
    public class UnitTest1
    {
        //private readonly WebApplicationFactory<Program> _factory;
        private readonly Libro libro;

        public UnitTest1()
        {
            //var factory = new WebApplicationFactory<Program>();
            //_factory = factory;

            libro = new Libro()
            {
                Id = 20,
                Nombre = "libro 20",
                Existencia = 5,
                Prestado = 0
            };
        }

        private IServiceProvider CreateContext(string nameDB)
        {
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: nameDB),
                ServiceLifetime.Scoped,
                ServiceLifetime.Scoped);

            return services.BuildServiceProvider();
        }

       
        [Theory]
        [InlineData(1)]
        //[InlineData(2)]
        //[InlineData(3)]
        public async Task GetLibro(int currentValue)
        {
            // Arrange
            //var client = _factory.CreateClient();
            //await client.GetAsync("/validpath");

            ////// Act
            ////LibroController servicio = new LibroController(db);
            ////Libro result = await servicio.GetLibro(currentValue);            
            ////Assert.Equal("Lo Que El Viento Se Llevo", result.Nombre);

            ////// Asert            
            ////var loLibro = Assert.IsType<Libro>(result);
            ////Assert.NotNull(result);
            //////Assert.IsType<OkObjectResult>(result);
            //////Assert.IsType<Libro>(result);
            //////Assert.IsType<IActionResult>(result);

        }

        ////[Test]
        ////[TestCase(HttpStatusCode.OK)]
        //////[TestCase(HttpStatusCode.InternalServerError)]
        ////public async Task AddLibro(HttpStatusCode code)
        ////{
        ////    // Arrange
        ////    var nameDB = Guid.NewGuid().ToString();
        ////    var serviceProvider = CreateContext(nameDB);
        ////    var db = serviceProvider.GetService<AppDbContext>();
        ////    db.Add(libro);

        ////    // Act
        ////    LibroController servicio = new LibroController(db);
        ////    var response = await servicio.PostLibro(libro);

        ////    // Asert
        ////    Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        ////}

    }
}