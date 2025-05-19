using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.Models;
using ModelMatch = WebApplication1.Models.Match;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Tests
{
    [TestClass]
    public class MatchesControllerTests
    {
        private ApplicationDbContext _context;
        private MatchesController _controller;

        [TestInitialize]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));

            var serviceProvider = services.BuildServiceProvider();
            _context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            _controller = new MatchesController(_context);
        }

        [TestMethod]
        public async Task CreateMatch_And_RetrieveById_Works()
        {
            // Arrange
            var match = new ModelMatch
            {
                PlayerOne = "John",
                PlayerTwo = "Doe",
                Score = "6-4, 6-4",
                Date = DateTime.UtcNow
            };

            _context.Matches.Add(match);
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.Details(match.Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);

            Assert.IsInstanceOfType(viewResult.Model, typeof(ModelMatch));
            var model = viewResult.Model as ModelMatch;
            Assert.IsNotNull(model);

            Assert.AreEqual("John", model.PlayerOne);
            Assert.AreEqual("Doe", model.PlayerTwo);
            Assert.AreEqual("6-4, 6-4", model.Score);
        }
    }
}
