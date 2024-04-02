﻿// <auto-generated />
using System;
using BoardGamesWorld.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoardGamesWorld.Infrastructure.Migrations
{
    [DbContext(typeof(BoardGameWDbContext))]
    partial class BoardGameWDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BoardGamesWorld.Infrastructure.Data.Models.BoardGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Board Game Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Board Game Category Identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("Board Game Description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Board Game Image URL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Board Game Name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Board Game Price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasComment("Board Game Amount");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("BoardGames");

                    b.HasComment("Information For Board Game");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 5,
                            Description = "Betrayal Legacy consists of a prologue and a thirteen-chapter story that takes place over decades.",
                            ImageUrl = "https://cf.geekdo-images.com/F4-UGFUM3FfVLWsgBgpFLQ__imagepagezoom/img/O5jPYNofvdcR5rBeBbglWj3e7lc=/fit-in/1200x900/filters:no_upscale():strip_icc()/pic4314964.jpg",
                            Name = "Betrayal Legacy",
                            Price = 150m,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            Description = "In Pandemic, several virulent diseases have broken out simultaneously all over the world!",
                            ImageUrl = "https://cf.geekdo-images.com/S3ybV1LAp-8SnHIXLLjVqA__imagepagezoom/img/pD92VJE3Eq9meWfJ6g1pfssPhTA=/fit-in/1200x900/filters:no_upscale():strip_icc()/pic1534148.jpg",
                            Name = "Pandemic",
                            Price = 60m,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "Experience the haunted and harrowing world of The Binding of Isaac: Four Souls yourself in this faithful adaptation.",
                            ImageUrl = "https://cf.geekdo-images.com/a9XKKnuS1ejixeWRfcxQHQ__imagepagezoom/img/vyfJgyBuQz73NPqDeCMBn4cfAPY=/fit-in/1200x900/filters:no_upscale():strip_icc()/pic8103837.png",
                            Name = "The Binding of Isaac: FourSouls",
                            Price = 200m,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("BoardGamesWorld.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Category Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Category Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasComment("Board Game Category ");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Card"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cooperative"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Deck Building"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Dice"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Legacy"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Puzzle"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Real Time"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Story Telling"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Train"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Word"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Worker Placement"
                        });
                });

            modelBuilder.Entity("BoardGamesWorld.Infrastructure.Data.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Event Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BoardGameId")
                        .HasColumnType("int")
                        .HasComment("Board Game Identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Event Description");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2")
                        .HasComment("Event End Time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasComment("Event Name");

                    b.Property<int>("OrganizerId")
                        .HasColumnType("int")
                        .HasComment("Organizer Identifier");

                    b.Property<string>("OrganizerName")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasComment("Organizer's Name");

                    b.Property<int>("RequiredParticipants")
                        .HasColumnType("int")
                        .HasComment("Participants Required");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2")
                        .HasComment("Event Start Time");

                    b.Property<int>("ThemeId")
                        .HasColumnType("int")
                        .HasComment("Theme Identifier");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.HasIndex("OrganizerId");

                    b.HasIndex("ThemeId");

                    b.ToTable("Events");

                    b.HasComment("Information for the Event");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BoardGameId = 3,
                            Description = "Exploring Spooky Basement",
                            End = new DateTime(2024, 4, 1, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Dungeon Crawling",
                            OrganizerId = 1,
                            OrganizerName = "Admin",
                            RequiredParticipants = 4,
                            Start = new DateTime(2024, 4, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            ThemeId = 7
                        });
                });

            modelBuilder.Entity("BoardGamesWorld.Infrastructure.Data.Models.EventParticipant", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("ParticipantId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EventId", "ParticipantId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("EventParticipants");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            ParticipantId = "e2ef1ea5-0a5d-441c-b3cf-97330a3025ed"
                        });
                });

            modelBuilder.Entity("BoardGamesWorld.Infrastructure.Data.Models.Organizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Organizer Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasComment("Organizer Name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasComment("Organizer's Phone Number");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Organizers");

                    b.HasComment("Event Organizer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            PhoneNumber = "+35988888888",
                            UserId = "a016f272-4daa-4d52-a797-ac11a94b48a3"
                        });
                });

            modelBuilder.Entity("BoardGamesWorld.Infrastructure.Data.Models.Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Theme Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Theme Name");

                    b.HasKey("Id");

                    b.ToTable("Themes");

                    b.HasComment("Event Theme");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Animals"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Campaign"
                        },
                        new
                        {
                            Id = 3,
                            Name = "City Building"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Civilization"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Classic Games"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Dungeon"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Exploration"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Family"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Magic"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Trivia"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a016f272-4daa-4d52-a797-ac11a94b48a3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f46aee8b-98f6-436a-9de9-fa4bb754a00f",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEOrrOg/kZf/q4QsZjl8bbZK64XHqlY8HaFNo5zJ+uFF4mRsyyvO2F21o1jh3vrIj1Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2df11ff7-75e5-4ccb-b414-36a021635404",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = "e2ef1ea5-0a5d-441c-b3cf-97330a3025ed",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "11e54952-5aee-488b-8249-bb0ad2647b50",
                            Email = "user@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "user@gmail.com",
                            NormalizedUserName = "user@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEDqaTgsnG0LMKgY1u1JbMTS7I5lurQmLvmvUWiEQ9hwVE7sRt65tgQPi++GNy9/qHw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "99ca2f44-39d7-482a-97e2-428b54b55c83",
                            TwoFactorEnabled = false,
                            UserName = "user@gmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BoardGamesWorld.Infrastructure.Data.Models.BoardGame", b =>
                {
                    b.HasOne("BoardGamesWorld.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("BoardGames")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BoardGamesWorld.Infrastructure.Data.Models.Event", b =>
                {
                    b.HasOne("BoardGamesWorld.Infrastructure.Data.Models.BoardGame", "BoardGame")
                        .WithMany("Events")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGamesWorld.Infrastructure.Data.Models.Organizer", "Organizer")
                        .WithMany("Events")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BoardGamesWorld.Infrastructure.Data.Models.Theme", "Theme")
                        .WithMany("Events")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BoardGame");

                    b.Navigation("Organizer");

                    b.Navigation("Theme");
                });

            modelBuilder.Entity("BoardGamesWorld.Infrastructure.Data.Models.EventParticipant", b =>
                {
                    b.HasOne("BoardGamesWorld.Infrastructure.Data.Models.Event", "Event")
                        .WithMany("Participants")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("BoardGamesWorld.Infrastructure.Data.Models.Organizer", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BoardGamesWorld.Infrastructure.Data.Models.BoardGame", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("BoardGamesWorld.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("BoardGames");
                });

            modelBuilder.Entity("BoardGamesWorld.Infrastructure.Data.Models.Event", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("BoardGamesWorld.Infrastructure.Data.Models.Organizer", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("BoardGamesWorld.Infrastructure.Data.Models.Theme", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
