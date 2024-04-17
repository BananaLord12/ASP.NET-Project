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
    public class EventUnitTests
    {
        private IRepository repository;
        private ILogger<EventService> logger;
        private IEvent eventService;
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
        public async Task TestGetBoardGamesNames()
        {
            var loggerMock = new Mock<ILogger<EventService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            eventService = new EventService(repo, logger);

            var result = await eventService.AllBoardGamesNamesAsync();

            Assert.That(result.Count(), Is.EqualTo(repo.AllReadOnly<BoardGame>().Count()));
        }

        [Test]
        public async Task TestGetAllEvents()
        {
            var loggerMock = new Mock<ILogger<EventService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            eventService = new EventService(repo, logger);

            var result = await eventService.AllEventsAsync();

            Assert.That(result.Count(), Is.EqualTo(repo.AllReadOnly<Event>().Count()));
        }

        [Test]
        public async Task TaskGetAllEventThemes()
        {
            var loggerMock = new Mock<ILogger<EventService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            eventService = new EventService(repo, logger);

            var result = await eventService.AllThemeCategoriesAsync();

            Assert.That(result.Count(), Is.EqualTo(repo.AllReadOnly<Theme>().Count()));
        }

        [Test]
        public async Task TestCheckIfBoardGameExists()
        {
            var loggerMock = new Mock<ILogger<EventService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            eventService = new EventService(repo, logger);

            var result = await eventService.BoardGameNameExistsAsync(1);

            if (result)
            {
                Assert.IsTrue(result);
            }
            else
            {
                Assert.IsFalse(result);
            }
        }

        [Test]
        public async Task TestCreateEvent()
        {
            var loggerMock = new Mock<ILogger<EventService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            eventService = new EventService(repo, logger);

            await repo.AddAsync<Event>(new Event()
            {
                Id = 2,
                Name = "Dungeon",
                Description = ""
            });

            var result = eventService.ExistsAsync(2);

            Assert.That(result.Result, Is.EqualTo(true));
        }

        [Test]
        public async Task TestGetEventDetailById()
        {
            var loggerMock = new Mock<ILogger<EventService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            eventService = new EventService(repo, logger);

            var result = eventService.EventDetailsByIdAsync(1);

            Assert.That(result.Result.Name, Is.EqualTo("Dungeon Crawling"));
        }

        [Test]
        public async Task TestIfEventExists()
        {
            var loggerMock = new Mock<ILogger<EventService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            eventService = new EventService(repo, logger);

            var result = await eventService.ExistsAsync(1);

            if (result)
            {
                Assert.IsTrue(result);
            }
            else
            {
                Assert.IsFalse(result);
            }
        }

        [Test]
        public async Task TestGetBoardGameId()
        {
            var loggerMock = new Mock<ILogger<EventService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            eventService = new EventService(repo, logger);

            var result = await eventService.GetEventBoardGameIdAsync(1);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public async Task TestGetEventsByOrganizerId()
        {
            var loggerMock = new Mock<ILogger<EventService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            eventService = new EventService(repo, logger);

            var result = await eventService.GetEventsByOrganizerId(1);

            Assert.That(result.Count(), Is.EqualTo(repo.AllReadOnly<Event>().Where(e => e.OrganizerId == 1).Count()));
        }

        [Test]
        public async Task TestGetEventThemeId()
        {
            var loggerMock = new Mock<ILogger<EventService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            eventService = new EventService(repo, logger);

            var result = await eventService.GetEventThemeIdAsync(1);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public async Task TestGetUserNamebyUserId()
        {
            var loggerMock = new Mock<ILogger<EventService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            eventService = new EventService(repo, logger);

            var result = await eventService.GetUserNameById("a016f272-4daa-4d52-a797-ac11a94b48a3");

            Assert.That(result, Is.EqualTo("Admin"));
        }

        [Test]
        public async Task TestThemeExists()
        {
            var loggerMock = new Mock<ILogger<EventService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            eventService = new EventService(repo, logger);

            var result = await eventService.ThemeExistsAsync(2);

            if (result)
            {
                Assert.IsTrue(result);
            }
            else
            {
                Assert.IsFalse(result);
            }
        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            bgDbContext.Dispose();
        }
    }
}
