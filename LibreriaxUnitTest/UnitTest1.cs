using Libreria.Controllers;
using Libreria.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace LibreriaxUnitTest
{
    public class UnitTest1
    {
        private Libro libro;
        
        public UnitTest1()
        {            
            ////libro = new Libro()
            ////{
            ////    Id = 20,
            ////    Nombre = "libro 20",
            ////    Existencia = 5,
            ////    Prestado = 0
            ////};            
        }

        ////private IServiceProvider CreateContext(string nameDB)
        ////{
        ////    var services = new ServiceCollection();
        ////    services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: nameDB),
        ////        ServiceLifetime.Scoped,
        ////        ServiceLifetime.Scoped);

        ////    return services.BuildServiceProvider();
        ////}

        ////[Fact]
        ////public async Task GetLibro()
        ////{
        ////    // Arrange
        ////    var nameDB = Guid.NewGuid().ToString();
        ////    var serviceProvider = CreateContext(nameDB);
        ////    var db = serviceProvider.GetService<AppDbContext>();

        ////    // Act
        ////    LibroController servicio = new LibroController(db);
        ////    var response = await servicio.GetLibro(1);

        ////    // Asert
        ////    //Assert.Equal(response.Result, 400);

        ////}

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

        ////[Test]
        ////[TestCase(HttpStatusCode.OK)]
        ////public async Task RemoveLibro(HttpStatusCode code)
        ////{
        ////    // Arrange
        ////    var nameDB = Guid.NewGuid().ToString();
        ////    var serviceProvider = CreateContext(nameDB);
        ////    var db = serviceProvider.GetService<AppDbContext>();
        ////    db.Add(libro);

        ////    // Act
        ////    LibroController servicio = new LibroController(db);
        ////    var response = await servicio.DeleteLibro(3);

        ////    // Asert
        ////    Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        ////}

        ////[Fact]        
        ////public async Task UpdateLibro()
        ////{
        ////    // Arrange
        ////    var nameDB = Guid.NewGuid().ToString();
        ////    var serviceProvider = CreateContext(nameDB);
        ////    var db = serviceProvider.GetService<AppDbContext>();
        ////    db.Add(libro);

        ////    // Act
        ////    LibroController servicio = new LibroController(db);
        ////    var result = await servicio.PutLibro(2, libro);
        ////    //var okResult = result as OkObjectResult;

        ////    // Asert
        ////    //Assert.NotNull(okResult);
        ////   // Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        ////}

    }
}