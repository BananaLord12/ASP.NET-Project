using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Core.Services;
using BoardGamesWorld.Infrastructure.Data;
using BoardGamesWorld.Infrastructure.Data.Common;
using BoardGamesWorld.Infrastructure.Data.Models;
using BoardGamesWorld.Infrastructure.Data.SeedDB;
using BoardGamesWorld.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGamesWorld.Core.Models.BoardGame;
using BoardGamesWorld.Core.Models.Home;
namespace BoardGamesWorldUnitTests.UnitTests
{
    [TestFixture]
    public class OrganizerUnitTests
    {
        private IRepository repository;
        private ILogger<OrganizerService> logger;
        private IOrganizerService orgService;
        private BoardGameWDbContext bgDbContext;

        [OneTimeSetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<BoardGameWDbContext>()
                .UseInMemoryDatabase(databaseName: "BoardGamesInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            bgDbContext = new BoardGameWDbContext(dbContextOptions);

            bgDbContext.Database.EnsureCreated();

            SeedDataBase.SeedDatabase(bgDbContext);
        }

        [Test]
        public async Task TestCreateOrganizer()
        {
            var loggerMock = new Mock<ILogger<OrganizerService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            orgService = new OrganizerService(repo);

            await repo.AddAsync<Organizer>(new Organizer()
            {
                Id = 2,
                UserId = "1234abc",
                Name = "Pesho"
            });

            var organizer = await repo.GetByIdAsync<Organizer>(2);

            Assert.That(2, Is.EqualTo(organizer.Id));
        }

        [Test]
        public async Task TestOrganizerExistsByUserId()
        {
            var repo = new Repository(bgDbContext);
            orgService = new OrganizerService(repo);

            var exists = orgService.ExistsByIdAsync("a016f272-4daa-4d52-a797-ac11a94b48a3").Result;

            if (exists)
            {
                Assert.IsTrue(exists);
            }
            else
            {
                Assert.IsFalse(exists);
            }
        }

        [Test]
        public async Task TestGetOrganizerIdByUserId()
        {
            var repo = new Repository(bgDbContext);
            orgService = new OrganizerService(repo);

            var result = await orgService.GetOrganizerIdAsync("a016f272-4daa-4d52-a797-ac11a94b48a3");

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public async Task TestGetPhoneNumberByUserId()
        {
            var repo = new Repository(bgDbContext);
            orgService = new OrganizerService(repo);

            var result = await orgService.GetPhoneNumberFromUserId("a016f272-4daa-4d52-a797-ac11a94b48a3");

            Assert.That(result, Is.EqualTo("+35988888888"));
        }

        [Test]
        public async Task TestOrganizerWithPhoneNumberExists()
        {
            var repo = new Repository(bgDbContext);
            orgService = new OrganizerService(repo);

            var result = await orgService.UserWithPhoneNumberExistsAsync("+35988888888");

            if (result)
            {
                Assert.IsTrue(result);
            }
            else
            {
                Assert.IsFalse(result);
            }
        }
        //a016f272-4daa-4d52-a797-ac11a94b48a3
        [OneTimeTearDown]
        public void TearDownBase()
        {
            bgDbContext.Dispose();
        }
    }
}
