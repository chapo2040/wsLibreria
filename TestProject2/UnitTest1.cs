using Libreria.Controllers;
using Libreria.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject2
{
    [TestFixture]
    public class Tests
    {        
        [SetUp]
        public void Setup()
        {

        }

        private IServiceProvider CreateContext()
        {
            var nameDB = "LibreriaDb";
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: nameDB),
                ServiceLifetime.Scoped,
                ServiceLifetime.Scoped);

            return services.BuildServiceProvider();
        }

        [Test]
        [TestCase(1, 200)]
        //[TestCase(2, 200)]
        //[TestCase(3, 200)]
        public async Task AddLibro(int id, int code)
        {
            // Arrange
            var serviceProvider = CreateContext();
            var db = serviceProvider.GetService<AppDbContext>();
            //db.Add(libro);

            // Act
            LibroController servicio = new LibroController(db);
            var response = await servicio.PostLibro(CrearLibro(id));
            var statusCodeResult = (IStatusCodeActionResult)response;
            
            // Asert           
            //Assert.That(statusCodeResult.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(code));
        }

        private Libro? CrearLibro(int id)
        {
            if (id == 1) { return new Libro(1, "Padre Rico, Padre Pobre", 5, 0); }
            if (id == 2) { return new Libro(2, "Don Quijote", 3, 0); }
            if (id == 3) { return new Libro(3, "Angeles y Demonios", 7, 0); }

            return null;
        }

        [Test]
        [TestCase(1)]
        //[TestCase(2)]
        //[TestCase(3)]
        public async Task GetLibro(int id)
        {
            // Arrange       
            var serviceProvider = CreateContext();
            var db = serviceProvider.GetService<AppDbContext>();

            // Act
            LibroController servicio = new LibroController(db);
            Libro response = await servicio.GetLibro(id);

            // Asert
            Assert.That(response.Id, Is.EqualTo(1));
            Assert.NotNull(response);
        }

        [Test]
        [TestCase(1, 400)]
        public async Task UpdateLibro(int id, int code)
        {
            // Arrange
            var serviceProvider = CreateContext();
            var db = serviceProvider.GetService<AppDbContext>();

            // Act
            LibroController servicio = new LibroController(db);
            var response = await servicio.PutLibro(id, new Libro(4, "Volver el Futuro", 4, 0));
            var statusCodeResult = (IStatusCodeActionResult)response;

            // Asert
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(code));
        }

        [Test]
        [TestCase(1, 200)]
        //[TestCase(2, 200)]
        //[TestCase(3, 400)]
        public async Task RemoveLibro(int id, int code)
        {
            // Arrange
            var serviceProvider = CreateContext();
            var db = serviceProvider.GetService<AppDbContext>();
 
            // Act
            LibroController servicio = new LibroController(db);
            var response = await servicio.DeleteLibro(id);
            var statusCodeResult = (IStatusCodeActionResult)response;

            // Asert
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(code));
        }

    }
}