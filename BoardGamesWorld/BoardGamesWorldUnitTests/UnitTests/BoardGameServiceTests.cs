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
    public class BoardGameServiceTests
    {
        private IRepository repository;
        private ILogger<BoardGamesService> logger;
        private IBoardGameService bgService;
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
        public async Task TestBoardGameEdit()
        {
            var loggerMock = new Mock<ILogger<BoardGamesService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            bgService = new BoardGamesService(repo, loggerMock.Object);

            await repo.AddAsync<BoardGame>(new BoardGame()
            {
                Id = 2,
                Name = "",
                ImageUrl = "",
                Description = ""
            });

            //await repo.SaveChangedAsync();

            await bgService.Edit(2, new BGModel()
            {
                Id = 2,
                Name = "",
                ImageUrl = "",
                Description = "This board game is edited"
            });

            var bg = await repo.GetByIdAsync<BoardGame>(2);

            Assert.That(bg.Description, Is.EqualTo("This board game is edited"));
        }
        [Test]
        public async Task TestToRetrieveAllBoardGames()
        {
            var loggerMock = new Mock<ILogger<BoardGamesService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            bgService = new BoardGamesService(repo, loggerMock.Object);

            int count = bgService.AllBoardGamesAsync().Result.Count();
            int result = repo.AllReadOnly<BoardGame>().Count();

            Assert.That(count, Is.EqualTo(result));
        }

        [Test]
        public async Task TestToRetrieveAllCategory()
        {
            var loggerMock = new Mock<ILogger<BoardGamesService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            bgService = new BoardGamesService(repo, loggerMock.Object);

            var categories = bgService.AllCategories().Result.Count();
            var result = repo.AllReadOnly<Category>().Count();

            Assert.That(categories, Is.EqualTo(result));
        }

        [Test]
        public async Task TestBoardGameDetails()
        {
            var loggerMock = new Mock<ILogger<BoardGamesService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            bgService = new BoardGamesService(repo, loggerMock.Object);

            var bg = bgService.BoardGameDetailsById(1);

            if (bg == null)
            {
                Assert.IsNull(bg);
            }

            Assert.That(bg.Result.Name, Is.EqualTo("Betrayal Legacy"));
        }

        [Test]
        public async Task TestCheckIfCategoryExists()
        {
            var loggerMock = new Mock<ILogger<BoardGamesService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            bgService = new BoardGamesService(repo, loggerMock.Object);

            var exists = bgService.CategoryExists(3).Result;

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
        public async Task TestToCreateBoardGame()
        {
            var loggerMock = new Mock<ILogger<BoardGamesService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            bgService = new BoardGamesService(repo, loggerMock.Object);

            await repo.AddAsync<BoardGame>(new BoardGame()
            {
                Id = 2,
                Name = "Pandemic Legacy",
                Description = "",
                ImageUrl = "",
                Quantity = 10
            });

            var boardGame = repo.GetByIdAsync<BoardGame>(2);

            Assert.That(boardGame.Result.Name, Is.EqualTo("Pandemic Legacy"));

        }

        [Test]
        public async Task TaskToDeleteBoardGame()
        {
            var loggerMock = new Mock<ILogger<BoardGamesService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            bgService = new BoardGamesService(repo, loggerMock.Object);

            await repo.AddAsync<BoardGame>(new BoardGame()
            {
                Id = 2,
                Name = "Pandemic Legacy",
                Description = "",
                ImageUrl = "",
                Quantity = 10
            });

            await repo.DeleteAsync<BoardGame>(2);

            bool isHere = await bgService.Exists(2);

            if (isHere)
            {
                Assert.IsTrue(isHere);
            }
            else
            {
                Assert.IsFalse(isHere);
            }
        }

        [Test]
        public async Task TaskGetCategoryId()
        {
            var loggerMock = new Mock<ILogger<BoardGamesService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            bgService = new BoardGamesService(repo, loggerMock.Object);

            var categoryid = await bgService.GetHouseCategoryId(1);

            Assert.That(categoryid, Is.EqualTo(3));
        }

        [Test]
        public async Task TestTakeLastThreeBoardGames()
        {
            var loggerMock = new Mock<ILogger<BoardGamesService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            bgService = new BoardGamesService(repo, loggerMock.Object);

            await repo.AddRangeAsync(new List<BoardGame>()
            {
                new BoardGame() {Id = 2, Name="", Description="", ImageUrl=""},
                new BoardGame() {Id = 5, Name="", Description="", ImageUrl=""},
                new BoardGame() {Id = 7, Name="", Description="", ImageUrl=""},
                new BoardGame() {Id = 3, Name="", Description="", ImageUrl=""}
            });

            var boardgamecollection = await bgService.LastThreeBoardGamesAsync();
            Assert.That(3, Is.EqualTo(boardgamecollection.Count()));
        }

        [Test]
        public async Task TestGetCategoryNames()
        {
            var loggerMock = new Mock<ILogger<BoardGamesService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            bgService = new BoardGamesService(repo, loggerMock.Object);

            var categoryNames = await bgService.AllCategoriesNames();

            Assert.That(categoryNames.Count(),Is.EqualTo(12));
        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            bgDbContext.Dispose();
        }
    }
}
