using BoardGamesWorld.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Infrastructure.Data.SeedDB
{
    public static class SeedDataBase
    {
        public static Organizer Organizer;
        public static IdentityUser AdminUser;
        public static IdentityUser GuestUser;
        public static Category Cooperative;
        public static Theme Campaign;
        public static BoardGame FirstBoardGame;
        public static Event Event;
        public static EventParticipant Participant;

        public static void SeedDatabase(BoardGameWDbContext bg)
        {

            SeedUsers();
            SeedOrganizer();
            SeedCategories();
            SeedTheme();
            SeedBoardGames();
            SeedEvent();
            SeedEventParticipants();

            bg.Add(Organizer);
            bg.Add(AdminUser);
            bg.Add(GuestUser);
            bg.Add(Cooperative);
            bg.Add(Campaign);
            bg.Add(FirstBoardGame);
            bg.Add(Event);
            bg.Add(Participant);

        }

        private static void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AdminUser = new IdentityUser()
            {
                Id = "a016f272-4daa-4d52-a797-ac11a94b48a3",
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
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

        private static void SeedOrganizer()
        {
            Organizer = new Organizer()
            {
                Id = 1,
                Name = "Admin",
                PhoneNumber = "+35988888888",
                UserId = AdminUser.Id
            };
        }

        private static void SeedCategories()
        {

            Cooperative = new Category()
            {
                Id = 3,
                Name = "Cooperative"
            };
        }

        private static void SeedTheme()
        {
            Campaign = new Theme()
            {
                Id = 2,
                Name = "Campaign"
            };
        }

        private static void SeedBoardGames()
        {
            FirstBoardGame = new BoardGame()
            {
                Id = 1,
                Name = "Betrayal Legacy",
                Description = "Betrayal Legacy consists of a prologue and a thirteen-chapter story that takes place over decades.",
                ImageUrl = "https://cf.geekdo-images.com/F4-UGFUM3FfVLWsgBgpFLQ__imagepagezoom/img/O5jPYNofvdcR5rBeBbglWj3e7lc=/fit-in/1200x900/filters:no_upscale():strip_icc()/pic4314964.jpg",
                Price = 150M,
                CategoryId = Cooperative.Id,
                Quantity = 5
            };
        }

        private static void SeedEvent()
        {
            Event = new Event()
            {
                Id = 1,
                Name = "Dungeon Crawling",
                Description = "Exploring Spooky Basement",
                OrganizerName = Organizer.Name,
                ThemeId = Campaign.Id,
                OrganizerId = Organizer.Id,
                BoardGameId = FirstBoardGame.Id,
                Start = DateTime.Parse("18:00 2024/04/01"),
                End = DateTime.Parse("20:00 2024/04/01"),
                RequiredParticipants = 4
            };
        }

        private static void SeedEventParticipants()
        {
            Participant = new EventParticipant()
            {
                EventId = 1,
                ParticipantId = GuestUser.Id
            };
        }
    }
}
