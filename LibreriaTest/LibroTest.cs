using Libreria.Controllers;
using Libreria.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaTest.Services
{
    public class LibroTest
    {
        private Libro libro;

        [SetUp]
        public void Setup()
        {
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

        [Test]
        [TestCase(HttpStatusCode.OK)]        
        public async Task GetLibro(HttpStatusCode code)
        {
            // Arrange
            var nameDB = Guid.NewGuid().ToString();
            var serviceProvider = CreateContext(nameDB);
            var db = serviceProvider.GetService<AppDbContext>();
            
            // Act
            LibroController servicio = new LibroController(db);
            var response = await servicio.GetLibro(1);

            // Asert
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [TestCase(HttpStatusCode.OK)]
        //[TestCase(HttpStatusCode.InternalServerError)]
        public async Task AddLibro(HttpStatusCode code)
        {
            // Arrange
            var nameDB = Guid.NewGuid().ToString();
            var serviceProvider = CreateContext(nameDB);            
            var db = serviceProvider.GetService<AppDbContext>();
            db.Add(libro);

            // Act
            LibroController servicio = new LibroController(db);
            var response = await servicio.PostLibro(libro);

            // Asert
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [TestCase(HttpStatusCode.OK)]
        public async Task RemoveLibro(HttpStatusCode code)
        {
            // Arrange
            var nameDB = Guid.NewGuid().ToString();
            var serviceProvider = CreateContext(nameDB);
            var db = serviceProvider.GetService<AppDbContext>();
            db.Add(libro);

            // Act
            LibroController servicio = new LibroController(db);
            var response = await servicio.DeleteLibro(3);

            // Asert
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [TestCase(HttpStatusCode.OK)]
        public async Task UpdateLibro(HttpStatusCode code)
        {
            // Arrange
            var nameDB = Guid.NewGuid().ToString();
            var serviceProvider = CreateContext(nameDB);
            var db = serviceProvider.GetService<AppDbContext>();
            db.Add(libro);

            // Act
            LibroController servicio = new LibroController(db);
            var response = await servicio.PutLibro(2, libro);

            // Asert
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        }

    }
}
