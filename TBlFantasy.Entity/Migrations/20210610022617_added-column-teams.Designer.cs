﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TBlFantasy.Entity;

namespace TBlFantasy.Entity.Migrations
{
    [DbContext(typeof(TBLDContext))]
    [Migration("20210610022617_added-column-teams")]
    partial class addedcolumnteams
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TBlFantasy.Entity.FakeUser", b =>
                {
                    b.Property<Guid>("FakeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("TeamName");

                    b.HasKey("FakeId");

                    b.ToTable("FakeUser");
                });

            modelBuilder.Entity("TBlFantasy.Entity.FakeUserMatches", b =>
                {
                    b.Property<Guid>("MatchId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("FakeId");

                    b.Property<int>("FakeScore");

                    b.Property<string>("FakeTeam");

                    b.Property<Guid>("UserId");

                    b.Property<int>("UserScore");

                    b.Property<string>("UserTeam");

                    b.Property<string>("Week");

                    b.Property<int>("Weeks");

                    b.Property<string>("Winner");

                    b.HasKey("MatchId");

                    b.ToTable("FakeUserMatches");
                });

            modelBuilder.Entity("TBlFantasy.Entity.TBLBasketballer", b =>
                {
                    b.Property<Guid>("BasketballerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int>("Assists");

                    b.Property<decimal>("AverageAssists");

                    b.Property<decimal>("AveragePoints");

                    b.Property<decimal>("AverageRebounds");

                    b.Property<int>("Blocks");

                    b.Property<decimal>("FantasyScore");

                    b.Property<int>("Fauls");

                    b.Property<int>("Height");

                    b.Property<int>("MatchesPlayed");

                    b.Property<string>("Matchtime");

                    b.Property<string>("Name");

                    b.Property<int>("No");

                    b.Property<decimal>("PirValue");

                    b.Property<int>("Points");

                    b.Property<string>("Position");

                    b.Property<int>("Rebounds");

                    b.Property<int>("Steals");

                    b.Property<string>("ThreePointShot");

                    b.Property<string>("TotalTime");

                    b.Property<int>("Turnovers");

                    b.Property<string>("TwoPointShot");

                    b.Property<string>("freeThrown");

                    b.HasKey("BasketballerId");

                    b.ToTable("Basketballer");
                });

            modelBuilder.Entity("TBlFantasy.Entity.TBLLeague", b =>
                {
                    b.Property<Guid>("ligId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("LeagueId");

                    b.Property<string>("Name");

                    b.Property<Guid>("TeamId");

                    b.Property<Guid>("UserId");

                    b.HasKey("ligId");

                    b.ToTable("League");
                });

            modelBuilder.Entity("TBlFantasy.Entity.TBLMatches", b =>
                {
                    b.Property<Guid>("MatchId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("FakeId");

                    b.Property<int>("FakeScore");

                    b.Property<string>("FakeTeam");

                    b.Property<Guid>("UserId");

                    b.Property<int>("UserScore");

                    b.Property<string>("UserTeam");

                    b.Property<string>("Week");

                    b.Property<int>("Weeks");

                    b.Property<string>("Winner");

                    b.HasKey("MatchId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("TBlFantasy.Entity.TBLTeam", b =>
                {
                    b.Property<Guid>("TeamId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<decimal>("FantasyScore");

                    b.Property<int>("GamesPlayed");

                    b.Property<int>("Lose");

                    b.Property<string>("Name");

                    b.Property<int>("Points");

                    b.Property<int>("TeamNumber");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<Guid>("UserId");

                    b.Property<int>("Win");

                    b.HasKey("TeamId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("TBlFantasy.Entity.TBLTeamPlayer", b =>
                {
                    b.Property<Guid>("tpId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BasketballerId");

                    b.Property<Guid>("TeamId");

                    b.Property<int>("TeamNumber");

                    b.HasKey("tpId");

                    b.ToTable("TeamPlayer");
                });

            modelBuilder.Entity("TBlFantasy.Entity.TBLUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("TBlFantasy.Entity.TBLUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("TBlFantasy.Entity.TBLUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TBlFantasy.Entity.TBLUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("TBlFantasy.Entity.TBLUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
