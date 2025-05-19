using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

    namespace ProjectTest1.Tests;


    [TestClass]
    public class AccountTest1
    {

        private UserManager<ApplicationUser> _userManager;

        [TestInitialize]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));
            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var serviceProvider = services.BuildServiceProvider();
            _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        }

        [TestMethod]
        public async Task AdminTestAsync()
        {
            // Arrange
            var testEmail = "admin@tennis.com";
            var testPassword = "Admin@123";

            var adminEmail = "admin@tennis.com";
            var adminPassword = "Admin@123";
            var user = new ApplicationUser { UserName = testEmail, Email = testEmail };

            // Act
            var createResult = await _userManager.CreateAsync(user, testPassword);

            // Assert
            var resultUser = await _userManager.FindByEmailAsync(testEmail);
            var resultPassword = await _userManager.CheckPasswordAsync(resultUser,adminPassword);

            Assert.AreEqual(adminEmail, resultUser?.Email);
            Assert.IsTrue(resultPassword);
        }
    }
