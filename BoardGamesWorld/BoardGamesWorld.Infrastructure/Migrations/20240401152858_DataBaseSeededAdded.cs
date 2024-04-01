using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesWorld.Infrastructure.Migrations
{
    public partial class DataBaseSeededAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_Categories_CategoryId",
                table: "BoardGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Themes_ThemeId",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed","LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a016f272-4daa-4d52-a797-ac11a94b48a3", 0, "572c3f6d-0368-452f-b33d-9ab2f158babe", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEPagSmRI6V7rNDAPj90FPUO8W/Fwco/qexGgFhF6RKXNDOIxAkIeqDl7WU1YOxHcuA==", null, false, "b169c9a3-b662-4229-aaa5-a98dc86a7b00", false, "admin@gmail.com" },
                    { "e2ef1ea5-0a5d-441c-b3cf-97330a3025ed", 0, "0c26c3ce-9a12-4fd3-8252-38c6beca7a21", "user@gmail.com", false, false, null, "user@gmail.com", "user@gmail.com", "AQAAAAEAACcQAAAAEBeSDUHCbCCdF0JJRqlC38j18rv2JBPe3nkv+0iQaHcA2gUg0AeDZfE3qz912AXq0w==", null, false, "50ebde87-a756-4c5b-95d7-04e471dfde2a", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adventure" },
                    { 2, "Card" },
                    { 3, "Cooperative" },
                    { 4, "Deck Building" },
                    { 5, "Legacy" },
                    { 6, "Dice" },
                    { 7, "Puzzle" },
                    { 8, "Real Time" },
                    { 9, "Story Telling" },
                    { 10, "Train" },
                    { 11, "Word" },
                    { 12, "Worker Placement" }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Animals" },
                    { 2, "Campaign" },
                    { 3, "City Building" },
                    { 4, "Civilization" },
                    { 5, "Classic Games" },
                    { 6, "Dungeon" },
                    { 7, "Exploration" },
                    { 8, "Family" },
                    { 9, "Horror" },
                    { 10, "Magic" },
                    { 11, "Science Fiction" },
                    { 12, "Trivia" }
                });

            migrationBuilder.InsertData(
                table: "BoardGames",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 5, "Betrayal Legacy consists of a prologue and a thirteen-chapter story that takes place over decades.", "https://cf.geekdo-images.com/F4-UGFUM3FfVLWsgBgpFLQ__imagepagezoom/img/O5jPYNofvdcR5rBeBbglWj3e7lc=/fit-in/1200x900/filters:no_upscale():strip_icc()/pic4314964.jpg", "Betrayal Legacy", 150m, 5 },
                    { 2, 3, "In Pandemic, several virulent diseases have broken out simultaneously all over the world!", "https://cf.geekdo-images.com/S3ybV1LAp-8SnHIXLLjVqA__imagepagezoom/img/pD92VJE3Eq9meWfJ6g1pfssPhTA=/fit-in/1200x900/filters:no_upscale():strip_icc()/pic1534148.jpg", "Pandemic", 60m, 10 },
                    { 3, 2, "Experience the haunted and harrowing world of The Binding of Isaac: Four Souls yourself in this faithful adaptation.", "https://cf.geekdo-images.com/a9XKKnuS1ejixeWRfcxQHQ__imagepagezoom/img/vyfJgyBuQz73NPqDeCMBn4cfAPY=/fit-in/1200x900/filters:no_upscale():strip_icc()/pic8103837.png", "The Binding of Isaac: FourSouls", 200m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "Id", "Name", "PhoneNumber", "UserId" },
                values: new object[] { 1, "Admin", "+35988888888", "a016f272-4daa-4d52-a797-ac11a94b48a3" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "BoardGameId", "Description", "End", "Name", "OrganizerId", "OrganizerName", "RequiredParticipants", "Start", "ThemeId" },
                values: new object[] { 1, 3, "Exploring Spooky Basement", new DateTime(2024, 4, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), "Dungeon Crawling", 1, "Admin", 4, new DateTime(2024, 4, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_Categories_CategoryId",
                table: "BoardGames",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "Organizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Themes_ThemeId",
                table: "Events",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_Categories_CategoryId",
                table: "BoardGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Themes_ThemeId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2ef1ea5-0a5d-441c-b3cf-97330a3025ed");

            migrationBuilder.DeleteData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a016f272-4daa-4d52-a797-ac11a94b48a3");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_Categories_CategoryId",
                table: "BoardGames",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "Organizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Themes_ThemeId",
                table: "Events",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
