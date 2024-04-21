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
    public class EventParticipantUnitTests
    {
        private IRepository repository;
        private ILogger<EventParticipantsService> logger;
        private IEventParticipants epService;
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
        public async Task TestGetAllEventsFromUser()
        {
            var loggerMock = new Mock<ILogger<EventParticipantsService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            epService = new EventParticipantsService(repo, logger);

            var result = await epService.AllEventsForUser("e2ef1ea5-0a5d-441c-b3cf-97330a3025ed");

            Assert.That(result.Count(), Is.EqualTo(repo.AllReadOnly<EventParticipant>().Where(ep => ep.ParticipantId == "e2ef1ea5-0a5d-441c-b3cf-97330a3025ed").Count()));
        }

        [Test]
        public async Task TestGetAllParticipantsInEvent()
        {
            var loggerMock = new Mock<ILogger<EventParticipantsService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            epService = new EventParticipantsService(repo, logger);

            var result = await epService.AllParticipantsInEvent(1);

            Assert.That(result.Count(), Is.EqualTo(repo.AllReadOnly<EventParticipant>().Where(e => e.EventId == 1).Count()));
        }

        [Test]
        public async Task TestRemoveAllParticipantsFromEvent()
        {
            var loggerMock = new Mock<ILogger<EventParticipantsService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            epService = new EventParticipantsService(repo, logger);

            await repo.AddRangeAsync(new List<EventParticipant>()
            {
                new EventParticipant() {EventId = 2, ParticipantId = "a016f272-4daa-4d52-a797-ac11a94b48a3"},
                new EventParticipant() {EventId = 2, ParticipantId = "e2ef1ea5-0a5d-441c-b3cf-97330a3025ed"}
            });

            var participants = await epService.AllParticipantsInEvent(2);
            
            foreach(var participant in participants)
            { 
                var ep = new EventParticipant()
                {
                    EventId = participant.EventId,
                    ParticipantId = participant.Id,
                };

                object[] eventp = new object[2] { ep.EventId, ep.ParticipantId };

                await repo.DeleteRangeAsync<EventParticipant>(eventp);
            }

            var result = epService.AllParticipantsInEvent(2).Result;

            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task TestIsUserInTheSameEvent()
        {
            var loggerMock = new Mock<ILogger<EventParticipantsService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            epService = new EventParticipantsService(repo, logger);

            await repo.AddAsync<EventParticipant>(new EventParticipant()
            {
                EventId = 2,
                ParticipantId = "e2ef1ea5-0a5d-441c-b3cf-97330a3025ed"
            });

            var result = await epService.IsUserAlreadyInTheSameOneAsync("e2ef1ea5-0a5d-441c-b3cf-97330a3025ed", 2);

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
        public async Task TestUserCanJoinEvent()
        {
            var loggerMock = new Mock<ILogger<EventParticipantsService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bgDbContext);
            epService = new EventParticipantsService(repo, logger);

            var ep = new EventParticipant()
            {
                EventId = 1,
                ParticipantId = "e2ef1ea5-0a5d-441c-b3cf-97330a3025ed"
            };

            await repo.AddAsync<EventParticipant>(ep);

            var result = epService.AllParticipantsInEvent(2).Result;

            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            bgDbContext.Dispose();
        }
    }
}
