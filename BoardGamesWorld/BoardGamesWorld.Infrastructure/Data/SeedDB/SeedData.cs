using BoardGamesWorld.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Infrastructure.Data.SeedDB
{
    internal class SeedData
    {
        public IdentityUser AdminUser { get; set; } = new IdentityUser();
        public IdentityUser GuestUser { get; set; } = new IdentityUser();
        public Organizer Organizer { get; set; } = new Organizer();

        public Category Cooperative { get; set; } = new Category();
        public Category Legacy { get; set; } = new Category();
        public Category Card { get; set; } = new Category();
        public Category DeckBuilding { get; set; } = new Category();
        public Category RealTime { get; set; } = new Category();
        public Category StoryTelling { get; set; } = new Category();
        public Category Word { get; set; } = new Category();
        public Category WorkerPlacement { get; set; } = new Category();
        public Category Dice { get; set; } = new Category();
        public Category Trains { get; set; } = new Category();
        public Category Puzzle { get; set; } = new Category();
        public Category Adventure { get; set; } = new Category();

        public Theme Campaign { get; set; } = new Theme();
        public Theme Family { get; set; } = new Theme();
        public Theme Animals { get; set; } = new Theme();
        public Theme CityBuilding { get; set; } = new Theme();
        public Theme Civilization { get; set; } = new Theme();
        public Theme ClassicGames { get; set; } = new Theme();
        public Theme Dungeon { get; set; } = new Theme();
        public Theme Exploration { get; set; } = new Theme();
        public Theme Horror { get; set; } = new Theme();
        public Theme Magic { get; set; } = new Theme();
        public Theme ScienceFiction { get; set; } = new Theme();
        public Theme Trivia { get; set; } = new Theme();

        public BoardGame FirstBoardGame { get; set; } = new BoardGame();
        public BoardGame SecondBoardGame { get; set; } = new BoardGame();
        public BoardGame ThirdBoardGame { get; set; } = new BoardGame();

        public Event Event { get; set; } = new Event();

        public EventParticipant Participant { get; set; } = new EventParticipant();

        public SeedData()
        {
            SeedUsers();
            SeedOrganizer();
            SeedCategories();
            SeedTheme();
            SeedBoardGames();
            SeedEvent();
            SeedEventParticipants();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AdminUser = new IdentityUser()
            {
                Id = "a016f272-4daa-4d52-a797-ac11a94b48a3",
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com"
            };

            AdminUser.PasswordHash = hasher.HashPassword
                (AdminUser, "admin1234");

            GuestUser = new IdentityUser()
            {
                Id = "e2ef1ea5-0a5d-441c-b3cf-97330a3025ed",
                UserName = "user@gmail.com",
                NormalizedUserName = "user@gmail.com",
                Email = "user@gmail.com",
                NormalizedEmail = "user@gmail.com"
            };

            GuestUser.PasswordHash = hasher.HashPassword
                (GuestUser, "user1234");
        }

        private void SeedOrganizer()
        {
            Organizer = new Organizer()
            {
                Id = 1,
                Name = "Admin",
                PhoneNumber = "+35988888888",
                UserId = AdminUser.Id
            };
        }

        private void SeedCategories()
        {
            Adventure = new Category()
            {
                Id = 1,
                Name = "Adventure"
            };

            Card = new Category()
            {
                Id = 2,
                Name = "Card"
            };

            Cooperative = new Category()
            {
                Id = 3,
                Name = "Cooperative"
            };

            DeckBuilding = new Category()
            {
                Id = 4,
                Name = "Deck Building"
            };

            Legacy = new Category()
            {
                Id = 5,
                Name = "Legacy"
            };

            Dice = new Category()
            {
                Id = 6,
                Name = "Dice"
            };

            Puzzle = new Category()
            {
                Id = 7,
                Name = "Puzzle"
            };

            RealTime = new Category()
            {
                Id = 8,
                Name = "Real Time"
            };

            StoryTelling = new Category()
            {
                Id = 9,
                Name = "Story Telling"
            };

            Trains = new Category()
            {
                Id = 10,
                Name = "Train"
            };

            Word = new Category()
            {
                Id = 11,
                Name = "Word"
            };

            WorkerPlacement = new Category()
            {
                Id = 12,
                Name = "Worker Placement"
            };
        }

        private void SeedTheme()
        {
            Animals = new Theme()
            {
                Id = 1,
                Name = "Animals"
            };

            Campaign = new Theme()
            {
                Id = 2,
                Name = "Campaign"
            };

            CityBuilding = new Theme()
            {
                Id = 3,
                Name = "City Building"
            };

            Civilization = new Theme()
            {
                Id = 4,
                Name = "Civilization"
            };

            ClassicGames = new Theme()
            {
                Id = 5,
                Name = "Classic Games"
            };

            Dungeon = new Theme()
            {
                Id = 6,
                Name = "Dungeon"
            };

            Exploration = new Theme()
            {
                Id = 7,
                Name = "Exploration"
            };

            Family = new Theme()
            {
                Id = 8,
                Name = "Family"
            };

            Horror = new Theme()
            {
                Id = 9,
                Name = "Horror"
            };

            Magic = new Theme()
            {
                Id = 10,
                Name = "Magic"
            };

            ScienceFiction = new Theme()
            {
                Id = 11,
                Name = "Science Fiction"
            };

            Trivia = new Theme()
            {
                Id = 12,
                Name = "Trivia"
            };
        }

        private void SeedBoardGames()
        {
            FirstBoardGame = new BoardGame()
            {
                Id = 1,
                Name = "Betrayal Legacy",
                Description = "Betrayal Legacy consists of a prologue and a thirteen-chapter story that takes place over decades.",
                ImageUrl = "https://cf.geekdo-images.com/F4-UGFUM3FfVLWsgBgpFLQ__imagepagezoom/img/O5jPYNofvdcR5rBeBbglWj3e7lc=/fit-in/1200x900/filters:no_upscale():strip_icc()/pic4314964.jpg",
                Price = 150M,
                CategoryId = Legacy.Id,
                Quantity = 5
            };

            SecondBoardGame = new BoardGame()
            {
                Id = 2,
                Name = "Pandemic",
                Description = "In Pandemic, several virulent diseases have broken out simultaneously all over the world!",
                ImageUrl = "https://cf.geekdo-images.com/S3ybV1LAp-8SnHIXLLjVqA__imagepagezoom/img/pD92VJE3Eq9meWfJ6g1pfssPhTA=/fit-in/1200x900/filters:no_upscale():strip_icc()/pic1534148.jpg",
                Price = 60M,
                CategoryId = Cooperative.Id,
                Quantity = 10
            };

            ThirdBoardGame = new BoardGame()
            {
                Id = 3,
                Name = "The Binding of Isaac: FourSouls",
                Description = "Experience the haunted and harrowing world of The Binding of Isaac: Four Souls yourself in this faithful adaptation.",
                ImageUrl = "https://cf.geekdo-images.com/a9XKKnuS1ejixeWRfcxQHQ__imagepagezoom/img/vyfJgyBuQz73NPqDeCMBn4cfAPY=/fit-in/1200x900/filters:no_upscale():strip_icc()/pic8103837.png",
                Price = 200M,
                CategoryId = Card.Id,
                Quantity = 2
            };
        }

        private void SeedEvent()
        {
            Event = new Event()
            {
                Id = 1,
                Name = "Dungeon Crawling",
                Description = "Exploring Spooky Basement",
                OrganizerName = Organizer.Name,
                ThemeId = Exploration.Id,
                OrganizerId = Organizer.Id,
                BoardGameId = ThirdBoardGame.Id,
                Start = DateTime.Parse("18:00 2024/04/01"),
                End = DateTime.Parse("20:00 2024/04/01"),
                RequiredParticipants = 4
            };
        }

        private void SeedEventParticipants()
        {
            Participant = new EventParticipant()
            {
                EventId = 1,
                ParticipantId = GuestUser.Id
            };
        }
    }
}
